using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DnAScreener
{
    /// <summary>
    /// Data Management class for accessing the database.
    /// </summary>
    /// <remarks>Re-implimentation should be done by creating this class as a component.</remarks>
    public class DataMgr
    {
        #region DataMembers
        protected static SqlConnection myConnection = new SqlConnection();
        protected static SqlCommand myCommand;
        protected static SqlDataAdapter myAdapter;
        #endregion

        #region Public Members
        public string uname, password;
        public int TotalActiveDrivers { get; set; }
        public int DriverPoolPercentage { get; set; }
        public int AlchoholPercentage { get; set; }
        public bool PrintActiveDriverList { get; set; }
        public DataTable empList { get; set; }
        public EmployeeList myEmpList { get; set; }
        public string terminal { get; set; }
        #endregion

        #region ConnectionMethods
        public void Connect()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            
            builder.ApplicationName = "DnA Presa";
            builder.TrustServerCertificate = true;
           //kyle out builder.DataSource = "TMWDB\\TMW";
            builder.DataSource = "NAUS03TMW1";
            builder.ConnectTimeout = 30;
            builder.Encrypt = true;
            builder.InitialCatalog = "TMW_Live";
            builder.IntegratedSecurity = false;
            builder.PersistSecurityInfo = false;
            builder.UserID = this.uname.ToUpper();
            builder.Password = this.password.ToUpper();
            //builder.UserID = uname.ToUpper();
            //builder.Password = password.ToUpper();
            builder.IntegratedSecurity = true;

            if (!(myConnection.State == System.Data.ConnectionState.Closed || myConnection.State == System.Data.ConnectionState.Broken))
                Disconnect();

            initConnection(builder);
        }

        public bool Disconnect()
        {
            try
            {
                myConnection.Close();
                return true;
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.ToString());
                return false;
            }
        }

        private void initConnection(SqlConnectionStringBuilder builder)
        {
            myConnection = new SqlConnection(builder.ToString());

            try
            {
                myConnection.Open();

            }
            catch (Exception e)
            {
              //  MessageBox.Show(e.ToString());
            }
        }
        #endregion

        #region Constructors
        public DataMgr(string uname, string pwd)
        {
            this.uname = uname;
            this.password = pwd;
            terminal = string.Empty;
        }

        public DataMgr(string uname, string pwd, int drivers, int pool, int alch, bool print)
        {
            this.uname = uname;
            this.password = pwd;
            this.TotalActiveDrivers = drivers;
            this.DriverPoolPercentage = pool;
            this.AlchoholPercentage = alch;
            this.PrintActiveDriverList = print;
            terminal = string.Empty;
        }

        public DataMgr()
        {
            terminal = string.Empty;
        }
        #endregion

        #region Data Retrival Methods
        /// <summary>
        /// Simplified method for retriving data from the non_driveremployees table.
        /// </summary>
        /// <param name="Criteria">Criteria for which data should be returned.</param>
        /// <returns>DataTable matching the criteria.</returns>
        private DataTable getUnspecified(string Criteria){
            Connect();

            System.Data.DataTable myData = new System.Data.DataTable();
            //myCommand = new SqlCommand("SELECT SSN,	EmployID AS EmployeeID,	LastName AS LName, 	FrstName AS FNAME, 	MidlName AS MI, 	EmplClas AS EmpClass,	DB from 	carter_nondriveremployees " + Criteria, myConnection);
            myCommand = new SqlCommand("SELECT mpp_ssn as SSN, EmployeeNumber as EmployeeID, ISNULL(mpp_id, '') as TMWDriverID, " +
                "EmployeeLastName as LName, EmployeeFirstName as FNAME, LEFT(LTRIM(EmployeeMiddleName), 1) as MI, Tier3 as EmplClass, " +
                "'CEXPL' as DB FROM [naus03sql2].CarterProd.dbo.tbl_DNA_CurrentEmployees ce " +
                "LEFT OUTER JOIN [NAUS03TMW1].TMW_Live.dbo.manpowerprofile mpp ON (mpp.mpp_id=ce.EmployeeNumber OR mpp.mpp_otherid=ce.EmployeeNumber)" +
                terminal + Environment.NewLine + Criteria, myConnection);
            myAdapter = new SqlDataAdapter();
            myAdapter.SelectCommand = myCommand;
            myAdapter.Fill(myData);

            Disconnect();
            return myData;
        }

        public DataTable getDrivers()
        {
            return getUnspecified("	WHERE Tier3 = 'Drivers'");
        }

        public DataTable getCEXPOffice()
        {

            return getUnspecified("	WHERE Tier3 = 'Office'");
        }

        public DataTable getCEXPWarehouse()
        {
            return getUnspecified("	WHERE Tier3 = 'Warehouse'");
        }

        public DataTable getCLL()
        {
            return getUnspecified("	WHERE Tier3 = 'Logistics'");
        }

        public DataTable getDukel()
        {
            return getUnspecified("	WHERE Tier3 = 'Dukes'");
        }

        public DataTable getCantons()
        {
            terminal = "inner join TMW_Live.dbo.labelfile lf on mpp_terminal = lf.abbr and lf.labeldefinition = 'terminal'";
            return getUnspecified(" WHERE lf.abbr = 'CW'");
        }

        /// <summary>
        /// Gets all drivers from the manpowerprofile.
        /// </summary>
        /// <returns></returns>
        internal DataTable getActiveDriverList() {
            Connect();

            System.Data.DataTable myData = new System.Data.DataTable();
            myCommand = new SqlCommand("select    mpp_lastfirst as [Driver Name], mpp_id as [Driver ID], dbo.fn_DType(mpp_id) as [Driver Type] from      manpowerprofile where   mpp_terminationdt >= '2049-12-31 00:00:00' and mpp_id not in ('UNKNOWN', 'TEST') AND mpp_status <> 'DEC' AND mpp_status <> 'OUT' AND mpp_status <> 'WC' AND mpp_status <> 'RET' AND mpp_status <>'MLOA' AND mpp_status <>'MTLOA' AND mpp_status <> 'FMLA' order by mpp_lastfirst", myConnection);
            myAdapter = new SqlDataAdapter();
            myAdapter.SelectCommand = myCommand;
            myAdapter.Fill(myData);

            Disconnect();
            return myData;
        }
        #endregion

        #region Data Input Methods
        /// <summary>
        /// Inserts the DataTable source into the DnAHistory table.
        /// This method was used over an update due to an employee existing as both a driver and warehouse worker.
        /// As well as several employees having the same ID.
        /// As such, no unique key was able to be generated by which the row can be accurately updated.
        /// </summary>
        /// <param name="source"></param>
        internal void insertHistory(DataTable source) {
            Connect();

            System.Data.DataTable myData = new System.Data.DataTable();
            myCommand = new SqlCommand("SELECT   EmployID,	LastName, 	FrstName, 	MidlName, 	EmplClas,	DB, TestSel, Report_DateTime 	from carter_dnahistory", myConnection);
            myAdapter = new SqlDataAdapter();
            myAdapter.SelectCommand = myCommand;
            SqlCommandBuilder builder = new SqlCommandBuilder(myAdapter);

            myAdapter.InsertCommand = builder.GetInsertCommand();
            //MessageBox.Show(myAdapter.InsertCommand.CommandText);
            myAdapter.Update(source);
            Disconnect();
            //return myData;
        }
        #endregion
    }
}
