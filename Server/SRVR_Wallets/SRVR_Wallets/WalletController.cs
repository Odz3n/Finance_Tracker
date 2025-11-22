using System.Text.Json;


public class WalletController
{
    private readonly WalletService service = new WalletService();


    public string Handle(string command, string json)
    {
        switch (command)
        {
            case "wallet_create":
                var reqCreate = JsonSerializer.Deserialize<CreateWalletRequest>(json);
                var wallet = service.CreateWallet(reqCreate.UserId, reqCreate.Currency);
                return JsonSerializer.Serialize(wallet);


            case "wallet_deposit":
                var reqDeposit = JsonSerializer.Deserialize<WalletOperationRequest>(json);
                bool depositResult = service.Deposit(reqDeposit.WalletId, reqDeposit.Amount);
                return depositResult.ToString();


            case "wallet_withdraw":
                var reqWithdraw = JsonSerializer.Deserialize<WalletOperationRequest>(json);
                bool withdrawResult = service.Withdraw(reqWithdraw.WalletId, reqWithdraw.Amount);
                return withdrawResult.ToString();


            default:
                return "Unknown command";
        }
    }
}