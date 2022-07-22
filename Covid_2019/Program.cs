using System;
using System.Collections.Generic;
using System.Threading;
using Menu;

namespace Covid_2019
{
    class Program
    {
        static void Main(string[] args)
        {

            Hospital hospital = new Hospital() { HospitalName = "Good Hospital" };
            DateTime dateOfToday= DateTime.Now;
            AddPatients(hospital);
            int index = -1;
            int id = -1;
            while (true)
            {
                Console.Clear();
                if (index == -1)
                {
                    index = SelectingMenu.choose(hospital.HospitalName + "\n" + dateOfToday.ToShortDateString(), new string[] { "Show Patients", "Register","End Day", "End Week", "Exit" });
                }
                else if (index == 0)//Show Patient
                {
                    if (id == -1)
                    {
                        string[] patientString = new string[hospital.Patients.Count + 1];
                        int i = 0;
                        foreach (var patient in hospital.Patients)
                        {
                            patientString[i] = patient.Name + " " + patient.Surname;
                            i++;
                        }
                        patientString[i] = "Back";
                        id = SelectingMenu.choose(patientString);
                    }
                    if (id == hospital.Patients.Count)
                    {
                        index = -1;
                        id = -1;
                    }
                    else
                    {
                        int index2 = SelectingMenu.choose(hospital.GetPatientByID(id).ToString(), new string[] { "Get Vaccine", "Delete Patient", "Back" });
                        if (index2 == 0)//Get Vaccine
                        {
                            if (!hospital.GetPatientByID(id).isSecondVaccineActive)
                                hospital.GetVaccineByID(id, dateOfToday);
                        }
                        else if (index2 == 1) //Delete 
                        { 
                            hospital.DeleteByID(id); 
                            id = -1; 
                        }
                        else if (index2 == 2) { id = -1; } //Back
                    }

                }
                else if (index == 1) //Add Patient
                {
                    Patient patient = new Patient();
                    Console.Write("Name: ");
                    patient.Name = Console.ReadLine();
                    Console.Write("Surname: ");
                    patient.Surname = Console.ReadLine();
                    Console.Write("Age: ");
                    int age;
                    int.TryParse(Console.ReadLine(), out age);
                    patient.Age = age;
                    Console.Write("Passport ID: ");
                    patient.PassportID = Console.ReadLine();
                    hospital.Register(patient);
                    index = -1;
                }
                else if (index == 2) //End Day
                { 
                    dateOfToday = dateOfToday.AddDays(1);
                    index = -1;
                }
                else if (index == 3) //End Week
                {
                    dateOfToday = dateOfToday.AddDays(7);
                    index = -1;
                }
                else if (index == 4) { return; }//Exit
            }
        }

        static void AddPatients(Hospital hospital)
        {
            List<Patient> patients = new List<Patient>
            {
                new Patient(22,"Maureen", "Gregg","1Z 302 V32"),
                new Patient(54,"Troy", "Stephens","1Z E57 88E"),
                new Patient(37,"Cora", "Manning","1Z 072 563"),
                new Patient(25,"John", "Green","1Z 039 648"),
                new Patient(42,"Thomas", "Colvin","1Z 112 V17"),
                new Patient(35,"Rosemary", "Sherman","1Z 5W3 6E5"),
                new Patient(57,"Laura", "Smith","1Z 253 7Y2")
            };
            foreach (var patient in patients)
            {
                hospital.Register(patient);
            }
        }
    }
}
