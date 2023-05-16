using System;
using System.Collections.Generic;
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
        public static void ClearScreen(string title)
        {
            Console.Clear();
            if( title != null)
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
    }
}
