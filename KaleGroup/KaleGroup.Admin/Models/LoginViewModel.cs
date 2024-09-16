namespace KaleGroup.Admin.Models
{
    public class LoginViewModel
    { 
        public string Username { get; set; }
        public string Password { get; set; }
        public bool ShowCaptcha { get; set; }
        public string CaptchaCode { get; set; }
    }
}