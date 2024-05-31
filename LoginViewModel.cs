using Microsoft.Data.SqlClient;
using StoreAppMVVM1.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using StoreAppMVVM1.View;

namespace StoreAppMVVM1.ViewModel
{
    public class LoginViewModel
    {
        public RelayCommand LoginCommand { get; set; }
        public RelayCommand RegisterCommand { get; set; }
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private string _password;

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(LoginData);

            string name = _name;
            string password = _password;

            
           
            
        }
        public void LoginData()
        {
            SqlConnection sqlnn = new SqlConnection(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=April26;Data Source=DESKTOP-3K843UQ\SQLEXPRESS;Encrypt=false");
            sqlnn.Open();
            SqlCommand ssql = new SqlCommand($"SELECT * FROM EEMP1 WHERE EName='{_name}' and PASSWORDD='{_password}'",sqlnn);
            ssql.ExecuteScalar();
            MessageBox.Show("Login Successful");

           
        }
        
    }
}
