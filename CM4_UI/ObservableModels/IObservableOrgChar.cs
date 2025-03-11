using System.Collections.ObjectModel;

namespace CM4_UI.ObservableModels
{
    public interface IObservableOrgChar
    {
        public string Name { get; set; }
        public ObservableCollection<IObservableOrgChar>? Children { get;}
    }
}
