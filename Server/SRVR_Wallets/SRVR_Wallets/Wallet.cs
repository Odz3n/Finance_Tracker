namespace SRVR_Wallets
{
    public class Wallet
    {
        public int WalletId { get; set; }
        public int UserId { get; set; }
        public string Currency { get; set; } = "USD";
        public decimal Balance { get; set; } = 0;
    }
}