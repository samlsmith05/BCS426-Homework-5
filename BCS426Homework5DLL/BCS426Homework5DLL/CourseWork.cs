//******************************************************
// File: CourseWork.cs
//
// Purpose: Contains the class definition for CourseWork
//          
//
// Written By: Samantha Smith 
//
// Compiler: Visual Studio 2019
//
//******************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BCS426Homework5DLL
{
    //****************************************************
    // Class: CourseWork{}
    //
    // Purpose: contains the properties and methods for the 
    //          CourseWork class with serialization and 
    //          deserialization code
    //
    // Update Information
    // ------------------
    // 
    //
    //****************************************************
    [DataContract]
    public class CourseWork
    {
        #region Member Variables
        //Member variables
        private string courseName;
        private List<Category> categories;
        private List<Assignment> assignments;
        private List<Submission> submissions;
        #endregion

        #region CourseWork Properties
        //properties for member variable courseName
        [DataMember(Name = "courseName")]
        public string CourseName
        {
            get
            {
                return courseName;
            }
            set
            {
                courseName = value;
            }
        }
        //properties for member variable categories
        [DataMember(Name = "categories")]
        public List<Category> Categories
        {
            get
            {
                return categories;
            }
            set
            {
                categories = value;
            }
        }
        //properties for member variable assignments
        [DataMember(Name = "assignments")]
        public List<Assignment> Assignments
        {
            get
            {
                return assignments;
            }
            set
            {
                assignments = value;
            }
        }
        //properties for member variable submissions
        [DataMember(Name = "submissions")]
        public List<Submission> Submissions
        {
            get
            {
                return submissions;
            }
            set
            {
                submissions = value;
            }
        }
        #endregion

        #region CourseWork Methods/Constructors
        //****************************************************
        // Method: CourseWork()
        //
        // Purpose: default constructor for CourseWork
        //
        //****************************************************
        public CourseWork()
        {
            //sets default values
            courseName = "No Name";
            categories = new List<Category>();
            assignments = new List<Assignment>();
            submissions = new List<Submission>();
        }
        //****************************************************
        // Method: Submission FindSubmission(String an)
        //
        // Purpose: loops through the submission list to find 
        //          the given submission and returns it if found
        //
        //****************************************************
        public Submission FindSubmission(string an)
        {
            //loops through the submissions list putting the current instance into sub
            foreach (Submission sub in submissions)
            {
                //if sub equals an, then we return the sub
                if (sub.AssignmentName.Equals(an) == true)
                {
                    //Console.WriteLine("The assignment you are searching for was found.");
                    return sub;
                }
            }
            //otherwise, we return null
            // Console.WriteLine("The assignment you are searching for is not in the list.");
            return null;
        }
        //****************************************************
        // Method: Category FindCategory(String cn)
        //
        // Purpose: loops through the submission list to find 
        //          the given category and returns it if found
        //
        //****************************************************
        public Category FindCategory(string cn)
        {
            //double weight;
            //loops through the categories list putting the current instance into cat
            foreach (Category cat in categories)
            {
                //if sub equals an, then we return the cat
                if (cat.Name.Equals(cn) == true)
                {
                    //weight = cat.Percentage;
                    return cat;
                }
            }
            //otherwise, we return null
            return null;
        }

        //****************************************************
        // Method: double SubmissionAverage(string cn)
        //
        // Purpose: loops through the submission list to find 
        //          the given submission and returns it if found
        //
        //****************************************************
        public double SubmissionAverage(string cn)
        {
            double sum = 0;
            double avg = 0;
            double count = 0;
            //loops through the submissions list putting the current instance into sub
            foreach (Submission sub in submissions)
            {
                //if sub's categoryName equals cn, then we return the sub
                if (sub.CategoryName.Equals(cn) == true)
                {
                    sum += sub.Grade;
                    count++;

                }
            }
            //calculates avg
            avg = sum / count;
            //returns the average
            return avg;
        }

        //****************************************************
        // Method: double CalculateGrade()
        //
        // Purpose: calculates the overall grade given the submissions
        //
        //****************************************************
        public double CalculateGrade()
        {
            double overall = 0;
            double examWeight = 0;
            double homeworkWeight = 0;
            double quizWeight = 0;
            double labWeight = 0;
            double examAvg = 0;
            double homeworkAvg = 0;
            double quizAvg = 0;
            double labAvg = 0;
            double examGrade;
            double homeworkGrade;
            double quizGrade;
            double labGrade;
            //loops through each instance in categories 
            foreach (Category cat in categories)
            {
                Category c = FindCategory(cat.Name);
                //if the name equals exams it gets that percentage
                if (c.Name.Equals("Exams"))
                {
                    examWeight = c.Percentage;
                    examAvg = SubmissionAverage(c.Name);
                }
                //if the name equals homework it gets that percentage
                else if (c.Name.Equals("Homework"))
                {
                    homeworkWeight = c.Percentage;
                    homeworkAvg = SubmissionAverage(c.Name);
                }
                //if the name equals quizzes it gets that percentage
                else if (c.Name.Equals("Quizzes"))
                {
                    quizWeight = c.Percentage;
                    quizAvg = SubmissionAverage(c.Name);
                }
                //if the name equals labs it gets that percentage
                else if (c.Name.Equals("Labs"))
                {
                    labWeight = c.Percentage;
                    labAvg = SubmissionAverage(c.Name);
                }
            }
            examGrade = examWeight * (examAvg / 100);
            homeworkGrade = homeworkWeight * (homeworkAvg / 100);
            quizGrade = quizWeight * (quizAvg / 100);
            labGrade = labWeight * (labAvg / 100);
            overall = examGrade + homeworkGrade + labGrade + quizGrade;

            overall = Math.Round(overall, 2);
            return overall;
        }
        //****************************************************
        // Method: ToString()
        //
        // Purpose: To show descriptive text and data for all member 
        //          variables by overriding ToString
        //****************************************************
        public override string ToString()
        {
            //creates a string to return
            string s = courseName + "\n";
            //loops through categories
            foreach (Category cat in categories)
            {
                //adds the current instance to s
                s += cat + "\n";
            }
            //loops through assignments
            foreach (Assignment assign in assignments)
            {
                //adds the current instance to s
                s += assign + "\n";
            }
            //loops through submissions
            foreach (Submission sub in submissions)
            {
                //adds the current instance to s
                s += sub + "\n";
            }
            s += "Overall grade: " + CalculateGrade() + "\n";
            return s;

        }

        #endregion
    }
}
