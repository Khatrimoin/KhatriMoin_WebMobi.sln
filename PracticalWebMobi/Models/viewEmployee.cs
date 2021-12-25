using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticalWebMobi.Models
{
    public class viewEmployee
    {
        public int employeeId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string gender { get; set; }
        public System.DateTime dateOfBirth { get; set; }
        public byte[] profilephoto { get; set; }
        public int departmentId { get; set; }
        public string departmentName { get; set; }

        public Nullable<bool> status { get; set; }

    }
}