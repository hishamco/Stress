namespace Microsoft.Test.Diagnostics
{
    public struct MemoryComparison
    {
        public Bytes PrivateMemoryChange { get; }
        public Bytes VirtualMemoryChange { get; }
        public Bytes WorkingSetChange { get; }
        public Bytes HeapChange { get; }

        public MemoryComparison(Bytes privateMemoryChange, Bytes virtualMemoryChange, Bytes workingSetChange, Bytes heapChange)
        {
            PrivateMemoryChange = privateMemoryChange;
            VirtualMemoryChange = virtualMemoryChange;
            WorkingSetChange = workingSetChange;
            HeapChange = heapChange;
        }
    }
}