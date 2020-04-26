//****************************************************
// File: main.cs
//
// Purpose: Utilize the dynamic link library and the 
//          serialization and deserialization code
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.IO;
using BCS426Homework3DLL;

namespace BCS426Homework3
{
    //****************************************************
    // Class: main{}
    //
    // Purpose: entry point for the program
    //
    // Update Information
    // ------------------
    // 
    //
    //****************************************************
    class main
    {
        static void Main(string[] args)
        {
            #region Class Instances
            CourseWork cw = new CourseWork();
            #endregion
          
            //Variables
            string userInput;
            int intUserInput;

            //loops until the user inputs a 16
            do
            {
                //Menu
                System.Console.WriteLine("CourseWork Menu");
                System.Console.WriteLine("---------------");
                System.Console.WriteLine("1 - Read course work from JSON file");
                System.Console.WriteLine("2 - Read course work from XML file");
                System.Console.WriteLine("3 - Write course work to JSON file");
                System.Console.WriteLine("4 - Write course work to XML file");
                System.Console.WriteLine("5 - Display all course work on screen");
                System.Console.WriteLine("6 - Find submission");
                System.Console.WriteLine("7 - Exit");
                System.Console.Write("Enter Choice: ");

                userInput = System.Console.ReadLine();      //reads the userInput in string
                intUserInput = Convert.ToInt32(userInput);  //converts the userInput to an int

                if (intUserInput == 1)      //goes into this option if the user entered 1
                {
                    string fileName;
                    System.Console.WriteLine("Please enter a filename:");
                    fileName = System.Console.ReadLine();           //gets the file name

                    FileStream reader = new FileStream(fileName, FileMode.Open, FileAccess.Read);   //opens the FileStream to read the JSON from 

                    DataContractJsonSerializer serializer;          //creates an instance of DataContractJsonSerializer          
                    serializer = new DataContractJsonSerializer(typeof(CourseWork));

                    cw = (CourseWork)serializer.ReadObject(reader);    //reads from the file

                    reader.Close();                                 //closes the file
                }
                else if (intUserInput == 2)     //goes into this option if the user entered 2
                {
                    string fileName;
                    System.Console.WriteLine("Please enter a filename:");
                    fileName = System.Console.ReadLine();   //gets the file name

                    FileStream reader = new FileStream(fileName, FileMode.Open, FileAccess.Read);   //opens the FileStream to read the XML from 

                    DataContractSerializer serializer;     //creates an instance of DataContractSerializer
                    serializer = new DataContractSerializer(typeof(CourseWork));

                    cw = (CourseWork)serializer.ReadObject(reader);   //reads from the file
                    reader.Close();                                     //closes the file
                }
                else if (intUserInput == 3)    //goes into this option if the user entered 3
                {
                    string fileName;
                    System.Console.WriteLine("Please enter a filename: ");
                    fileName = System.Console.ReadLine();   //gets the file name

                    FileStream writer = new FileStream(fileName, FileMode.Create, FileAccess.Write);    //creates the file to write the JSON to

                    DataContractJsonSerializer serializer;      //creates a DataContractJsonSerializer instance for CourseWork
                    serializer = new DataContractJsonSerializer(typeof(CourseWork));  //specify the type to serialize

                    serializer.WriteObject(writer, cw);      //writes to the file
                    writer.Close();                         //closes the file
                }
                else if (intUserInput == 4)
                {
                    string fileName;
                    System.Console.WriteLine("Please enter a filename:");
                    fileName = System.Console.ReadLine();   //gets the file name


                    FileStream writer = new FileStream(fileName, FileMode.Create, FileAccess.Write);   //creates the file to write the XML to

                    DataContractSerializer serializer;      //creates a DataContractSerializer instance for CourseWork
                    serializer = new DataContractSerializer(typeof(CourseWork));      //specifies the type to serialize

                    serializer.WriteObject(writer, cw);      //writes to the file
                    writer.Close();                         //closes the file
                }
                else if (intUserInput == 5)     //goes into this option if the user enters 5
                {
                    System.Console.WriteLine(cw);       //uses the ToString method to display the data for CourseWork
                }
                else if (intUserInput == 6)     //goes into this option if the user enters 6
                {
                    string assignName;
                    System.Console.WriteLine("Please enter an assignment name:");
                    assignName = System.Console.ReadLine();   //gets the file name  
                    //populates sub from FindSubmission
                    Submission sub = cw.FindSubmission(assignName);

                    //if it's not null it will print out the result
                    if(sub != null)
                    {
                        Console.WriteLine(sub);
                    }
                }
                else if (intUserInput != 7)    
                {
                    System.Console.WriteLine("Invalid input");  //prints if the user inputed anything besides 1, 2, ... , 7
                }
                System.Console.WriteLine();
            } while (intUserInput != 7);
        }
    }
}
