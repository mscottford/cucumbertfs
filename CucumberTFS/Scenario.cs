using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CucumberTfs
{
    public class Scenario
    {
        private int id;
        private string title;
        private string description;

        public Scenario(int id, string title, string description)
        {
            this.id = id;
            this.title = title;
            this.description = description;

            var descriptionBytes = Encoding.Unicode.GetBytes(description);
            descriptionBytes = Encoding.Convert(Encoding.Unicode, Encoding.ASCII, descriptionBytes);
            description = Encoding.ASCII.GetString(descriptionBytes);
        }

        public int Id
        {
            get
            {
                return id;
            }
        }

        public string Title
        {
            get
            {
                return title;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }
        }
    }
}
