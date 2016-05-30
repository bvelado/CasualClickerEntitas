using UnityEngine;
using System.Collections;

public class BuyNewBuilding : MonoBehaviour {

    [Header("Cost")]
    public int Cost;

    [Header("Building")]
    public BuildingType Type;
    public int MoneyAmount;
    public int Frequency;

    public void ButtonPressed()
    {

        Pools.pool.CreateEntity()
            .AddBuyBuildingInput(Cost)
            .AddBuidling(Type)
            .AddMoney(MoneyAmount)
            .AddGenerator(Frequency);
    }
}
