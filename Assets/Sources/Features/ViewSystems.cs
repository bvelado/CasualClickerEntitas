using Entitas;
using System.Collections.Generic;
using System;

public class UpdateGoldAmountViewSystem : IReactiveSystem, ISetPool
{
    Pool _pool;

    public TriggerOnEvent trigger
    {
        get
        {
            return Matcher.AllOf(Matcher.Player, Matcher.Money).OnEntityAdded();
        }
    }

    public void Execute(List<Entity> entities)
    {
        foreach(var e in entities)
        {
            if (e.hasView)
                e.view.View.UpdateContent();
        }
    }

    public void SetPool(Pool pool)
    {
        _pool = pool;
    }
}

public class UpdateBuildingViewSystem : IReactiveSystem, ISetPool
{
    Pool _pool;
    Group _buildings;

    public TriggerOnEvent trigger
    {
        get
        {
            return Matcher.AllOf(Matcher.Buidling, Matcher.Money, Matcher.Generator).NoneOf(Matcher.BuyBuildingInput).OnEntityAdded();
        }
    }

    public void Execute(List<Entity> entities)
    {
        foreach (var e in entities)
        {
            int number = 0;
            int moneyPer60Ticks = 0;

            foreach (var building in _buildings.GetEntities())
            {
                if (building.buidling.Type == e.buidling.Type)
                {
                    number++;
                    moneyPer60Ticks += building.money.Amount * 60 / building.generator.Frequency;
                }
            }

            ((IBuildingViewController)PoolExtension.GetBuildingView(e.buidling.Type)).UpdateBuilding(number, moneyPer60Ticks);
        }
    }

    public void SetPool(Pool pool)
    {
        _pool = pool;
        _buildings = pool.GetGroup(Matcher.AllOf(Matcher.Buidling, Matcher.Money, Matcher.Generator).NoneOf(Matcher.BuyBuildingInput));
    }
}