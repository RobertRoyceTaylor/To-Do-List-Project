using System;
using System.Collections.Generic;
using System.IO;

namespace ToDoListProject
{
    
    internal class Program
    {
        //To Do Tomorrow::
        //Figure out how to either impliment classes to count the entries
        //Use Regex to grab the line number
        //Figure out marking as complete
        //Figure out deleting

        static void Main(string[] args)
        {
            //The path the file is in (change for release)
            string path = @"list.txt";
            //Creates the list that stores the tasks
            List<string> toDoList = new List<string>();
            //Creates the list to store the completed tasks
            List<string> toDoListComplete = new List<string>();

            //Stores previous lines within todo list upon opening
            string[] readFile = File.ReadAllLines(path);
            
            //AddRange in to replace a foreach loop (Khalil taught me)
            toDoList.AddRange(readFile);
            
            ForEachView(toDoList);

            //While loop to write to the file
            while (true)
            {
                //Takes the user input method and stores it in a string
                string input = UserInput();
                //If the conditions are met, will exit out of the program
                if(input == "#Done" || input == "#D")
                {
                    break;
                }
                else
                {
                    //Adds the user input to the list
                    toDoList.Add(input);
                    Console.Clear();
                    //Displays the list then starts the loop over just displaying the list
                    ForEachView(toDoList);
                }
            }
            Console.Clear();
            ForEachView(toDoList);

            File.WriteAllLines(path, toDoList);
        }

        //Takes the user input for the tasks on the list
        private static string UserInput()
        {
            Console.WriteLine("===================");
            Console.WriteLine("----Add to List----");
            Console.WriteLine("===================");
            Console.WriteLine("Type #Done to Finsh");
            Console.WriteLine("Type #Check to Check Off Item");
            Console.WriteLine("===================");
            //More Instructions needed
            string input = Console.ReadLine();
            return input;

        }

        //Displays the list itself using a foreach loop
        private static void ForEachView(List<string> lines)
        {
            foreach(string line in lines)
            {
                //prints the index a check box and the line
                Console.WriteLine($"{lines.IndexOf(line) + 1}[] - {line}");
            }
        }

    }
}
