using SRVR_Wallets;
using System.Collections.Generic;
using System.Linq;


public class WalletRepository
{
    private List<Wallet> wallets = new List<Wallet>();


    public Wallet CreateWallet(int userId, string currency)
    {
        var w = new Wallet
        {
            WalletId = wallets.Count + 1,
            UserId = userId,
            Currency = currency,
            Balance = 0
        };


        wallets.Add(w);
        return w;
    }


    public Wallet GetWallet(int walletId)
    {
        return wallets.FirstOrDefault(w => w.WalletId == walletId);
    }

    // Додано метод Update
    public void Update(Wallet wallet)
    {
        // Метод потрібен для архітектурної цілісності
    }


    public List<Wallet> GetUserWallets(int userId)
    {
        return wallets.Where(w => w.UserId == userId).ToList();
    }
}