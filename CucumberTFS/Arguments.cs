using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CucumberTfs
{
    public class Arguments
    {
        private string first;
        private string[] rest;

        public Arguments(string[] args)
        {
            first = args[0];

            rest = new string[args.Length - 1];
            for (int index = 1; index < args.Length; index++)
            {
                rest[index - 1] = args[index];
            }
        }

        public string First
        {
            get
            {
                return first;
            }
        }

        public string[] Rest
        {
            get
            {
                return rest;
            }
        }
    }
}
