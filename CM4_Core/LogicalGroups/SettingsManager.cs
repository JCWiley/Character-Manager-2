using CM4_Core.DataAccess;
using CM4_Core.LogicalGroupInterfaces;
using CM4_Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM4_Core.LogicalGroups
{
    public class SettingsManager(IDataAccess dataAccess,INotifyService notifyService) : ISettingsManager
    {
        IDataAccess _dataAccess = dataAccess;
        INotifyService _notifyService = notifyService;

        public void OpenProject(string Path)
        {
            _dataAccess.OpenDataStore(Path);
            _notifyService.OnDataSourceChanged();
        }

        public void NewProject(string Path)
        {
            _dataAccess.CreateDataStore(Path);
            _notifyService.OnDataSourceChanged();
        }

        public string DataPath
        {
            get {
                return _dataAccess.StoragePath;
            }
        }

    }
}
