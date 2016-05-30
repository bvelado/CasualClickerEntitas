using UnityEngine.UI;
using System.Collections;
using System;

public interface IBuildingViewController : IViewController
{
    void UpdateBuilding(int number, int revenue);
}

public class BuildingViewController : ViewController, IBuildingViewController
{
    public Text BuildingNumber;
    public Text BuildingRevenue;

    public void UpdateBuilding(int number, int revenue)
    {
        BuildingNumber.text = number.ToString();
        BuildingRevenue.text = "+ " + revenue; 
    }

    public override void UpdateContent()
    {
        
    }
}
