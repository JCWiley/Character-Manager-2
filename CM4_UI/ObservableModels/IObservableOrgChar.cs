using System;
using System.Collections.ObjectModel;

namespace CM4_UI.ObservableModels
{
    public interface IObservableOrgChar
    {
        public Guid ID { get; }
        public string Name { get; set; }
        public ObservableCollection<IObservableOrgChar>? Children { get;}
    }
}
