using KomodoClasses.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClasses.Repo
{
    public class DevTeamRepo
    {
        //C
        private readonly List<DevTeam> _devTeam = new List<DevTeam>();
        private readonly List<Developer> _teamMembers = new List<Developer>();
        public void AddDeveloperTeam(DevTeam team)
        {
            _devTeam.Add(team);
        }

        //R
        public List<DevTeam> GetTeamList()
        {
            return _devTeam;
        }

        public void AddTeamMember(Developer developer)
        {
            _teamMembers.Add(developer);
        }

        public DevTeam GetTeamByID(int devTeamID)
        {
            foreach (DevTeam devTeam in _devTeam)
            {
                if (devTeam.TeamID == devTeamID)
                {
                    return devTeam;
                }

            }
            return null;
        }
        //create a list within a list 
        //U



        //D
    }
}
