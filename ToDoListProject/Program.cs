using System;
using System.Collections.Generic;
using System.IO;

namespace ToDoListProject
{

    internal class Program
    {
        //To Do:


        static void Main(string[] args)
        {
            VerifyFiles();
            

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


            
            while (true)
            {
                //Displays the Graphics
                Console.Clear();

                //Takes the user input method and stores it in a string
                string input = UserInput(toDoList,toDoListComplete);

                //If the conditions are met, will exit out of the program
                if (input.ToLower() == "#save" || input == "#s")
                {
                    break;
                }
                else if (input.ToLower() == "#mark" || input == "#m")
                {
                    MarkTaskComplete(toDoList, toDoListComplete);
                }
                else if(input.ToLower() == "#delete" || input == "#d")
                {
                    DeleteTasks(toDoList);
                }
                else
                {
                    if (toDoList.Contains(input))
                    {
                        //Doesn't add to the list if it already exists
                    }
                    else
                    {
                        toDoList.Add(input);
                    }

                }
                
            }
            //Exiting the Program
            Console.Clear();
            Console.WriteLine("=======================");
            Console.WriteLine("----- Saving List -----");
            Console.WriteLine("=======================");
            Console.WriteLine("------ ToDo List ------");
            ForEachView(toDoList);
            Console.WriteLine("------ Completed ------");
            ForEachViewComplete(toDoListComplete);
            Console.WriteLine("=======================");
            Console.WriteLine("Files saved. \nPress any key to quit...");
            Console.Read();
            //Saves the lists to the files
            File.WriteAllLines(path, toDoList);
            File.WriteAllLines(pathComplete, toDoListComplete);
        }


        private static void VerifyFiles()
        {
            //if the files dont exist makes new files
            if (!File.Exists(@"list.txt"))
            {
                using (File.Create("list.txt")) { }
            }

            if (!File.Exists(@"list-complete.txt"))
            {
                using (File.Create("list-complete.txt")) { }
            }
        }


        //Takes the user input for the tasks on the list
        private static string UserInput(List<string> toDoList, List<string> toDoListComplete)
        {
            //Displays instructions
            Console.WriteLine("=======================");
            Console.WriteLine("----- Add to List -----");
            Console.WriteLine("=======================");
            Console.WriteLine("------ ToDo List ------");
            ForEachView(toDoList);
            Console.WriteLine();
            Console.WriteLine("------ Completed ------");
            ForEachViewComplete(toDoListComplete);
            Console.WriteLine();
            Console.WriteLine("=======================");
            Console.WriteLine("Type #Mark to Mark Off");
            Console.WriteLine("Type #Delete to Delete");
            Console.WriteLine("Type #Save to Save");
            Console.WriteLine("=======================");
            Console.Write("> ");
            string userInput = Console.ReadLine();
            return userInput;

        }

        //Displays the list itself using a foreach loop
        private static void ForEachView(List<string> lines)
        {
            foreach (string line in lines)
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
                Console.WriteLine("======================");
                Console.WriteLine("-- Mark As Complete --");
                Console.WriteLine("======================");
                ForEachView(toDoList);
                Console.WriteLine();
                Console.WriteLine("======================");
                Console.WriteLine("-- Select line item --");
                Console.WriteLine("======================");
                Console.WriteLine("- Type #Exit to Exit -");
                Console.WriteLine("======================");
                Console.Write("> ");

                string userInputCheck = Console.ReadLine();
                if (userInputCheck.ToLower() == "#exit" || userInputCheck == "#e")
                {
                    break;
                }
                bool userInputCheckParse = Int32.TryParse(userInputCheck, out int userInputCheckInt);
                int lengthOfToDoList = toDoList.Count;
                if (userInputCheckParse && userInputCheckInt <= lengthOfToDoList)
                {
                    toDoListComplete.Add(toDoList[userInputCheckInt - 1]);
                    toDoList.RemoveAt(userInputCheckInt - 1);

                }
            }
        }

        private static void DeleteTasks(List<string> toDoList)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("======================");
                Console.WriteLine("------- Delete -------");
                Console.WriteLine("======================");
                ForEachView(toDoList);
                Console.WriteLine();
                Console.WriteLine("======================");
                Console.WriteLine("-- Select line item --");
                Console.WriteLine("======================");
                Console.WriteLine("- Type #Exit to Exit -");
                Console.WriteLine("======================");
                Console.Write("> ");

                string userInputCheck = Console.ReadLine();
                if (userInputCheck.ToLower() == "#exit" || userInputCheck == "#e")
                {
                    break;
                }
                bool userInputCheckParse = Int32.TryParse(userInputCheck, out int userInputCheckInt);
                int lengthOfToDoList = toDoList.Count;
                if (userInputCheckParse && userInputCheckInt <= lengthOfToDoList)
                {
                    toDoList.RemoveAt(userInputCheckInt - 1);
                }
            }


        }

    }
}
