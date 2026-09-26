namespace SysMonitorApp
{
    public class ProcessModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double MemoryMB { get; set; }

        public ProcessModel(int id, string name, double memoryMb)
        {
            Id = id;
            Name = name;
            MemoryMB = memoryMb;
        }
    }
}