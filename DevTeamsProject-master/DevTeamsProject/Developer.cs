using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    //POCO 
    //From assignment: Developers have names and ID numbers; we need to be able to identify one developer without mistaking them for another. We also need to know whether or not they have access to the online learning tool: Pluralsight.

    public class Developer
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public bool HasPluralsightAccess { get; set; }

        public Developer(int iD, string name, bool hasPluralsightAccess)
        {
            ID = iD;
            Name = name;
            HasPluralsightAccess = hasPluralsightAccess;
        }

        //Needed to add this because I was not able to make a blank developer in the code when I was creating new content. It was seeking an ID and all other info to be specified already when creating content.
        public Developer()
        {
        }
    }
}
