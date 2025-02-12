using CM4_Core.DataAccess;
using CM4_Core.Service.Interfaces;

namespace CM4_UI.ViewModels
{
    public class CharacterDetailViewModel : ViewModelBase
    {
        IDataAccess _da;
        INotifyService _notifyService;

        public CharacterDetailViewModel(IDataAccess DA, INotifyService notifyService)
        {
            _da = DA;
            _notifyService = notifyService;
        }
    }
}
