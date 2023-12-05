class Program
{
    static void Main()
    {
        PluginLoader pluginLoader = new PluginLoader();

        // Dynamically add new component factories (plugins)
        pluginLoader.AddComponentFactory(new ConcreteComponentAFactory());
        pluginLoader.AddComponentFactory(new ConcreteComponentBFactory());

        // Execute all components
        pluginLoader.LoadAndExecuteComponents();
    }
}
