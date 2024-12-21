using CharacterManager4.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterManager4.Services.Implementations;
using CharacterManager4.Services.Interfaces;
using CharacterManager4.Models;

namespace CharacterManager4.Utilities
{
    public static class ServiceCollectionExtensions
    {
        public static void AddCommonServices(this IServiceCollection collection)
        {
            //Services
            collection.AddSingleton<IDataProvider, DataProvider_Database>();
            collection.AddSingleton<ISettings, HardcodedSettings>();
            collection.AddSingleton<IDataManager, DataManager>();

            //ViewModels
            collection.AddTransient<MainViewModel>();

        }
    }
}
