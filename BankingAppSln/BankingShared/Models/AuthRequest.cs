namespace BankingShared.Models
{

    // TODO Add Security as this pin is in CLEARTEXT
    public class AuthRequest
    {
        public string UserName { get; set; }
        public string Pin { get; set; }
    }
}
