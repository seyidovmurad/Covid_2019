using System;
using System.Collections.Generic;
using System.Text;

namespace Covid_2019
{
    class Person
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public string Surname { get; set; }

        public string PassportID { get; set; }

        public int Age { get; set; }

        public Person() 
        {
            Age = 18;
            Name = "unknown";
            Surname = "unknown";
            PassportID = "uknown";
        }
        public Person(int age,string name,string surname,string passportID)
        {
            Age = age;
            Name = name;
            Surname = surname;
            PassportID = passportID;
        }
    }
}
