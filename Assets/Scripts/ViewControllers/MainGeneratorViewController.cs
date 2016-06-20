using UnityEngine.UI;
using System.Collections;
using System;

public interface IMainGeneratorViewController : IViewController
{
    void UpdateMainGenerator(int revenue);
}

public class MainGeneratorViewController : ViewController, IMainGeneratorViewController
{
    public Text BuildingRevenue;

    public void UpdateMainGenerator(int revenue)
    {
        BuildingRevenue.text = "Gold generated : " + revenue.ToString();
    }
}
