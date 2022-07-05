using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankingAppWebApi.Models
{
    public class Authentication
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int AuthenticationId { get; set; }

        public string EmailAddress { get; set; }
        public string Pin { get; set; }
        public DateTime LastLoginTime { get; set; }
        public bool Enabled { get; set; }
    }
}
