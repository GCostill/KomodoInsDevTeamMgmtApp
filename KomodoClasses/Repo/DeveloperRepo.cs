using KomodoClasses.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClasses.Repo
{
    public class DeveloperRepo
    {
        private readonly List<Developer> _listOfDevelopers = new List<Developer>();

        //Create
        public void AddDeveloperToList(Developer developer)
        {
            _listOfDevelopers.Add(developer);
        }

        //Read
        public List<Developer> GetDeveloperList()
        {
            return _listOfDevelopers;
        }


        //Update
      public Developer GetDeveloperByID(int devID)
      {
          foreach(Developer developer in _listOfDevelopers)
          {
              if (developer.DevID == devID)
              {
                  return developer;
              }
              
          }
          return null;
       }
 //      public bool UpdateExistingContent(int originalID, Developer newContent)
 //      {
 //          Developer oldContent = GetDeveloperByID(originalID);
 //
 //          if(oldContent != null)
 //          {
 //              oldContent.FirstName = newContent.FirstName;
 //              oldContent.LastName = newContent.LastName;
 //              oldContent.DevID = newContent.DevID;
 //              oldContent.Pluralsight = newContent.Pluralsight;
 //
 //              return true;
 //          }
 //          else
 //          {
 //              return false;
 //          }
 //              
 //      }
 //
 //      public bool RemoveDeveloperFromList(int devID)
 //      {
 //          Developer developer = GetDeveloperByID(devID);
 //
 //          if(developer == null)
 //          {
 //              return false;
 //          }
 //
 //          int initialCount = _listOfDevelopers.Count;
 //          _listOfDevelopers.Remove(developer);
 //
 //          if(initialCount > _listOfDevelopers.Count)
 //          {
 //              return true;
 //          }
 //          else
 //          {
 //              return false;
 //          }
 //       }
    }
}

