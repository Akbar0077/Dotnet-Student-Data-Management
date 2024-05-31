using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StoreAppMVVM1.Helper
{
    public class Notify : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnProperty([CallerMemberName] string propname="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propname));  
        }
    }
}
