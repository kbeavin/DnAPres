using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DnAPresa.UI.Models
{
    public class LoginModels
    {
        public LoginModels()
        {

        }
        public LoginModels(string Username, string Password)
        {
            this.Username = Username;
            this.Password = Password;
        }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}