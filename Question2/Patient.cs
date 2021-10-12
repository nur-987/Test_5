using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question2
{
    class Patient
    {
        public int PatientId { get; set; }
        public string Name { get; set; }
        public Treatment PaitentTreatment { get; set; }
        public string PatientIssue { get; set; }
        public bool SeenDoctor { get; set; }
        public bool Discharged { get; set; }

        public DateTime DateRegistered { get; set; }
    }

    enum Treatment
    {
        Emergency,Operation,Specialist
    }
}
