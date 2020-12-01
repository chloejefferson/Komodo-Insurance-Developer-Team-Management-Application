using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class DeveloperRepo
    {
        private readonly List<Developer> _developerDirectory = new List<Developer>();

        //Developer Create
        public void AddDeveloperToList(Developer developer)
        {
            _developerDirectory.Add(developer);
        }
        //Developer Read
        public List<Developer> GetDevelopersList()
        {
            return _developerDirectory;
        }
        //Developer Update
        public bool UpdateDeveloperDirectory(int id, Developer newInfo)
        {
            Developer oldInfo = GetDeveloperByID(id);

            if(oldInfo != null)
            {
                oldInfo.ID = newInfo.ID;
                oldInfo.Name = newInfo.Name;
                oldInfo.HasPluralsightAccess = newInfo.HasPluralsightAccess;
                return true;
            }
            else
            {
                return false;
            }
        }
        //Developer Delete
        public bool RemoveDeveloperFromDirectory(int id)
        {
            Developer developer = GetDeveloperByID(id);

            //if developer can't be found, write "false" (did not delete)
            if (developer == null)
            {
                return false;
            }

            //Take an initially tally and then remove the developer
            int initialCount = _developerDirectory.Count;
            _developerDirectory.Remove(developer);

            if(initialCount > _developerDirectory.Count)
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        //Developer Helper (Get Developer by ID)
        public Developer GetDeveloperByID (int id)
        {
            foreach(Developer developer in _developerDirectory)
            {
                if(developer.ID == id)
                {
                    return developer;
                }
            }
            return null;
        }
    }
}
