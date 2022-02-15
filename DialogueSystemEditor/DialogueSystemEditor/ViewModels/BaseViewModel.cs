using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DialogueSystemEditor.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string _propertyName = "")
        {
            if (!string.IsNullOrWhiteSpace(_propertyName))
            {
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(_propertyName));
            }
        }
    }
}
