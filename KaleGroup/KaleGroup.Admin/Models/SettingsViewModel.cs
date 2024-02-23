namespace KaleGroup.Admin.Models
{
    public class SettingsViewModel
    {
        public int Id { get; set; }
        public string SettingsKey { get; set; }
        public string SettingsValue { get; set; }
        public bool IsActive { get; set; }

    }
}