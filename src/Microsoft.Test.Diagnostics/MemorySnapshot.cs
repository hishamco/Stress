using System;
using System.Diagnostics;

namespace Microsoft.Test.Diagnostics
{
    public struct MemorySnapshot
    {
        public Bytes PrivateMemory { get; }
        public Bytes VirtualMemory { get; }
        public Bytes WorkingSet { get; }

        public MemorySnapshot(Bytes virtualMemorySize64, Bytes privateMemorySize64, Bytes workingSet64)
        {
            VirtualMemory = virtualMemorySize64;
            PrivateMemory = privateMemorySize64;
            WorkingSet = workingSet64;
        }

        internal static MemorySnapshot Capture(Process process)
        {
            return new MemorySnapshot(
                process.VirtualMemorySize64,
                process.PrivateMemorySize64,
                process.WorkingSet64);
        }

        internal MemoryComparison GetDifference(MemorySnapshot before)
        {
            return new MemoryComparison(
                PrivateMemory - before.PrivateMemory,
                VirtualMemory - before.VirtualMemory,
                WorkingSet - before.WorkingSet);
        }
    }
}