using Avalonia.Controls;
using Avalonia.Platform.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM4_UI.Menus.Interfaces
{
    public interface IFilesService
    {
        public void SetParentWindow(Window ParentWindow);
        public Task<IStorageFile?> GetNewProjectPathFromUser();
        public Task<IStorageFile> GetExistingProjectPathFromUser();
    }
}
