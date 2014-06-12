using System; //Libraries
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentClassHW
{
    class Program //Class Program
    {
        static void Main(string[] args) //Arguments
        {
            List<Student> stList = new List<Student> { //Using list intead of plain fix array
                new Student("Arvin", "Oprasic", "anoc1524@aubih.edu.ba"), //New Student , Name LastName Email
                new Student("Benjamin", "Kukuljac", "bnkc1533@aubih.edu.ba"),
                new Student("Semir", "Masic", "srmc1643@aubih.edu.ba"),
                new Student("Ela", "Alihodzic", "eaac1579@aubih.edu.ba"),
                new Student("Kerim", "Krdzevic", "kmkc1468@aubih.edu.ba"),
                new Student("Haris", "Memovic", "hsmc1457@aubih.edu.ba"),
                new Student("Eldin", "Kasapovic", "enkc1472@aubih.edu.ba"),
                new Student("Adnan", "Rahic", "anrc1573@aubih.edu.ba"),
                new Student("Denis", "Korjenic", "dskc1852@aubih.edu.ba"),
                new Student("Lejla", "Memic", "lamc1671@aubih.edu.ba"),
            };

            stList.Sort(); //Sorting list
            stList.ForEach(student => Console.WriteLine(student)); //It writes every student from the list

            Console.WriteLine("Press Enter to Exit..."); //Display line to press Enter to Exit from program
            Console.ReadLine(); //Reading the input text
        }
    }

    class Person //Class Person
    {
        protected string name, lastName; //protected class for student name and lastName
        
        protected Person(string name, string lastName)
        {
            this.name = name;
            this.lastName = lastName;
        }

        protected string getPersonInfo()
        {
            return name + ", " + lastName; // It returns to name and lastName with ","
        }
    }
    
    class Student : Person, IComparable<Student> //Class Student with comparing students
    {
        public string email {get; set;} //Geters and Seters
        private string Location;
        public string location
        {
            get //recieving Student Location
            {
                if (Location == "SA")
                {
                    return "Sarajevo";
                }
                else if (Location == "TZ")
                {
                    return "Tuzla";
                }
                else
                {
                    return "AUBiH Student";
                }
            }
            set
            {
                if (value == "SA" || value == "SARAJEVO" || value == "Sarajevo")
                {
                    Location = "Sarajevo";
                }
                else if (value == "TZ" || value == "TUZLA" || value == "Tuzla")
                {
                    Location = "Tuzla";
                }
                else //If we do not recieve Student Location it will be NA
                {
                    Location = "NA";
                }
            }
        }

        public Student() : base("Arvin", "Oprasic") //The default base is Arvin Oprasic Student Name and LastName
        {
            this.email = "anoc1524@aubih.edu.ba"; //Email
            this.location = "Sarajevo"; //Location
        }

        ~Student() {

        }

        public Student(string name, string lastname, string email) //Sudent constructor that takes three arguments 
            : base(name, lastname) //Base of two arguments name and lastName
        {
            this.email = email; //Email based project
            this.location = "Sarajevo"; //Location of student
        }

        public bool setName(string input)
        {
            if (input.Length <= 2) //Checking if name has more than two caracters
            {
                Console.WriteLine("You must type at least two caracters"); //Noticing us that we have to type in more than two caracters
                return false;
            }

            char[] cArray = input.ToCharArray(); //We have to type only letters
            foreach(char c in cArray) {
                if(!char.IsLetter(c)) {
                    Console.WriteLine("Please type only letters"); //Noticing us that we have to input only caracters
                return false;
                }
            }

            if (char.IsUpper(cArray[0])) //We have to input first letter as uppercase
            {
                Console.WriteLine("Please type first uppercase letter"); //Noticing us that we have to input first letter as uppercase one
                return false;
            }

            return true;
        }
        
        public string getStudentInfo() //Public string of student informations
        {
            return base.getPersonInfo() + ", " + this.email + ", " + this.location; //Collecting Student info like name lastName email and location
        }

        public override string ToString() //Override ToString() method to return Student info (return same value as getStudentInfo)

        {
            return getStudentInfo();
        }

        public int CompareTo(Student student); //Second part of  Implement IComparable so Students can be sorted by location in following order AUBiHStudent, Sarajevo, Tuzla
        {
            return this.email.CompareTo(student.email); //Return to student info and email of the same one
        }
    }
}
