//******************************************************
// File: Assignment.cs
//
// Purpose: Contains the class definition for Assignment
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
    // Class: Assignment{}
    //
    // Purpose: contains the properties and methods for the Assignment class
    //
    // Update Information
    // ------------------
    // Name: Samantha Smith
    // Date: 9/27/19
    // Description: Added serialization and deserialization code
    //              to the class
    //
    //****************************************************

    //SS 9/27/19 - Added DataContract
    [DataContract]
    public class Assignment
    {
        #region Member Variables
        //Member variables
        private string name;
        private string description;
        private string categoryName;

        #endregion

        #region Assignment Properties
        //properties for member variable name
        //SS 9/27/19 - made name a datamember
        [DataMember(Name = "name")]
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        //properties for member variable description
        //SS 9/27/19 - made description a datamember
        [DataMember(Name = "description")]
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }

        //properties for member variable categoryName
        //SS 9/27/19 - made categoryName a datamember
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

        #endregion

        #region Assignment Methods/Constructors
        //****************************************************
        // Method: Assignment()
        //
        // Purpose: default constructor for Assignment
        //
        //****************************************************

        public Assignment()
        {
            name = "No name";
            description = "No description";
            categoryName = "No category";
        }


        //****************************************************
        // Method: ToString()
        //
        // Purpose: To show descriptive text and data for all member 
        //          variables by overriding ToString
        //****************************************************

        public override string ToString()
        {
            return name + ", " + description + ", " + categoryName;
        }

        #endregion
    }
}
