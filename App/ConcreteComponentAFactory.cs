public class ConcreteComponentAFactory : IComponentFactory
{
    public IComponent CreateComponent()
    {
        return new ConcreteComponentA();
    }
}
