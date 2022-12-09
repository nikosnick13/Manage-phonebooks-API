using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace phoneCATALOG.Models
{
    public class Phone
    {
        // id KEY
        public int Id { get; set; }
        public string FullName { get; set; }
        public int PhoneNumber { get; set; }
        public string Type { get; set; }

        public List<Phone> myPhoneList = new List<Phone>();
    }

    
}