using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankingAppWebApi.Models
{

    [Table("TransactionType")]
    public class TransactionType
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int TransactionTypeId { get; set; }

        public string Description { get; set; }

    }
}
