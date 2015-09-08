using System;

namespace Microsoft.Test.Diagnostics
{
    public struct CpuComparison
    {
        public TimeSpan KernelTimeChange { get; }
        public TimeSpan UserTimeChange { get; }

        public CpuComparison(TimeSpan kernelTimeChange, TimeSpan userTimeChange)
        {
            KernelTimeChange = kernelTimeChange;
            UserTimeChange = userTimeChange;
        }
    }
}