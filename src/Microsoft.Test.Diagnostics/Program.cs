using System;

namespace Microsoft.Test.Diagnostics
{
    public class Program
    {
        public void Main(string[] args)
        {
            var before = TraceSnapshot.Capture();
            Alloc(4 * 1024 * 1024);
            var after = TraceSnapshot.Capture();

            var comparison = after.GetDifference(before);
            Console.WriteLine("Changes: ");
            Console.WriteLine($" Private: {comparison.Memory.PrivateMemoryChange}");
            Console.WriteLine($" Virtual: {comparison.Memory.VirtualMemoryChange}");
            Console.WriteLine($" Working: {comparison.Memory.WorkingSetChange}");
        }

        private void Alloc(long v)
        {
            byte[] bytes = new byte[v];
        }
    }
}
