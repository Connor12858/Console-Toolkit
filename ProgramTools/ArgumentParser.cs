using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Console_Toolkit.ProgramTools
{
    internal class ArgumentParser
    {
        // A List of the arguments for the parser
        private List<(string, dynamic)> args;

        // Create the object
        public ArgumentParser()
        {
            this.args = new List<(string, dynamic)>();
        }

        public void AddArgument<T>(string name, string defaultValue = "")
        {
            // Create the base tuple to add to list
            (string, dynamic) argTuple = (name, typeof(T));

            // Set the default value
            argTuple.Item2 = Convert.ChangeType(defaultValue, typeof(T));

            // Add the tuple to the list
            this.args.Add(argTuple);
        }

        // Check for if the arg is real
        private bool ArgIsReal(string arg)
        {
            for (int x = 0; x < this.args.Count; x++)
            {
                if (this.args[x].Item1 == arg)
                {
                    return true;
                }
            }

            return false;
        }

        private void SetArgValue(string arg, string value)
        {

        }

        // Take the argument string given and add it the parser stored args
        // Does 1 arg at a time
        public bool BreakdownArgs(string[] args)
        {
            // Try to do this unless it is not valid
            try
            {
                foreach (string arg in args)
                {
                    // Split the args to check for each one
                    string[] argsList = arg.Split('?');

                    // Only if we have args and even 
                    if (argsList.Count() != 0 && argsList.Count() % 2 == 0)
                    {
                        if (ArgIsReal(argsList[0]))
                        {
                            // Look for a matching arg
                            for (int x = 0; x < this.args.Count; x++)
                            {
                                // If it is the arg than assign new value
                                if (this.args[x].Item1 == argsList[0])
                                {
                                    // Try it
                                    try
                                    {
                                        // Set the new value, need a temp obj
                                        (string, dynamic) d = this.args[x];
                                        d.Item2 = Convert.ChangeType(argsList[1], this.args[x].Item2.GetType());
                                        this.args[x] = d;
                                        return true;
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                        return false;
                                    }
                                }
                            }
                        }
                        else
                        // Raise exception that it is not real
                        {
                            throw new Exception("Argument given is not a real argument");
                        }
                    }
                    // Raise exception that they do not match
                    else
                    {
                        throw new Exception("Arguments given do not match what is needed");
                    }
                }
            }
            // Output and return not properly parsed
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

            return false;
        }

        // Get the value of an arg
        public dynamic GetArgumentValue(string name)
        {
            // Only if it is real, bad code if not
            if (ArgIsReal(name))
            {
                // Find and return
                foreach (dynamic argTuple in this.args)
                {
                    if (argTuple.Item1 == name)
                    {
                        return argTuple.Item2;
                    }
                }

                return null;
            }

            return null;
        }
    }
}
