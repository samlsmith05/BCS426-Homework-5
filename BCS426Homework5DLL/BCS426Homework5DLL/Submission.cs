//******************************************************
// File: Category.cs
//
// Purpose: Contains the class definition for Category.
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
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace BCS426Homework5DLL
{
    //****************************************************
    // Class: Submission{}
    //
    // Purpose: contains the properties and methods for the Submission class
    //          with serialization and deserialization code
    //
    // Update Information
    // ------------------
    //
    //
    //****************************************************

    [DataContract]
    public class Submission
    {
        #region Member Variables
        //Member Variables
        private string categoryName;
        private string assignmentName;
        private double grade;
        #endregion

        #region Submission Properties
        //properties for member variable categoryName
        [DataMember(Name = "categoryname")]
        public string CategoryName
        {
            get
            {
                return categoryName;
            }
            set
            {
                categoryName = value;
            }
        }

        //properties for member variable assignmentName
        [DataMember(Name = "assignmentname")]
        public string AssignmentName
        {
            get
            {
                return assignmentName;
            }
            set
            {
                assignmentName = value;
            }
        }

        //properties for member variable grade
        [DataMember(Name = "grade")]
        public double Grade
        {
            get
            {
                return grade;
            }
            set
            {
                grade = value;
            }
        }
        #endregion

        #region Submission Methods/Constructors
        //****************************************************
        // Method: Submission()
        //
        // Purpose: default constructor for Submission
        //
        //****************************************************
        public Submission()
        {
            categoryName = "No category";
            assignmentName = "No assignment";
            grade = 0.0;
        }

        //****************************************************
        // Method: ToString()
        //
        // Purpose: To show descriptive text and data for all member 
        //          variables by overriding ToString
        //****************************************************

        public override string ToString()
        {
            return categoryName + ", " + assignmentName + ", " + grade;

        }
        #endregion
    }
}

