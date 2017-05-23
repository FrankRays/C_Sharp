using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students
{
    

    class Student
    {
        // Variable declarations
        private int    studentId;
        private int    age;
        private double gpa;

        // Automatic Properties
        public  string             FirstName      { get; set; }
        public  string             LastName       { get; set; }
        public  ClassificationType Classification { get; set; }
      
        // Enumerations
        public enum ClassificationType { Freshman, Sophomore, Junior, Senior, Graduate, Other };
       
      

        #region Constructors
        public Student()
        {

        }
        #endregion

        #region Public Accessors
        public int StudentId
        {
            get
            {
                return studentId;
            }
        }

        public int Age
        {
            get
            {
                return age;
            }

            set
            {
                if (value < 16)
                    throw new ArgumentOutOfRangeException("", "Student must at least be 16 years of age");
                else
                {
                    age = value;
                }
            }
        }

        public double GPA
        {
            get
            {
                return gpa;
            }

            set
            {
                if (value > 4.0 || value < 0.0)
                    throw new ArgumentOutOfRangeException("", "Invalid GPA - Must be within 0.0 to 4.0");
                else
                    gpa = value;
            }
        }
        #endregion

        #region Public methods
        public string getStudentName()
        {
            return LastName + ", " + FirstName;
        }

        public bool isOnProbation()
        {
            bool answer = false;

            if (GPA < 2.0)
                answer = true;

            return answer;
        }
        #endregion

        public override string ToString()
        {
            string information = $"{LastName}, {FirstName}. [{StudentId}] ({Classification}) \n\n -{GPA}";

            if (isOnProbation())
                information += " *Probation";

            return information;
        }

    }
}
