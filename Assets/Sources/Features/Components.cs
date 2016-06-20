using Entitas;
using Entitas.CodeGenerator;

[SingleEntity]
public class PlayerComponent : IComponent
{

}

[SingleEntity]
public class MainGeneratorComponent : IComponent
{

}

public class MoneyComponent : IComponent
{
    public int Amount;
}

public class CostComponent : IComponent
{
    public int Amount;
}

public class BuidlingComponent : IComponent
{
    public BuildingType Type;
}

public class GeneratorComponent : IComponent
{
    /// <summary>
    /// Expressed in ticks
    /// </summary>
    public int Frequency;
    /// <summary>
    /// Expressed in money amount
    /// </summary>
    public int Revenue;
}

public class ViewComponent : IComponent
{
    public ViewController View;
}

[SingleEntity]
public class TickComponent : IComponent
{
    public ulong Value;
}

public class WaitComponent : IComponent
{
    public int Duration;
}

// INPUT

public class GenerateGoldInputComponent : IComponent {
    public int Amount;
}

public class BuyBuildingInputComponent : IComponent
{
    public int Cost;
}