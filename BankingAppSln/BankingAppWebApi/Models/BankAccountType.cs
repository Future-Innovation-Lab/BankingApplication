using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankingAppWebApi.Models
{

    [Table("BankAccountType")]
    public class BankAccountType
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int BankAccountTypeId { get; set; }

        public string Description { get; set; }
    }
}
