namespace Microsoft.Test.Diagnostics
{
    public struct MemoryComparison
    {
        public Bytes PrivateMemoryChange { get; }
        public Bytes VirtualMemoryChange { get; }
        public Bytes WorkingSetChange { get; }

        public MemoryComparison(Bytes privateMemoryChange, Bytes virtualMemoryChange, Bytes workingSetChange)
        {
            PrivateMemoryChange = privateMemoryChange;
            VirtualMemoryChange = virtualMemoryChange;
            WorkingSetChange = workingSetChange;
        }
    }
}