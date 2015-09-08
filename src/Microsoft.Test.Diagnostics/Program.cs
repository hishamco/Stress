using System;
using System.Security.Cryptography;

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
            Console.WriteLine($" Private: {comparison.Memory.PrivateMemoryChange} ({after.Memory.PrivateMemory})");
            Console.WriteLine($" Virtual: {comparison.Memory.VirtualMemoryChange} ({after.Memory.VirtualMemory})");
            Console.WriteLine($" Working: {comparison.Memory.WorkingSetChange} ({after.Memory.WorkingSet})");
            Console.WriteLine($" Heap   : {comparison.Memory.HeapChange} ({after.Memory.HeapSize})");

            // Force a GC and wait
            Console.WriteLine("Forcing a GC...");
            GC.Collect(0, GCCollectionMode.Forced, blocking: true);
            var afterGC = TraceSnapshot.Capture();

            comparison = afterGC.GetDifference(after);
            Console.WriteLine("Changes: ");
            Console.WriteLine($" Private: {comparison.Memory.PrivateMemoryChange} ({afterGC.Memory.PrivateMemory})");
            Console.WriteLine($" Virtual: {comparison.Memory.VirtualMemoryChange} ({afterGC.Memory.VirtualMemory})");
            Console.WriteLine($" Working: {comparison.Memory.WorkingSetChange} ({afterGC.Memory.WorkingSet})");
            Console.WriteLine($" Heap   : {comparison.Memory.HeapChange} ({afterGC.Memory.HeapSize})");
        }

        private void Alloc(long v)
        {
            byte[] bytes = new byte[v];
            RandomNumberGenerator.Create().GetBytes(bytes);
            Console.WriteLine($"Allocated {bytes.Length} random bytes, including {bytes[0]}");
        }
    }
}
