using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;
using StoreAppMVVM1.Helper;
using StoreAppMVVM1.Model;
using StoreAppMVVM1.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Linq;
using System.Xml.Serialization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace StoreAppMVVM1.ViewModel
{
    public class RegisterViewModel : Notify
    {
        public RelayCommand RegisterCommand { get; set; }
        public RelayCommand ClearCommand { get; set; }

        public RelayCommand SearchCommand { get; set; }
        public ObservableCollection<Student> SearchList { get; set; }
        private string _searchuser;
        public string SearchUser
        {
            get { return _searchuser; }
            set
            {
                _searchuser = value;
                OnProperty();
            }
        }

        private Student _student;
        

        public Student Student
        {
            get{ return _student; }
            set { _student = value; }
        }
      

      
        public ObservableCollection<Student> StudentList
        {
            get; set;
        }
        public DataTable _data;
         public DataTable data
         {
            get { return _data; }
            set { _data = value;
                OnProperty();
            }
         }

        public RegisterViewModel()
        {
            RegisterCommand = new RelayCommand(RegisterData);
            ClearCommand = new RelayCommand(ClearData);
            SearchCommand = new RelayCommand(SearchData);
            if (Student == null)
            {
                Student = new Student();
            }
            if (StudentList == null)
            {
                StudentList = new ObservableCollection<Student>();
            }
            if (SearchList == null)
            {
                SearchList = new ObservableCollection<Student>();
            }
            //Student.Gen = "M";
            Student.isGenShow = true;
        }
        public void RegisterData()
        {
            StudentList.Add(new Student { Name = Student.Name, Age = Student.Age, Password = Student.Password, Salary = Student.Salary,Gen=Student.Gen });

            SqlConnection sqlnn = new SqlConnection(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=April26;Data Source=DESKTOP-3K843UQ\SQLEXPRESS;Encrypt=false");
            sqlnn.Open();
            SqlCommand ssql = new SqlCommand($"INSERT INTO EEMP1 VALUES('{Student.Name}',{Student.Age},'{Student.Password}',{Student.Salary})", sqlnn);
            ssql.ExecuteNonQuery();
            MessageBox.Show("Register Successful");

            //Login log = new Login();
            //log.Show();
        }
        public void SearchData()
        {
            //SqlConnection sqlnn = new SqlConnection(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=April26;Data Source=DESKTOP-3K843UQ\SQLEXPRESS;Encrypt=false");
            //sqlnn.Open();
            ////SqlCommand sqlCommand1 = new SqlCommand();
            ////sqlCommand1.Connection = sqlnn;
            ////sqlCommand1.CommandText = $"SELECT * FROM EEMP1 WHERE ENAME='{Student.Name}'";
            ////sqlCommand1.ExecuteNonQuery();

            //SqlDataAdapter sqlData = new SqlDataAdapter("SELECT * FROM EEMP1", sqlnn);
            //DataTable odata = new DataTable();
            //sqlData.Fill(odata);
            //data = odata;
            ////datagrid.ItemsSource = odata.Tables["EEMP1"].DefaultView;
            //sqlnn.Close();

            SearchList.Clear();
            foreach (Student user in StudentList)
            {
                if (user.Name.ToLower().Contains(SearchUser.ToLower()))
                {
                    SearchList.Add(user);
                }
            }




        }
        public void ClearData()
        {
            Student.Name = "";
            Student.Age = 0;
            Student.Password = "";
            Student.Salary = 0;
            

        }
    }
}
