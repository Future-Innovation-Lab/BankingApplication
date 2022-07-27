using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankingAppWebApi.Models
{
    [Table("BankAccount")]
    public class BankAccount
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int BankAccountId { get; set; }


        [ForeignKey("BankAccountType")]
        public int BankAccountTypeId { get; set; }

        public BankAccountType? BankAccountType { get; set; }


        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        public Customer? Customer { get; set; }

        public string AccountNumber { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal AccountBalance { get; set; }

        public ICollection<Transaction>? Transactions { get; set; }

    }
}
