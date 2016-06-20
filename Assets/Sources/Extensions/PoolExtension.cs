using UnityEngine;
using System.Collections;
using Entitas;

public enum BuildingType
{
    CornerShop,
    GasStation,
    Factory
}

public static class PoolExtension {

    public const int BUILDING_CORNERSHOP_FREQUENCY = 60;
    public const int BUILDING_GASSTATION_FREQUENCY = 60;
    public const int BUILDING_FACTORY_FREQUENCY = 120;

    public const int BUILDING_CORNERSHOP_REVENUE = 20;
    public const int BUILDING_GASSTATION_REVENUE = 50;
    public const int BUILDING_FACTORY_REVENUE = 180;

    public static IViewController GetBuildingView(BuildingType Type)
    {
        switch (Type)
        {
            case BuildingType.CornerShop:

                return UIContainer.Instance.CornerShop;

            case BuildingType.GasStation:

                return UIContainer.Instance.GasStation;

            case BuildingType.Factory:

                return UIContainer.Instance.Factory;

            default:

                return null;
        }
    }

    public static void CreateNewBuidling(BuildingType Type, Pool Pool)
    {
        Pool.CreateEntity()
            .AddBuidling(Type);
            //.AddGenerator(GetBuildingFrequency)
    }

    public static int GetBuildingFrequency(BuildingType Type)
    {
        switch (Type)
        {
            case BuildingType.CornerShop:

                return BUILDING_CORNERSHOP_FREQUENCY;

            case BuildingType.GasStation:

                return BUILDING_GASSTATION_FREQUENCY;

            case BuildingType.Factory:

                return BUILDING_FACTORY_FREQUENCY;

            default:

                return 0;

        }
    }

    public static int GetBuildingRevenue(BuildingType Type)
    {
        switch (Type)
        {
            case BuildingType.CornerShop:

                return BUILDING_CORNERSHOP_REVENUE;

            case BuildingType.GasStation:

                return BUILDING_GASSTATION_REVENUE;

            case BuildingType.Factory:

                return BUILDING_FACTORY_REVENUE;

            default:

                return 0;

        }
    }
}
