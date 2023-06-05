using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Toolkit.ProgramTools
{
    internal class ArgumentParser
    {
        // A List of the arguments for the parser
        private List<(string, dynamic)> args;

        // Create the object
        public ArgumentParser() 
        { 
            this.args = new List<(string, dynamic)> ();
        }

        public void AddArgument<T>(string name, string defaultValue = "")
        {
            // Create the base tuple to add to list
            (string, dynamic) argTuple = (name, typeof(T));
            
            // Set the default value
            argTuple.Item2 = Convert.ChangeType(defaultValue, typeof(T));

            // Add the tuple to the list
            this.args.Add (argTuple);
        }

        public void BreakdownArgs(string arg)
        {

        }

        public dynamic GetArgumentValue(string name)
        {
            foreach (dynamic argTuple in this.args)
            {
                if (argTuple.Item1 == name)
                {
                    return argTuple.Item2;
                }
            }

            return null;
        }
    }
}
