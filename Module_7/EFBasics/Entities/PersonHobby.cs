using System;
using System.Collections.Generic;
using System.Text;

namespace EFBasics.Entities
{
    public class PersonHobby
    {
        // Simpel properties
        public int PersonID { get; set; }
        public int HobbyID { get; set; }

        // Navigation Properties
        public Person Person { get; set; }
        public Hobby Hobby { get; set; }

    }
}
