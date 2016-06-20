using System;
using UnityEngine.UI;

public interface IPlayerGoldViewController : IViewController {
    void UpdateGoldAmount(int amount);
    void UpdateGoldRevenue(int revenue);
}

public class PlayerGoldViewController : ViewController, IPlayerGoldViewController {

    public Text GoldAmount;
    public Text GoldRevenue;

    public void UpdateGoldAmount(int amount)
    {
        GoldAmount.text = amount.ToString();
    }

    public void UpdateGoldRevenue(int revenue)
    {
        GoldRevenue.text = revenue.ToString();
    }
}
