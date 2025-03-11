using Avalonia.Controls;
using Avalonia.Platform.Storage;
using CM4_Core.Service.Interfaces;
using CM4_UI.Menus.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM4_UI.ViewModels
{
    public class MenuViewModel(IFileUIService filesService,IFileService fileService) : ViewModelBase
    {
        IFileUIService _filesService = filesService;
        IFileService _fileService = fileService;

        public async Task NewProjectAsync()
        {
            IStorageFile? newFile = await _filesService.GetNewProjectPathFromUser();
            string? path = newFile?.TryGetLocalPath();
            Debug.WriteLine("Attempting to open new project with path " + path);
            if (path != null) 
            {
                Debug.WriteLine("Opening new project with path " + path);
                _fileService.NewProject(path);
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
                _fileService.OpenProject(path);
            }
        }
    }
}
