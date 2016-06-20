using UnityEngine.UI;
using System.Collections;
using System;

public interface IBuildingViewController : IViewController
{
    void UpdateNumber(int number);
    void UpdateRevenue(int revenue);
    void UpdateCost(int cost);
}

public class BuildingViewController : ViewController, IBuildingViewController
{
    public Text BuildingNumber;
    public Text BuildingRevenue;
    public Text BuildingCost;
  
    public void UpdateNumber(int number)
    {
        BuildingNumber.text = "Number : " + number.ToString();
    }

    public void UpdateRevenue(int revenue)
    {
        BuildingRevenue.text = "Gold generated : " + revenue.ToString();
    }

    public void UpdateCost(int cost)
    {
        BuildingCost.text = "Cost : " + cost.ToString();
    }
}
