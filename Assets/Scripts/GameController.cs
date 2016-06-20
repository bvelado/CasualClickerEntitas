using Entitas;
using UnityEngine;

public class GameController : MonoBehaviour
{

    Systems _systems;

    void Start()
    {
        Random.seed = 42;

        _systems = createSystems(Pools.pool);
        _systems.Initialize();
    }

    void Update()
    {
        _systems.Execute();
    }

    Systems createSystems(Pool pool)
    {
        return new Feature("Systems")
            // Initialization
            .Add(pool.CreateSystem<InitializeGameSystem>())

            // View
            .Add(pool.CreateSystem<UpdatePlayerGoldAmountViewSystem>())
            .Add(pool.CreateSystem<UpdatePlayerGoldRevenueViewSystem>())

            .Add(pool.CreateSystem<UpdateBuildingCostViewSystem>())
            .Add(pool.CreateSystem<UpdateBuildingRevenueViewSystem>())

            .Add(pool.CreateSystem<UpdateMainGeneratorGoldRevenueSystem>())

            // Input
            .Add(pool.CreateSystem<HandleGenerateGoldInputSystem>())
            .Add(pool.CreateSystem<HandleBuyBuildingInputSystem>())

            // Tick
            .Add(pool.CreateSystem<IncrementTickSystem>())
            .Add(pool.CreateSystem<DecrementWaitTickSystem>())

            // Money
            .Add(pool.CreateSystem<GenerateMoneySystem>());
    }
}