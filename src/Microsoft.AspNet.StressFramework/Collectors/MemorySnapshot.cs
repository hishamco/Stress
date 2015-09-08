namespace Microsoft.AspNet.StressFramework
{
	public class MemorySnapshot
	{
		public long HeapMemoryBytes { get; }
		public long WorkingSet { get; }
		public long PrivateBytes { get; }
		
		public MemorySnapshot(long heapMemoryBytes, long workingSet, long privateBytes)
		{
			HeapMemoryBytes = heapMemoryBytes;
			WorkingSet = workingSet;
			PrivateBytes = privateBytes;
		}
		
		public static MemorySnapshot Capture()
		{
			var me = Process.GetCurrentProcess();
			return new MemorySnapshot(
				GC.GetTotalMemory(forceFullGeneration: false),
				me.WorkingSet64,
				me.PrivateMemorySize64);
		}
	}
}