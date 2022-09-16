using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace ToDoListProject
{
    
    internal class Program
    {
        //To Do:
        //Figure out deleting
        //Create files for saving if files are not present


        static void Main(string[] args)
        {
            
            

            #region
            //The paths the files are in
            string path = @"list.txt";
            string pathComplete = @"list-complete.txt";

            //Lists that store the tasks
            List<string> toDoList = new List<string>();
            List<string> toDoListComplete = new List<string>();

            //Stores previous lines within to-do list upon opening
            string[] readFile = File.ReadAllLines(path);
            string[] readFileComplete = File.ReadAllLines(pathComplete);
            
            //AddRange in to replace a foreach loop (Khalil taught me)
            toDoList.AddRange(readFile);
            toDoListComplete.AddRange(readFileComplete);
            #endregion


            //While loop to write to the file
            while (true)
            {
                //Displays the Graphics
                Console.Clear();
                Console.WriteLine("----- ToDo List -----");
                ForEachView(toDoList);
                Console.WriteLine("----- Completed -----");
                ForEachViewComplete(toDoListComplete);

                //Takes the user input method and stores it in a string
                string input = UserInput();
                
                //If the conditions are met, will exit out of the program
                if (input.ToLower() == "#save" || input == "#s")
                {
                    break;
                }
                else if (input.ToLower() == "#check" || input == "#c")
                {
                    MarkTaskComplete(toDoList,toDoListComplete); 
                }
                else
                {
                    //Adds the user input to the list
                    toDoList.Add(input);
                }
            }
            //Exiting the Program
            Console.Clear();
            Console.WriteLine("----- ToDo List -----");
            ForEachView(toDoList);
            Console.WriteLine("----- Completed -----");
            ForEachViewComplete(toDoListComplete);
            Console.WriteLine("======================");
            Console.WriteLine("Files saved. \nPress any key to quit...");
            Console.Read();
            //Saves the lists to the files
            File.WriteAllLines(path, toDoList);
            File.WriteAllLines(pathComplete, toDoListComplete);
        }



        //Takes the user input for the tasks on the list
        private static string UserInput()
        {
            //Displays instructions
            Console.WriteLine("=======================");
            Console.WriteLine("----- Add to List -----");
            Console.WriteLine("=======================");
            Console.WriteLine("- Type #Save to Save -");
            Console.WriteLine("Type #Check to Check Off Item");
            Console.WriteLine("=======================");
            Console.Write("> ");
            string userInput = Console.ReadLine();
            return userInput;

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
        private static void ForEachViewComplete(List<string> lines)
        {
            foreach (string line in lines)
            {
                //prints the index a check box and the line
                Console.WriteLine($"{lines.IndexOf(line) + 1}[X] - {line}");
            }
        }

        //Marks the files as complete(Takes in both lists)
        private static void MarkTaskComplete(List<string> toDoList, List<string> toDoListComplete)
        {
            while (true)
            {
                //Displays Graphics
                Console.Clear();
                ForEachView(toDoList);
                Console.WriteLine("======================");
                Console.WriteLine("-- Select line item --");
                Console.WriteLine("======================");
                Console.WriteLine("- Type #Exit to Exit -");
                Console.WriteLine("======================");
                Console.Write("> ");

                string userInputCheck = Console.ReadLine();
                if(userInputCheck.ToLower() == "#exit" || userInputCheck == "#e")
                {
                    break;
                }
                bool userInputCheckParse = Int32.TryParse(userInputCheck, out int userInputCheckInt);
                int lengthOfToDoList = toDoList.Count;
                if (userInputCheckParse && userInputCheckInt <= lengthOfToDoList)
                {
                    toDoListComplete.Add(toDoList[userInputCheckInt-1]);
                    toDoList.RemoveAt(userInputCheckInt - 1);

                }
            }
        }

    }
}
