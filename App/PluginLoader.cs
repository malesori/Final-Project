public class PluginLoader
{
    private readonly List<IComponentFactory> componentFactories;

    public PluginLoader()
    {
        componentFactories = new List<IComponentFactory>();
    }

    public void AddComponentFactory(IComponentFactory componentFactory)
    {
        componentFactories.Add(componentFactory);
    }

    public void LoadAndExecuteComponents()
    {
        foreach (var factory in componentFactories)
        {
            try
            {
                IComponent component = factory.CreateComponent();
                component.Execute();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error executing component: {ex.Message}");
            }
        }
    }
}
