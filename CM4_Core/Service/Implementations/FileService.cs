using CM4_Core.DataAccess;
using CM4_Core.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM4_Core.Service.Implementations
{
    internal class FileService(IDataAccess dataAccess, INotifyService notifyService, ISettingsService settings) : IFileService
    {
        IDataAccess _dataAccess = dataAccess;

        public void OpenProject(string Path)
        {
            _dataAccess.OpenDataStore(Path);
        }

        public void NewProject(string Path)
        {
            _dataAccess.CreateDataStore(Path);
        }

    }
}
