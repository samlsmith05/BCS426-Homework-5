//****************************************************
// File: MainWindow.xaml.cs
//
// Purpose: Utilize the dynamic link library and the WPF 
//          to interact with users
//
// Written By: Samantha Smith
//
// Compiler: Visual Studio 2019
// 
// Update Information
// ------------------
//
// 
//****************************************************
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BCS426Homework5DLL;
using Microsoft.Win32;

namespace BCS426Homework5WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //connection string to database
        string connString = @"server=(LocalDB)\MSSQLLocalDB;" +
            "integrated security=SSPI;" +
            "database=CourseWork";
        public MainWindow()
        {
            InitializeComponent();
        }
        //****************************************************
        // Method: void Window_Loaded(object sender, RoutedEventArgs e)
        //
        // Purpose: loads the listBox upon the window opening
        //
        //****************************************************
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //calls LoadData
            LoadDataFromDB();
        }

        //****************************************************
        // Method: void LoadDataFromDB
        //
        // Purpose: loads the listBox with the data from the database
        //
        //****************************************************
        private void LoadDataFromDB()
        {
           //creates a new connection
            SqlConnection sqlConn;
            sqlConn = new SqlConnection(connString);

            sqlConn.Open(); // Open the connection

            string sql = "SELECT * FROM Submissions";
            SqlCommand command = new SqlCommand(sql, sqlConn);

            // Retrieve the data from the database
            SqlDataReader reader = command.ExecuteReader();
            
            //gets the number of columns in the database table
            int fieldCount = reader.FieldCount;

            //loops through while there are still rows in the database
            while (reader.Read())
            {
                //loops through to get the assignment name of each row
                for (int i = 0; i < fieldCount; i = i+3)
                {
                    //adds the assignment name to the list box
                    listBoxSubmission.Items.Add(reader["AssignmentName"]);
                }
            }

        }
        //****************************************************
        // Method: void ListBoxSubmission_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //
        // Purpose: populates the information for the newly selected submission
        //
        //****************************************************
        private void ListBoxSubmission_SelectionChanged(object sender, SelectionChangedEventArgs e)
        { 
            if (listBoxSubmission.Items.Count > 0) { 
            //saves the string of the assignment name of the newly selected submission
            string s = (string) e.AddedItems[0];

            ShowDetails(s);     //calls ShowDetails(string)
            }
        }
        //****************************************************
        // Method: void ShowDetails(string s)
        //
        // Purpose: prints the details for each submission into the 
        //          text boxes
        //
        //****************************************************
        private void ShowDetails(string s)
        {
            //creates the connection
            SqlConnection sqlConn;
            sqlConn = new SqlConnection(connString);

            sqlConn.Open(); // Open the connection

            string sql = "SELECT * FROM Submissions";
            SqlCommand command = new SqlCommand(sql, sqlConn);

            // Retrieve the data from the database
            SqlDataReader reader = command.ExecuteReader();

            //loops through while there are still rows to read
            while (reader.Read())
            {
                //gets the info for that row
                string assign = reader.GetString(0);
                string cat = reader.GetString(1);
                double x = reader.GetDouble(2);
                string grade = x.ToString();
                //sees if the assignment name is a match to the one that the user selected
                bool result = s.Equals(assign);
                //goes into if they are equal
                if (result == true)
                {
                    //fills in the textboxes
                    textBoxAssignmentName.Text = assign;
                    textBoxCategoryName.Text = cat;
                    textBoxGrade.Text = grade;
                    return;
                }

            }
        }
        //****************************************************
        // Method: void MenuItemExit_Click(object sender, RoutedEventArgs e)
        //
        // Purpose: exits the application
        //
        //****************************************************
        private void MenuItemExit_Click(object sender, RoutedEventArgs e)
        {
            window.Close();     //closes the window
        }
        //****************************************************
        // Method: void MenuItemAbout_Click(object sender, RoutedEventArgs e)
        //
        // Purpose: brings up a message box with information about the program
        //
        //****************************************************
        private void MenuItemAbout_Click(object sender, RoutedEventArgs e)
        {
            //prints the message into the messageBox
            MessageBox.Show("Course Work GUI\nVersion 1.0\nWritten by Samantha Smith\n", "About Course Work GUI");
            
        }
        //****************************************************
        // Method: void MenuItemImport_Click(object sender, RoutedEventArgs e)
        //
        // Purpose: imports the data from the file into the cleared database
        //
        //****************************************************
        private void MenuItemImport_Click(object sender, RoutedEventArgs e)
        {
            //creates a course work instance
            BCS426Homework5DLL.CourseWork cw = new BCS426Homework5DLL.CourseWork();
       
            //opens the file dialog box
            OpenFileDialog openFileDialog = new OpenFileDialog();
            //filters the files to only show json files
            openFileDialog.Filter = "JSON files (*.json)|*.json";
            //openFileDialog.InitialDirectory = @"C:\Users\Samantha\Documents\Fall 2019\BCS426\BCS426Homework4WPF\BCS426Homework4WPF\bin\Debug";
            //sets the intital directory to the current working directory
            openFileDialog.InitialDirectory = @System.IO.Directory.GetCurrentDirectory();
            //changes the title of the dialog box
            openFileDialog.Title = "Open Course Work From JSON";
            
            if (openFileDialog.ShowDialog() == true)
            {
                //clears the text boxes
                textBoxAssignmentName.Clear();
                textBoxCategoryName.Clear();
                textBoxGrade.Clear();
                //clears the database
                ClearDB();
                listBoxSubmission.Items.Clear();

                //gets the filename wanted
                string filename = openFileDialog.FileName;
                //reads from the file selected into the coursework instance
                cw = ReadFromFile(filename);
                
                //loops through all the submissions and adds to the database table
                foreach (BCS426Homework5DLL.Submission sub in cw.Submissions)
                {
                    //adds the submission to the database
                    AddSubToDB(sub);
                }
                //loads the data to the listbox 
                LoadDataFromDB();
                
            }            
            
        
        }

        //****************************************************
        // Method: BCS426Homework5DLL.CourseWork ReadFromFile(string filename)
        //
        // Purpose: read from the file using serialization
        //
        //****************************************************
        private BCS426Homework5DLL.CourseWork ReadFromFile(string filename)
        { 
            //creates a course work instance
            BCS426Homework5DLL.CourseWork cw = new BCS426Homework5DLL.CourseWork();

            FileStream reader = new FileStream(filename, FileMode.Open, FileAccess.Read);   //opens the FileStream to read the JSON from 

            DataContractJsonSerializer serializer;          //creates an instance of DataContractJsonSerializer          
            serializer = new DataContractJsonSerializer(typeof(BCS426Homework5DLL.CourseWork));

            cw = (BCS426Homework5DLL.CourseWork)serializer.ReadObject(reader);    //reads from the file
            reader.Close();                              //closes the file
            return cw;                                  //returns the coursework instance

            
        }

        //****************************************************
        // Method: void ClearDB()
        //
        // Purpose: clears the database table
        //
        //****************************************************
        private void ClearDB()
        {
            // Setup the SQL command
            string sql = "DELETE FROM Submissions";

            //opens and creates the connection
            SqlConnection sqlConn;
            sqlConn = new SqlConnection(connString);
            sqlConn.Open();

            //deletes all the rows
            SqlCommand command = new SqlCommand(sql, sqlConn);
            int rowsAffected = command.ExecuteNonQuery();
        }
        //****************************************************
        // Method: void AddSubToDB
        //
        // Purpose: adds a submission to the table
        //
        //****************************************************
        private void AddSubToDB(Submission s)
        { 
            //creates and opens the connection                
            SqlConnection sqlConn;
            sqlConn = new SqlConnection(connString);
            sqlConn.Open();
            string sql = "INSERT INTO Submissions" +
            "(AssignmentName, CategoryName, Grade) Values" +
            "(@param1, @param2, @param3)";

            //inserts into the table using the submission passed in
            SqlCommand command = new SqlCommand(sql, sqlConn);
            command.Parameters.Add(new SqlParameter("@param1", s.AssignmentName));
            command.Parameters.Add(new SqlParameter("@param2", s.CategoryName));
            command.Parameters.Add(new SqlParameter("@param3", s.Grade));
            
            int rowsAffected = command.ExecuteNonQuery();
        }

    }
}
