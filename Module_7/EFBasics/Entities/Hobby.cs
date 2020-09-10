using System;
using System.Collections.Generic;
using System.Text;

namespace EFBasics.Entities
{
    public class Hobby
    {
        public int ID { get; set; }
        public string Description { get; set; }

        // Navigation
        public ICollection<PersonHobby> People { get; set; } = new HashSet<PersonHobby>();
    }
}
