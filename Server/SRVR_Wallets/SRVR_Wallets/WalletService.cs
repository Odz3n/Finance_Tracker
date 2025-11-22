using SRVR_Wallets;
using System.Collections.Generic;


public class WalletService
{
    private readonly WalletRepository repo = new WalletRepository();


    public Wallet CreateWallet(int userId, string currency)
    {
        return repo.CreateWallet(userId, currency);
    }


    public bool Deposit(int walletId, decimal amount)
    {
        var wallet = repo.GetWallet(walletId);
        if (wallet == null || amount <= 0) return false;


        wallet.Balance += amount;
        repo.Update(wallet);
        return true;
    }


    public bool Withdraw(int walletId, decimal amount)
    {
        var wallet = repo.GetWallet(walletId);
        if (wallet == null || amount <= 0 || wallet.Balance < amount) return false;


        wallet.Balance -= amount;
        repo.Update(wallet);
        return true;
    }


    public List<Wallet> GetUserWallets(int userId)
    {
        return repo.GetUserWallets(userId);
    }
}