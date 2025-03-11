using CM4_Core.Models;
using CM4_UI.ViewModels;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace CM4_UI.ObservableModels
{
    public class ObservableCharacter : ViewModelBase, IObservableOrgChar
    {
        private Character DataSource;
        public ObservableCharacter(Character _source)
        {
            DataSource = _source;
            Parent_Organization_IDs = new ObservableCollection<Guid>(DataSource.Parent_Organizations);
        }

        public ObservableCharacter()
        {
            DataSource = new Character();
            Parent_Organization_IDs = new ObservableCollection<Guid>();
        }

        public Character GetDataSource()
        {
            DataSource.Parent_Organizations = Parent_Organization_IDs.ToList();
            
            return DataSource;
        }

        public Guid Id
        {
            get
            {
                return DataSource.ID;
            }
        }
        public string Name
        {
            get
            {
                return DataSource.Name;
            }
            set
            {
                DataSource.Name = value;
                this.RaisePropertyChanged(nameof(Name));
            }
        }

        private ObservableCollection<Guid> _parent_Organization_IDs;
        public ObservableCollection<Guid> Parent_Organization_IDs
        {
            get
            {
                return _parent_Organization_IDs;
            }
            set
            {
                if (value != null)
                {
                    _parent_Organization_IDs = value;
                    this.RaisePropertyChanged(nameof(Parent_Organization_IDs));
                }
            }
        }
        public int Age
        {
            get
            {
                return DataSource.Age;
            }
            set
            {
                DataSource.Age = value;
                this.RaisePropertyChanged(nameof(Age));
            }
        }

        public ObservableCollection<IObservableOrgChar>? Children => null;
    }
}
