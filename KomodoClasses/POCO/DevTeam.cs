using KomodoClasses.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClasses.POCO
{
    public class DevTeam
    {
        //private DeveloperRepo _developerRepo = new DeveloperRepo(); 
        //^^^^this will save list of developers until console close
        //must contain team members (developers), Team name, and team ID
        public List<Developer> _developerList { get; set; } = new List<Developer>();
        public int TeamID { get; set; }
        public string TeamName { get; set; }

        public DevTeam() { }

        public DevTeam(int teamID, string teamName, List<Developer> developerList)
        {
            TeamID = teamID;
            TeamName = teamName;
            _developerList = developerList;
        }

    }
}
