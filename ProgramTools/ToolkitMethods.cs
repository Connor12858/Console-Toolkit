﻿using Console_Toolkit.Files;
using Pastel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Console_Toolkit
{
    internal class ToolkitMethods
    {
        // Outputs text with color
        public static void ColorWriteLine(string text, ConsoleColor color, string reg = "")
        {
            Console.WriteLine(reg + text.Pastel(color));
        }
        public static void ColorWrite(string text, ConsoleColor color, string reg = "")
        {
            Console.Write(reg + text.Pastel(color));
        }

        // Creates a menu display
        public static string Menu(string title)
        {
            // Change title to match entry of script name
            if (title == "Program")
            {
                title = "Menu";
            }
            else
            {
                title += " Manager";
            }

            // Declare empty string
            string menu = "";

            // Make the top row
            for (int i = 0; i < 14 + title.Length; i++)
            {
                menu += "=";
            }
            menu += '\n';

            // Add the title
            for (int i = 0; i < 7; i++)
            {
                menu += ' ';
            }
            menu += title.ToUpper();
            menu += '\n';

            // Make the bottom row
            for (int i = 0; i < 14 + title.Length; i++)
            {
                menu += "=";
            }

            // Return the string
            return menu;
        }

        // Clear the screen
        public static void ClearScreen(string title = null)
        {
            Console.Clear();
            if (title != null)
            {
                Console.WriteLine(Menu(title));
            }
        }

        // Retrieves a method from text
        public static MethodInfo RetrieveMethod(string classType, string methodName)
        {
            // Find the class type 
            Type type = Type.GetType("Console_Toolkit." + classType);

            // Checks if the type exists
            if (type != null)
            {
                // Get the method and return, even if null
                MethodInfo method = type.GetMethod(methodName);
                return method;
            }
            else
            {
                return null;
            }
        }

        // Check if the first word of a line and sent text match
        private static bool FirstWordToSentenceCheck(string line, string word)
        {
            // Break it down to just each word
            string[] words = line.Split(' ');

            // Empty lines clearly do not contain the word
            if (words.Length > 0)
            {
                // If line starts with the word then it is the word
                if (words[0] == word)
                {
                    return true;
                }

                return false;
            }
            else
            {
                return false;
            }
        }

        // Find the start and end for a block of code
        private static int BlockCodeLocator(int min, string[] lines)
        {
            // Check all lines
            for (int i = min + 1; i < lines.Length; i++)
            {
                // Only if it is not the last line
                if (i != lines.Length - 1)
                {
                    // Check if the first word is a word and not an indent
                    string[] words = lines[i].Split(' ');
                    if (words[0] != "")
                    {
                        return i - 2;
                    }
                }
            }

            // If we reached here than return the end
            return lines.Length - 1;
        }

        // Return the parts of the help menu text, for each part that needs it
        public static string Help(string lineName)
        {
            // Set the need info for disecting the text file
            string helpMenu = "";
            string[] lines = FileManager.ReadFromFile(ProgramCommonVariables.HelpFilePath);
            int min = ProgramCommonVariables.HelpMenuLength - 1;
            int max = lines.Length - 1;

            // Add the first lines no matter what
            for (int i = 0; i < ProgramCommonVariables.HelpMenuLength; i++)
            {
                helpMenu += lines[i] + "\n";
            }

            // Find the max and min for the block of code
            // Unless no line name is given we use all of it
            if (lineName != "Program")
            {
                // Loops through all lines to detect if the first word is the first line of the block
                for (int i = 0; i < FileManager.LineCount(ProgramCommonVariables.HelpFilePath); i++)
                {
                    if (FirstWordToSentenceCheck(lines[i], lineName))
                    {
                        min = i;
                    }
                }

                // Find the last line for the block of text
                max = BlockCodeLocator(min, lines);

                // Add the Back help line manually only when not Program
                helpMenu += "Back - Takes you back to the Main Menu\n\n";
            }

            // Add the min and max text, only need to check for lines after 3 since always added
            for (int i = ProgramCommonVariables.HelpMenuLength - 1; i < FileManager.LineCount(ProgramCommonVariables.HelpFilePath); i++)
            {
                if (min <= i && i <= max)
                {
                    helpMenu += lines[i] + "\n";
                }
            }

            // Return the text
            return helpMenu;
        }

        // Takes input for dynamic entry of running a method
        public static void CommandEntry(string input, string className)
        {
            // Remove whitespace on the sides
            input = input.Trim();

            // Get the main of the class for when we need to run it
            var classMenu = RetrieveMethod(className, "Menu");
            try
            {
                // Check for clear command
                if (input.ToLower() == "cls" || input.ToLower() == "clear")
                {
                    ToolkitMethods.ClearScreen(className);
                    classMenu.Invoke(null, new object[] { });
                }

                // Check if the 'Back' command was entered and can be used
                else if (input.ToLower() == "back")
                {
                    if (className != "Program" && ProgramCommonVariables.mangerList.Contains(className))
                    {
                        Console.Clear();
                        Program.Main();
                    }
                    else
                    {
                        Console.WriteLine("\nThere is no menu to go back to\n");
                        classMenu.Invoke(null, new object[] { });
                    }
                }

                // Check if the input is empty
                else if (input.Length == 0)
                {
                    classMenu.Invoke(null, new object[] { });
                }

                // Does not match so run the dynamic search
                else
                {
                    // Analyze the input for commands
                    List<string> commands = input.Split(' ').ToList();

                    // Check if input contains a class value, if not add the default class name
                    if (!ProgramCommonVariables.mangerList.Contains(commands[0]))
                    {
                        commands.Insert(0, className);
                    }

                    // Variables to determine the method to call
                    // Detect if we need to use the main method or not
                    string classType = commands[0];
                    string methodName = "Main";
                    if (commands.Count >= 2)
                    {
                        methodName = commands[1];
                    }

                    // Drop the first 2 items to make it a list of arguments
                    commands.Remove(classType);
                    commands.Remove(methodName);

                    // Compound the quoted text 
                    for(int i  = 0; i < commands.Count - 1; i++)
                    {
                        if (commands[i].StartsWith(Convert.ToString('"')))
                        {
                            while (!commands[i].EndsWith(Convert.ToString('"')))
                            {
                                commands[i] += " " + commands[i + 1];
                                commands.RemoveAt(i + 1);
                            }
                        }
                    }

                    // Check for even amount
                    if (commands.Count / 2 == 0 && commands.Count != 0)
                    {
                        throw new Exception("Wrong Argument Configuration");
                    }

                    // Compound them to work for the argument parser - which I made work weridly so we finna format this shi
                    for (int i = 0; i < commands.Count - 1; i++)
                    {
                        commands[i] += "?" + commands[i + 1];
                        commands.RemoveAt(i + 1);
                    }

                    // Turn the commands an array of provided commands
                    string[] providedArgs = commands.ToArray();

                    // Execute the method
                    var method = RetrieveMethod(classType, methodName);
                    if (method != null)
                    {
                        // Set the needed parameters and use default if not given
                        var parameters = method.GetParameters();
                        object[] args = new object[parameters.Length];
                        for (int i = 0; i < args.Length; i++)
                        {
                            if (i < providedArgs.Length)
                            {
                                args[i] = providedArgs[i];
                            }
                            else if (parameters[i].HasDefaultValue)
                            {
                                args[i] = parameters[i].DefaultValue;
                            }
                            else
                            {
                                throw new ArgumentException("Not enough arguments provided");
                            }
                        }

                        method.Invoke(null, args);
                        classMenu.Invoke(null, new object[] { });
                    }
                    else
                    {
                        Console.WriteLine(Help(className));
                        classMenu.Invoke(null, new object[] { });
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\n" + e.Message + "\n");
                classMenu.Invoke(null, new object[] { });
            }
        }
    }
}
