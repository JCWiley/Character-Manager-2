using Avalonia.Controls;
using Avalonia.Platform.Storage;
using CM4_UI.Menus.Interfaces;
using CM4_UI.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM4_UI.Menus.Implementations
{
    public class FileUIService : IFileUIService
    {
        Window _target = null;
        public void SetParentWindow(Window ParentWindow)
        {
            _target = ParentWindow;
        }
        public async Task<IStorageFile?> GetNewProjectPathFromUser()
        {
            return await _target.StorageProvider.SaveFilePickerAsync(new FilePickerSaveOptions()
            {
                Title = "Create New Project"
                //FileTypeChoices = new[] { }
            });
        }

        public async Task<IStorageFile> GetExistingProjectPathFromUser()
        {
            Debug.WriteLine("GetExistingProjectPathFromUser was called");
            return (await _target.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions()
            {
                Title = "Create New Project",
                AllowMultiple = false
                //FileTypeChoices = new[] { }
            }))[0];
        }
    }
}
