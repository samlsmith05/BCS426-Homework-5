//******************************************************
// File: CourseWorkUnitTesting.cs
//
// Purpose: Contains the class definition for CourseWorkUnitTesting
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

namespace BCS426Homework5DLL
{
    //****************************************************
    // Class: CourseWorkUnitTesting{}
    //
    // Purpose: contains the methods for the Unit Testing which
    //          will test the properties of the Category class and 
    //          Assignment class
    //
    // Update Information
    // ------------------
    // 
    //
    //****************************************************
    public class CourseWorkUnitTesting
    {
        #region CourseWorkUnitTesting Methods
        //****************************************************
        // Method: void UnitTestCategory()
        //
        // Purpose: this method performs Unit Testing on the properties
        //          of the Category class
        //
        //****************************************************

        public void UnitTestCategory()
        {
            Category testCat = new Category();  //instance of Category

            //test values
            string testName = "Samantha";
            double testPercent = 85.3;


            testCat.Name = testName;                  //sets the name of testCat
            testCat.Percentage = testPercent;         //sets the percentage for testCat

            System.Console.WriteLine("\n**********************");
            System.Console.WriteLine("Unit Testing: Category");
            System.Console.WriteLine("**********************");

            //tests the set property for Name of Category to see if if it is assigning values correctly
            //if it works correctly it will go into the if part of the if-else
            if (testCat.Name == testName)
            {
                System.Console.WriteLine("Category Name Property: PASS");
            }
            else
            {
                System.Console.WriteLine("Category Name Property: FAIL");
            }

            //tests the set property for Percentage of Category to see if if it is assigning values correctly
            //if it works correctly it will go into the if part of the if-else
            if (testCat.Percentage == testPercent)
            {
                System.Console.WriteLine("Category Percentage Property: PASS");
            }
            else
            {
                System.Console.WriteLine("Category Percentage Property: FAIL");
            }


        }


        //****************************************************
        // Method: void UnitTestAssignment()
        //
        // Purpose: this method performs unit testing on the 
        //          properties of the Assignment class
        //****************************************************

        public void UnitTestAssignment()
        {
            Assignment testAssign = new Assignment();       //creates an instance of Assignment

            //test values
            string testName = "Samantha";
            string testDescrip = "Nothing";
            string testCatName = "No category";

            testAssign.Name = testName;             //sets testAssign name
            testAssign.Description = testDescrip;   //sets testAssign description
            testAssign.CategoryName = testCatName;  //sets testAssign category name

            System.Console.WriteLine("\n************************");
            System.Console.WriteLine("Unit Testing: Assignment");
            System.Console.WriteLine("************************");

            //tests the set property for Name of Assignment to see if if it is assigning values correctly
            //if it works correctly it will go into the if part of the if-else
            if (testAssign.Name == testName)
            {
                System.Console.WriteLine("Assignment Name Property: PASS");
            }
            else
            {
                System.Console.WriteLine("Assignment Name Property: FAIL");
            }

            //tests the set property for Description of Assignment to see if if it is assigning values correctly
            //if it works correctly it will go into the if part of the if-else
            if (testAssign.Description == testDescrip)
            {
                System.Console.WriteLine("Assignment Description Property: PASS");
            }
            else
            {
                System.Console.WriteLine("Assignment Description Property: FAIL");
            }

            //tests the set property for CategoryName of Assignment to see if if it is assigning values correctly
            //if it works correctly it will go into the if part of the if-else
            if (testAssign.CategoryName == testCatName)
            {
                System.Console.WriteLine("Assignment CategoryName Property: PASS");
            }
            else
            {
                System.Console.WriteLine("Assignment CategoryName Property: FAIL");
            }

        }

        #endregion
    }
}