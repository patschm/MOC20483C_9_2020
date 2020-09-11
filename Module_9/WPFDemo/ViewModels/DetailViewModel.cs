using System;
using System.Collections.Generic;
using System.Text;

namespace WPFDemo.ViewModels
{
    public class DetailViewModel
    {
        public PersonViewModel Person { get; set; }
        public List<PersonViewModel> People { get; set; } = new List<PersonViewModel>();
    }
}
