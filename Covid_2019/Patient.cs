using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Covid_2019
{
    class Patient : Person
    {
        public DateTime FirstVaccine { get; set; }
        public DateTime SecondVaccine { get; set; }

        public bool isFirstVaccineActive { get; set; }
        public bool isSecondVaccineActive { get; set; }
        public void GetVaccinated(DateTime dateOfToday)
        {
            if (FirstVaccine.Date.AddDays(32) < dateOfToday.Date)
                isFirstVaccineActive = false;
            if (!isFirstVaccineActive)
            {
                FirstVaccine = dateOfToday;
                isFirstVaccineActive = true;
            }
            else
            {
                if (FirstVaccine.Date.AddDays(28) <= dateOfToday.Date && FirstVaccine.Date.AddDays(32) > dateOfToday.Date)
                {
                    SecondVaccine = dateOfToday;
                    isSecondVaccineActive = true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("You have to wait 28 day after first vaccine.");
                    Thread.Sleep(2000);
                }
            }

        }

        private string VaccineString()
        {
            string temp;
            temp = "Vaccine: ";
            if (!isFirstVaccineActive)
                temp += "-";
            else
            {
                temp += "\nFirst Vaccine: ";
                temp += FirstVaccine.ToShortDateString();
                temp += "\nSecond Vaccine: ";
                if (!isSecondVaccineActive)
                    temp += "-";
                else
                    temp += SecondVaccine.ToShortDateString();

            }
            return temp;
        }
        public Patient(int age, string name, string surname,string passportID): base( age, name, surname,passportID) {
            isFirstVaccineActive = false;
            isSecondVaccineActive = false;
        }

        public Patient() : base() { }

        public override string ToString()
        {
            return $@"Name: {Name}
Surname: {Surname}
Age: {Age}
Passport ID: {PassportID}
ID: {ID}
{VaccineString()}
";
        }
    }
}
