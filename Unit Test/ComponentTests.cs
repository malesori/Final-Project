using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

[TestClass]
public class ComponentTests
{
    [TestMethod]
    public void ExecuteConcreteComponentA_ShouldPrintMessage()
    {
        // Arrange
        IComponent component = new ConcreteComponentA();

        // Act
        string consoleOutput = CaptureConsoleOutput(() => component.Execute());

        // Assert
        Assert.IsTrue(consoleOutput.Contains("Executing ConcreteComponentA"));
    }

    [TestMethod]
    public void ExecuteConcreteComponentB_ShouldPrintMessage()
    {
        // Arrange
        IComponent component = new ConcreteComponentB();

        // Act
        string consoleOutput = CaptureConsoleOutput(() => component.Execute());

        // Assert
        Assert.IsTrue(consoleOutput.Contains("Executing ConcreteComponentB"));
    }

    [TestMethod]
    public void LoadAndExecuteComponents_WithValidFactories_ShouldNotThrowException()
    {
        // Arrange
        PluginLoader pluginLoader = new PluginLoader();
        pluginLoader.AddComponentFactory(new ConcreteComponentAFactory());
        pluginLoader.AddComponentFactory(new ConcreteComponentBFactory());

        // Act and Assert
        Assert.IsFalse(CaptureConsoleOutput(() => pluginLoader.LoadAndExecuteComponents()).Contains("Error executing component"));
    }

    private string CaptureConsoleOutput(Action action)
    {
        // Redirect console output to a string
        using (var consoleOutput = new System.IO.StringWriter())
        {
            Console.SetOut(consoleOutput);

            // Perform the action, capturing the output
            action();

            // Return the captured output
            return consoleOutput.ToString();
        }
    }
}
