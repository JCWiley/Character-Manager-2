using Avalonia.Controls;
using Avalonia.Platform.Storage;
using CM4_Core.LogicalGroupInterfaces;
using CM4_UI.Menus.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM4_UI.ViewModels
{
    public class MenuViewModel(IFilesService filesService,ISettingsManager settingsManager) : ViewModelBase
    {
        IFilesService _filesService = filesService;
        ISettingsManager _settingsManager = settingsManager;

        public async Task NewProjectAsync()
        {
            IStorageFile? newFile = await _filesService.GetNewProjectPathFromUser();
            string? path = newFile?.TryGetLocalPath();
            Debug.WriteLine("Attempting to open new project with path " + path);
            if (path != null) 
            {
                Debug.WriteLine("Opening new project with path " + path);
                _settingsManager.NewProject(path);
            }
        }

        public async Task OpenProjectAsync()
        {
            IStorageFile? newFile = await _filesService.GetExistingProjectPathFromUser();
            string? path = newFile?.TryGetLocalPath();
            Debug.WriteLine("Attempting to open existing project with path " + path);
            if (path != null)
            {
                Debug.WriteLine("Opening existing project with path " + path);
                _settingsManager.OpenProject(path);
            }
        }
    }
}
