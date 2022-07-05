using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankingAppWebApi.Models
{
    [Table("Customer")]
    public class Customer
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int CustomerId { get; set; }
        public string FirstNames { get; set; }
        public string Surname { get; set; }
        public string IdNumber { get; set; }
        public string ResidentialAddress { get; set; }
        public string EmailAddress { get; set; }
        public string CellPhoneNumber { get; set; }

        [ForeignKey("Authentication")]
        public int AuthenticationId { get; set; }

        public Authentication? Authentication { get; set; }

        public ICollection<BankAccount> BankAccounts { get; set; }

    }
}
