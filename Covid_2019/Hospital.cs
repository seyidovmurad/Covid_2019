using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Covid_2019
{
    class Hospital
    {
        public List<Patient> Patients { get; private set; }

        public string HospitalName { get; set; }

        public void Register(Patient patient)
        {
            if (Patients.Count == 0)
                patient.ID = 0;
            else
                patient.ID = Patients.Last().ID + 1;
            Patients.Add(patient);
        }

        public Patient GetPatientByID(int id)
        {
            return Patients.Find(p => p.ID == id);
        }

        public void DeleteByID(int id)
        {
            Patients.ForEach(p =>
            {
                if (p.ID > id)
                {
                    p.ID--;
                }
            });
            Patients.Remove(GetPatientByID(id));
        }

        public void GetVaccineByID(int id,DateTime time)
        {
            GetPatientByID(id).GetVaccinated(time);
            if (GetPatientByID(id).isSecondVaccineActive)
            {
                Console.Clear();
                Console.WriteLine("Congratulations! You got both vaccine");
                Thread.Sleep(1000);
            }
                
        }

        public Hospital()
        {
            Patients = new List<Patient>();
        }
    }
}
