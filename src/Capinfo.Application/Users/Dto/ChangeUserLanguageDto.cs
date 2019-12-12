using System.ComponentModel.DataAnnotations;

namespace Capinfo.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}