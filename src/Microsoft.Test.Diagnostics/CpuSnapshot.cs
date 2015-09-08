using System;
using System.Diagnostics;

namespace Microsoft.Test.Diagnostics
{
    public struct CpuSnapshot
    {
        public TimeSpan KernelTime { get; }
        public TimeSpan UserTime { get; }

        public CpuSnapshot(TimeSpan userProcessorTime, TimeSpan privilegedProcessorTime)
        {
            UserTime = userProcessorTime;
            KernelTime = privilegedProcessorTime;
        }

        internal static CpuSnapshot Capture(Process process)
        {
            return new CpuSnapshot(
                process.UserProcessorTime,
                process.PrivilegedProcessorTime);
        }

        internal CpuComparison GetDifference(CpuSnapshot before)
        {
            return new CpuComparison(
                KernelTime - before.KernelTime,
                UserTime - before.UserTime);
        }
    }
}