using CharacterManager4.Models;
using CharacterManager4.Services.Interfaces;
using DynamicData.Tests;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://learn.microsoft.com/en-us/ef/core/get-started/overview/first-app?tabs=visual-studio

namespace CharacterManager4.Services.Implementations
{
    public class DataProvider_Database : DbContext, IDataProvider
    {
        DbSet<Item> _Items {  get; set; }

        ISettings _settings;

        public DataProvider_Database(ISettings settings)
        {
            _settings = settings;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite($"Data Source={_settings.DbPath}");
        }

        public string Test { get => _settings.DbPath; }
    }
}
