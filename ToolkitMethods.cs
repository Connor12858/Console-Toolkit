using Console_Toolkit.Files;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Console_Toolkit
{
    internal class ToolkitMethods
    {
        // Creates a menu display
        public static string Menu(string title)
        {
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
            // Default it to 0
            int max = 0;

            // Check all lines
            for (int i = min; i < lines.Length; i++)
            {
                // Only if it is not the last line
                if (i != lines.Length - 1)
                {
                    // Check if the first word is a word and not an indent
                    string[] words = lines[i].Split(' ');
                    if (words[0] != " ")
                    {
                        max = i - 1;
                        break;
                    }
                } else
                // If it is than we can tell it is the last block
                {
                    max = lines.Length - 1;
                }
            }

            return max;
        }

        // Return the parts of the help menu text, for each part that needs it
        public static string Help(string lineName = "")
        {
            // Set the need info for disecting the text file
            string helpMenu = "";
            string[] lines = FileManager.ReadFromFile(ProgramCommonVariables.HelpFilePath);
            int min = ProgramCommonVariables.HelpMenuLength - 1;
            int max = lines.Length - 1;

            // Find the max and min for the block of code
            // Unless no line name is given we use all of it
            if (lineName != "")
            {
                // Loops through all lines to detect if the first word is the first line of the block
                for (int i = 0; i < FileManager.LineCount("..\\..\\ProgramFiles\\HelpMenu.txt"); i++)
                {
                    if (FirstWordToSentenceCheck(lines[i], lineName))
                    {
                        min = i;
                    }
                }

                // Find the last line for the block of text
                max = BlockCodeLocator(min, lines);
            }

            // Add the first lines no matter what
            for (int i = 0; i < ProgramCommonVariables.HelpMenuLength; i++)
            {
                helpMenu += lines[i] + "\n";
            }

            // Add the min and max text, only need to check for lines after 3 since always added
            for (int i = ProgramCommonVariables.HelpMenuLength - 1; i < FileManager.LineCount("..\\..\\ProgramFiles\\HelpMenu.txt"); i++)
            {
                if (min <= i && i <= max)
                {
                    helpMenu += lines[i] + "\n";
                }
            }

            // Return the text
            return helpMenu;
        }
    }
}
