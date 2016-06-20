using Entitas;
using System.Collections.Generic;
using System;

#region Player view update

public class UpdatePlayerGoldAmountViewSystem : IReactiveSystem, ISetPool
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
                ((IPlayerGoldViewController)e.view.View).UpdateGoldAmount(e.money.Amount);
        }
    }

    public void SetPool(Pool pool)
    {
        _pool = pool;
    }
}

public class UpdatePlayerGoldRevenueViewSystem : IReactiveSystem, ISetPool
{
    Pool _pool;

    public TriggerOnEvent trigger
    {
        get
        {
            return Matcher.AllOf(Matcher.Generator, Matcher.Money).OnEntityAdded();
        }
    }

    public void Execute(List<Entity> entities)
    {
        var totalRevenue = 0;

        foreach (var e in entities)
        {
            totalRevenue += e.money.Amount;
        }

        ((IPlayerGoldViewController)_pool.playerEntity.view.View).UpdateGoldRevenue(totalRevenue);
    }

    public void SetPool(Pool pool)
    {
        _pool = pool;
    }
}

#endregion

public class UpdateBuildingCostViewSystem : IReactiveSystem, ISetPool
{
    Pool _pool;

    public TriggerOnEvent trigger
    {
        get
        {
            return Matcher.AllOf(Matcher.Buidling, Matcher.Cost).NoneOf(Matcher.BuyBuildingInput).OnEntityAdded();
        }
    }

    public void Execute(List<Entity> entities)
    {
        foreach(var e in entities)
        {

        }
    }

    public void SetPool(Pool pool)
    {
        _pool = pool;
    }
}

public class UpdateBuildingRevenueViewSystem : IReactiveSystem, ISetPool
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
            int moneyPer60Ticks = 0;

            foreach (var building in _buildings.GetEntities())
            {
                if (building.buidling.Type == e.buidling.Type)
                {
                    moneyPer60Ticks += building.money.Amount * 60 / building.generator.Frequency;
                }
            }

            ((IBuildingViewController)PoolExtension.GetBuildingView(e.buidling.Type)).UpdateRevenue(moneyPer60Ticks);

        }
    }

    public void SetPool(Pool pool)
    {
        _pool = pool;
        _buildings = pool.GetGroup(Matcher.AllOf(Matcher.Buidling, Matcher.Money, Matcher.Generator).NoneOf(Matcher.BuyBuildingInput));
    }
}

#region Main generator view update

public class UpdateMainGeneratorGoldRevenueSystem : IReactiveSystem, ISetPool
{
    Pool _pool;

    public TriggerOnEvent trigger
    {
        get
        {
            return Matcher.AllOf(Matcher.MainGenerator, Matcher.Money, Matcher.Generator).OnEntityAdded();
        }
    }

    public void Execute(List<Entity> entities)
    {
        foreach(var e in entities)
        {
            ((IMainGeneratorViewController)_pool.mainGeneratorEntity.view.View).UpdateMainGenerator(e.money.Amount);
        }
    }

    public void SetPool(Pool pool)
    {
        _pool = pool;
    }
}

#endregion