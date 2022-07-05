using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankingAppWebApi.Models
{
    public class Transaction
    {

        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int TransactionId { get; set; }

        public DateTime TransactionDate { get; set; }

        [ForeignKey("TransactionType")]
        public int TransactionTypeId { get; set; }

        public TransactionType? TransactionType { get; set; }

        public string Description { get; set; }

        public string Reference { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal Amount { get; set; }

        [ForeignKey("BankAccount")]
        public int BankAccountId { get; set; }

        public BankAccount? BankAccount { get; set; }


    }
}
