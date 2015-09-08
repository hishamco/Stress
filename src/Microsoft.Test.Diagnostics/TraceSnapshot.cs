using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Microsoft.Test.Diagnostics
{
    public struct TraceSnapshot
    {
        public TraceSnapshot(DateTime timestampUtc, MemorySnapshot memory, CpuSnapshot cpu) : this()
        {
            TimestampUtc = timestampUtc;
            Memory = memory;
            Cpu = cpu;
        }

        internal TraceComparison GetDifference(TraceSnapshot before)
        {
            return new TraceComparison(
                TimestampUtc - before.TimestampUtc,
                Memory.GetDifference(before.Memory),
                Cpu.GetDifference(before.Cpu));
        }

        public DateTime TimestampUtc { get; }
        public MemorySnapshot Memory { get; }
        public CpuSnapshot Cpu { get; }

        public static TraceSnapshot Capture()
        {
            var process = Process.GetCurrentProcess();

            return new TraceSnapshot(
                DateTime.UtcNow,
                MemorySnapshot.Capture(process),
                CpuSnapshot.Capture(process));
        }
    }
}
