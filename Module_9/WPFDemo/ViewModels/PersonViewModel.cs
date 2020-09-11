using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace WPFDemo.ViewModels
{
    public class PersonViewModel : INotifyPropertyChanged
    {
        private string name;
        public int Age { get; set; }
        public string Name 
        { 
            get
            {
                return name;
            }
            set
            {
                name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
