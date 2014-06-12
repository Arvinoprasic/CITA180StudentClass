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
            List<Student> stList = new List<Student> { //Student list instead of plain fixed array
                new Student("Arvin", "Oprasic", "anoc1524@aubih.edu.ba"), //Student new with name lastName and email
                new Student("Benjamin", "Loncarevic", "bnlc1456@aubih.edu.ba"),
                new Student("Benjamin", "Kukuljac", "bnkc1754@aubih.edu.ba"),
                new Student("Nedim", "Kulasin", "nmkn1472@aubih.edu.ba"),
                new Student("Ela", "Alihodzic", "eaac1426@aubih.edu.ba"),
                new Student("Adnan", "Rahic", "anrc1726@aubih.edu.ba"),
                new Student("Kerim", "Krdzevic", "kmkc1754@aubih.edu.ba"),
                new Student("Eldin", "Kasapovic", "enkc1554@aubih.edu.ba"),
                new Student("Lejla", "Memic", "lamc1471@aubih.edu.ba"),
                new Student("Denis", "Korjenic", "dskc1942@aubih.edu.ba"),
            };

            stList.Sort(); //Sorting Students by alphabet
            stList.ForEach(student => Console.WriteLine(student)); //Write every student in list after sorting

            Console.WriteLine("Please press Enter to Exit..."); //User have to press Enter to Exit the program
            Console.ReadLine(); //Reading line
        }
    }

    class Person //Class Person
    {
        protected string name, lastName; //Protected strings name and lastName

        protected Person(string name, string lastName)
        {
            this.name = name;
            this.lastName = lastName;
        }

        protected string getPersonInfo() //Geting person student informations name and lastname
        {
            return name + ", " + lastName; //Student name and lastName with ,
        }
    }
    
    class Student : Person, IComparable<Student> //Class Student with comparing
    {
        public string email {get; set;} //Geting and Seting informations of student
        private string Location; //Location of student
        public string location
        {
            get //Getting info is student from SA or TZ
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
                    return "AUBIH"; //If we do not know from where is student we will se just AUBIH
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
                else
                {
                    Location = "NA"; //If we do not know it will display NA
                }
            }
        }

        public Student() : base("Arvin", "Oprasic")
        {
            this.email = "anoc1524@aubih.edu.ba";
            this.location = "Sarajevo";
        }

        ~Student() {

        }

        public Student(string name, string lastname, string email) // Student constructor that takes in 3 string arguments name, lastName, email
            : base(name, lastname)
        {
            this.email = email;
            this.location = "Sarajevo";
        }

        public bool setName(string input) //Bool for input informations
        {
            if (input.Length <= 2) //Input must be two or more letters
            {
                Console.WriteLine("Please enter more ,name must be at least two characters long"); //Display line
                return false;
            }

            char[] cArray = input.ToCharArray(); //Name hase to have only letters
            foreach(char c in cArray) {
                if(!char.IsLetter(c)) {
                    Console.WriteLine("Please do not enter numbers and symbols, name can only have letters"); //Display line
                return false;
                }
            }

            if (char.IsUpper(cArray[0])) //Start name with uppercase
            {
                Console.WriteLine("Please enter first letter as uppercase, name must start with an uppercase letter");
                return false;
            }

            return true;
        }
        
        public string getStudentInfo() //Collecting students informations
        {
            return base.getPersonInfo() + ", " + this.email + ", " + this.location; //Geting person info emil and location
        }

        public override string ToString() //Override ToString() method to return Student info (return same value as getStudentInfo)
        {
            return getStudentInfo(); //return same value as getStudentInfo
        }

        public int CompareTo(Student student) //Comparing to student
        {
            return this.email.CompareTo(student.email); //Compare student email
        }
    }
}
