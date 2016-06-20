using UnityEngine;
using Entitas;
using System;
using System.Collections.Generic;

public class InitializeGameSystem : IInitializeSystem, ISetPool
{
    Pool _pool;

    public void Initialize()
    {

        // Create the player
        var playerEntity = _pool.CreateEntity()
            .IsPlayer(true)
            .AddMoney(0);

        UIContainer.Instance.PlayerGoldAmount.gameObject.Link(playerEntity, _pool);
        playerEntity.AddView(UIContainer.Instance.PlayerGoldAmount);

        // Create a base money generator
        var mainGenerator = _pool.CreateEntity()
            .IsMainGenerator(true)
            .AddMoney(10)
            .AddGenerator(60);

        UIContainer.Instance.MainGenerator.gameObject.Link(mainGenerator, _pool);
        mainGenerator.AddView(UIContainer.Instance.MainGenerator);

        var cornerShop = _pool.CreateEntity()
            .AddBuidling(BuildingType.CornerShop)
            .AddCost(100);
    }

    public void SetPool(Pool pool)
    {
        _pool = pool;
    }
}

public class GenerateMoneySystem : IReactiveSystem, ISetPool
{
    Pool _pool;
    Group _generators;

    public TriggerOnEvent trigger
    {
        get
        {
            return Matcher.Tick.OnEntityAdded();
        }
    }

    public void Execute(List<Entity> entities)
    {
        foreach (var e in _generators.GetEntities())
        {
            _pool.playerEntity.ReplaceMoney(_pool.playerEntity.money.Amount + e.money.Amount);
            e.AddWait(e.generator.Frequency);
        }
    }

    public void SetPool(Pool pool)
    {
        _pool = pool;
        _generators = pool.GetGroup(Matcher.AllOf(Matcher.Money, Matcher.Generator).NoneOf(Matcher.Wait, Matcher.BuyBuildingInput));
    }
}

public class DecrementWaitTickSystem : IReactiveSystem, ISetPool
{
    Pool _pool;
    Group _tickWaiters;

    public TriggerOnEvent trigger
    {
        get
        {
            return Matcher.Tick.OnEntityAdded();
        }
    }

    public void SetPool(Pool pool)
    {
        _pool = pool;
        _tickWaiters = pool.GetGroup(Matcher.Wait);
    }

    public void Execute(List<Entity> entities)
    {
        foreach (var e in _tickWaiters.GetEntities())
        {
            e.wait.Duration--;

            if (e.wait.Duration < 0)
                e.RemoveWait();
        }
    }
}