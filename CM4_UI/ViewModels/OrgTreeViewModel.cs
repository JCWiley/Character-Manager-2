using CM4_Core.LogicalGroupInterfaces;
using CM4_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM4_UI.ViewModels
{
    public class OrgTreeViewModel(IPeople people) : ViewModelBase
    {
        public List<Character> Characters
        { get => people.GetCharacters();}

        //public List<Organization> Organizations
       // { get => people.GetOrganizations(); }

    }
}
