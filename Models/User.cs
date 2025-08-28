using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.SqlTypes;


namespace MyApp.Model
{
    public class User
    {
        public int id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required, DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
        [NotMapped, DataType(DataType.Password)]
        public string C_Password { get; set; } = string.Empty;
    }

    public class UserOtp
    {
        public int id { get; set; }
        public string Email { get; set; } = string.Empty;

        public int Otp { get; set; }
        public DateTime Expire { get; set; }
    }
}