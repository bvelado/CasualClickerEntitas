using UnityEngine;
using System.Collections;

public enum BuildingType
{
    CornerShop,
    GasStation,
    Factory
}

public static class PoolExtension {
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
}
