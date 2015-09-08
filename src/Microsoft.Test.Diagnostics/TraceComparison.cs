using System;

namespace Microsoft.Test.Diagnostics
{
    public struct TraceComparison
    {
        public CpuComparison Cpu { get; }
        public MemoryComparison Memory { get; }
        public TimeSpan Duration { get; }

        public TraceComparison(TimeSpan duration, MemoryComparison memory, CpuComparison cpu)
        {
            Duration = duration;
            Memory = memory;
            Cpu = cpu;
        }
    }
}