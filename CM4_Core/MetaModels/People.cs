using CM4_Core.DataAccess;
using CM4_Core.Models;
using CM4_Core.Service.Interfaces;
using CM4_Core.Service.Interfaces.EventDataPackages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM4_Core.MetaModels
{
    public class People
    {
        IDataAccess _da;
        INotifyService _notifyService;

        Dictionary<Guid, Character> _characterDict;
        Dictionary<Guid, Organization> _organizationDict;

        public People(IDataAccess DA, INotifyService notifyService)
        {
            _da = DA;
            _notifyService = notifyService;

            _characterDict = [];
            _organizationDict = [];

            _notifyService.NotifyDataSourceChanged += _notifyService_NotifyDataSourceChanged;
            _notifyService.NotifyDataSourceAboutToChange += _notifyService_NotifyDataSourceAboutToChange;
            _notifyService.NotifyApplicationAboutToClose += _notifyService_NotifyApplicationAboutToClose;
        }

        private void _notifyService_NotifyApplicationAboutToClose(object? sender, EventArgs e)
        {
            WriteToDataAccess();
        }
        private void _notifyService_NotifyDataSourceChanged(object? sender, EventArgs e)
        {
            ReadFromDataAccess();
        }
        private void _notifyService_NotifyDataSourceAboutToChange(object? sender, EventArgs e)
        {
            WriteToDataAccess();
        }

        private void ReadFromDataAccess()
        {
            foreach (Organization organization in _da.Repository.Get<Organization>())
            {
                _organizationDict[organization.ID] = organization;
            }
            foreach (Character character in _da.Repository.Get<Character>())
            {
                _characterDict[character.ID] = character;
            }
            _notifyService.OnPeopleUpdated(this,new PeopleUpdatedArgs());
        }

        private void WriteToDataAccess()
        {
            foreach (Organization org in _organizationDict.Values)
            {
                if (_da.Repository.Get<Organization>().Contains(org))
                {
                    _da.Repository.Update(org);
                }
                else
                {
                    _da.Repository.Add(org);
                }
            }
            foreach (Character character in _characterDict.Values)
            {
                if (_da.Repository.Get<Character>().Contains(character))
                {
                    _da.Repository.Update(character);
                }
                else
                {
                    _da.Repository.Add(character);
                }
            }
        }

        public Guid AddOrg()
        {
            Organization org = new Organization();
            _organizationDict[org.ID] = org;
            _notifyService.OnPeopleUpdated(this, new PeopleUpdatedArgs(org.ID));
            return org.ID;
        }
        public Guid AddOrg(Organization org)
        {
            _organizationDict[org.ID] = org;
            _notifyService.OnPeopleUpdated(this, new PeopleUpdatedArgs(org.ID));
            return org.ID;
        }

        public Organization? GetOrg(Guid ID)
        {
            if(ID != Guid.Empty && _organizationDict.ContainsKey(ID)){
                return _organizationDict[ID];
            }
            return null;
        }
        public List<Organization> GetOrg(List<Guid> ID)
        {
            return _organizationDict.Values.Where(x => ID.Contains(x.ID) == true).ToList();
        }

        public List<Organization> GetOrg()
        {
            return _organizationDict.Values.ToList();
        }

        public Guid AddChar()
        {
            Character Char = new Character();
            _characterDict[Char.ID] = Char;
            _notifyService.OnPeopleUpdated(this,new PeopleUpdatedArgs(Char.ID));
            return Char.ID;
        }

        public Guid AddChar(Character Char)
        {
            _characterDict[Char.ID] = Char;
            _notifyService.OnPeopleUpdated(this, new PeopleUpdatedArgs(Char.ID));
            return Char.ID;
        }

        public Character? GetChar(Guid ID)
        {
            if (ID != Guid.Empty && _characterDict.ContainsKey(ID)){
                return _characterDict[ID];
            }
            return null;
        }
        public List<Character> GetChar(List<Guid> ID)
        {
            return _characterDict.Values.Where(x => ID.Contains(x.ID) == true).ToList();
        }

        public List<Character> GetChar()
        {
            return _characterDict.Values.ToList();
        }

        public void AddChild(Organization Parent, Organization Child)
        {
            if (!_organizationDict.ContainsKey(Parent.ID) || !_organizationDict.ContainsKey(Child.ID))
            {
                throw new InvalidDataException("AddChild Parent or Child does not exist in dict");
            }
            else
            {
                _organizationDict[Parent.ID].Child_Organizations.Add(Child.ID);
                _organizationDict[Child.ID].Parent_Organizations.Add(Parent.ID);
            }
        }

        public void AddChild(Organization Parent, Character Child)
        {
            if (!_organizationDict.ContainsKey(Parent.ID) || !_characterDict.ContainsKey(Child.ID))
            {
                throw new InvalidDataException("AddChild Parent or Child does not exist in dict");
            }
            else
            {
                _organizationDict[Parent.ID].Child_Characters.Add(Child.ID);
                _characterDict[Child.ID].Parent_Organizations.Add(Parent.ID);
            }
        }

        public bool IsChar(Guid? Key)
        {
            if(Key == null)
            {
                return false;
            }
            return _characterDict.ContainsKey((Guid)Key);
        }

        public bool IsOrg(Guid? Key)
        {
            if (Key == null)
            {
                return false;
            }
            return _organizationDict.ContainsKey((Guid)Key);
        }

        public void AddJob(Guid ownerID, Guid ID)
        {
            if (IsChar(ownerID))
            {
                _characterDict[ownerID].Jobs.Add(ID);
            }
            else if (IsOrg(ownerID))
            {
                _organizationDict[ownerID].Jobs.Add(ID);
            }   
        }
    }
}
