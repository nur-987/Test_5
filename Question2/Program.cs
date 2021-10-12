using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question2
{
    class Program
    {
        public static List<Patient> patientsList = new List<Patient>();
        static void Main(string[] args)
        {
            Console.WriteLine("-------------Register Patient-------------");
            Console.WriteLine("enter ID");
            int tempId = Int32.Parse(Console.ReadLine());

            Console.WriteLine("enter NAME");
            string tempName = Console.ReadLine();

            Console.WriteLine("enter COMPLAINT");
            string tempIssue = Console.ReadLine();

            Console.WriteLine("Choose a treatment");
            Console.WriteLine("1)" + Treatment.Emergency.ToString());
            Console.WriteLine("2)" + Treatment.Operation.ToString());
            Console.WriteLine("3)" + Treatment.Operation.ToString());
            int res = Int32.Parse(Console.ReadLine());

            Register(tempId, tempName, tempIssue, res);


            DisplayAll();

            Console.WriteLine("-------------See Doctor-------------");
            SeeDoctor();

        }

        public static void Register(int id, string name, string issue, int res)
        {
            Patient newPatient = new Patient();
            newPatient.PatientId = id;
            newPatient.Name = name;
            newPatient.PatientIssue = issue;
            newPatient.SeenDoctor = false;
            newPatient.DateRegistered = DateTime.Now;
            newPatient.Discharged = false;
            if(res == 1)
            {
                newPatient.PaitentTreatment = Treatment.Emergency;
            }
            if (res == 2)
            {
                newPatient.PaitentTreatment = Treatment.Operation;
            }
            if (res == 3)
            {
                newPatient.PaitentTreatment = Treatment.Specialist;
            }

            patientsList.Add(newPatient);
        }

        public static void DisplayAll()
        {
            Console.WriteLine("Total number of Patients in hospital: " + patientsList.Count);
            foreach (Patient item in patientsList)
            {
                if(item.Discharged == false)
                {
                    Console.WriteLine(item.PatientId);
                    Console.WriteLine(item.Name);
                    Console.WriteLine(item.PatientIssue);
                    Console.WriteLine(item.SeenDoctor);
                    Console.WriteLine(item.PaitentTreatment);
                    Console.WriteLine(item.DateRegistered);
                }

            }

            Console.WriteLine("Patients since 7 days");
            TimeSpan oneWeek = new TimeSpan(7,0,0,0);

            DateTime dt7Days = DateTime.Now.Subtract(oneWeek);

            foreach (Patient item in patientsList)
            {
                if(item.DateRegistered >= dt7Days)
                {
                    Console.WriteLine(item.PatientId);
                    Console.WriteLine(item.Name);
                    Console.WriteLine(item.PatientIssue);
                    Console.WriteLine(item.SeenDoctor);
                    Console.WriteLine(item.PaitentTreatment);
                    Console.WriteLine(item.DateRegistered);
                    Console.WriteLine(item.Discharged);
                }
            }
        }
    }
}
