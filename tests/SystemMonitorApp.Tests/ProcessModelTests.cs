using SysMonitorApp;

namespace SystemMonitorApp.Tests;

public class ProcessModelTests
{
    [Fact]
    public void Constructor_SetsProperties()
    {
        var process = new ProcessModel(123, "notepad", 42.5);

        Assert.Equal(123, process.Id);
        Assert.Equal("notepad", process.Name);
        Assert.Equal(42.5, process.MemoryMB);
    }
}
