namespace KaleGroup.Admin.Models
{
    public class ChangeUserViewModel
    {
        public  int Id { get; set; }
     
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string NewRepeatPassword { get; set; }
     

    }
}