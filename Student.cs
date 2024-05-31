using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreAppMVVM1.Helper;

namespace StoreAppMVVM1.Model
{
    public class Student:Notify
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set
           {
                _name = value;
                OnProperty();
            }
        }
        private int _age;

        public int Age
        {
            get { return _age; }
            set
            {
                _age = value;
                OnProperty();
            }
        }
        private string _password;

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnProperty();
            }
        }
        private int _salary;

        public int Salary
        {
            get { return _salary; }
            set { _salary = value;
                OnProperty();
            }
        }
        private string _gen;
        public string Gen
        {
            get { return _gen; }
            set
            {
                _gen = value;
                OnProperty();
            }
        }
        private bool _isGenShow;

        public bool isGenShow
        {
            get { return _isGenShow; }
            set
            {
                _isGenShow = value;
                OnProperty();
            }
        }



    }
}
