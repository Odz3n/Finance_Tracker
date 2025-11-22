using System.Text.Json;

public class CreateWalletRequest
{
    public int UserId { get; set; }
    public string Currency { get; set; }
}


public class WalletOperationRequest
{
    public int WalletId { get; set; }
    public decimal Amount { get; set; }
}