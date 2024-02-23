namespace KaleGroup.Admin.Models
{
    public class AddSettingsViewModel
    {
        public int Id { get; set; }
        public string SettingsKey { get; set; }
        public string SettingsKeyHidden { get; set; }
        public string SettingsValue { get; set; }
        public bool IsActive { get; set; }

    }
}