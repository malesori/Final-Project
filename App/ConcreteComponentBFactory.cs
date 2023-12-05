public class ConcreteComponentBFactory : IComponentFactory
{
    public IComponent CreateComponent()
    {
        return new ConcreteComponentB();
    }
}
