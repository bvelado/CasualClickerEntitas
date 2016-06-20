using UnityEngine;
using System.Collections;

public class BuyNewBuilding : MonoBehaviour {

    [Header("Cost")]
    public int Cost;

    [Header("Building")]
    public BuildingType Type;

    public void ButtonPressed()
    {

        Pools.pool.CreateEntity()
            .AddBuyBuildingInput(Cost)
            .AddBuidling(Type);
    }
}
