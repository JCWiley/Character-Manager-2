using CM4_Core.Service.Interfaces;

namespace CM4_Core.Service.Implementations
{
    public class SettingsService : ISettingsService
    {
        public SettingsService()
        {
            ProjectPath = string.Empty;
        }
        public string ProjectPath { get; set; }
    }
}
