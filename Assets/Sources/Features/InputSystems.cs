using UnityEngine;
using System.Collections.Generic;
using Entitas;
using System;

public class IncrementTickSystem : IInitializeSystem, IExecuteSystem, ISetPool
{

    Pool _pool;

    public void SetPool(Pool pool)
    {
        _pool = pool;
    }

    public void Initialize()
    {
        _pool.SetTick(0);
    }

    public void Execute()
    {
        _pool.ReplaceTick(_pool.tick.Value + 1);
    }
}

public class HandleGenerateGoldInputSystem : IReactiveSystem, ISetPool
{
    Pool _pool;

    public TriggerOnEvent trigger
    {
        get
        {
            return Matcher.GenerateGoldInput.OnEntityAdded();
        }
    }

    public void SetPool(Pool pool)
    {
        _pool = pool;
    }

    public void Execute(List<Entity> entities)
    {
        foreach (var e in entities)
        {
            _pool.playerEntity.ReplaceMoney(_pool.playerEntity.money.Amount + e.generateGoldInput.Amount);

            _pool.DestroyEntity(e);
        }
    }
}

public class HandleBuyBuildingInputSystem : IReactiveSystem, ISetPool
{
    Pool _pool;

    public TriggerOnEvent trigger
    {
        get
        {
            return Matcher.BuyBuildingInput.OnEntityAdded();
        }
    }

    public void Execute(List<Entity> entities)
    {
        foreach(var e in entities)
        {
            Debug.Log("Trying to buy a building for " + e.buyBuildingInput.Cost + " // Money : " + _pool.playerEntity.money.Amount );

            if(_pool.playerEntity.money.Amount > e.buyBuildingInput.Cost)
            {
                _pool.CreateEntity()
                    .AddBuidling(e.buidling.Type)
                    .AddMoney(e.money.Amount)
                    .AddGenerator(e.generator.Frequency);

                _pool.playerEntity.ReplaceMoney(_pool.playerEntity.money.Amount - e.buyBuildingInput.Cost);
            }
        }
    }

    public void SetPool(Pool pool)
    {
        _pool = pool;
    }
}