using CM4_Core.DataAccess;
using CM4_Core.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM4_UI.ViewModels
{
    public class OrganizationDetailViewModel : ViewModelBase
    {
        IDataAccess _da;
        INotifyService _notifyService;

        public OrganizationDetailViewModel(IDataAccess DA, INotifyService notifyService)
        {
            _da = DA;
            _notifyService = notifyService;
        }
    }
}
