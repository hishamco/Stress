namespace Microsoft.AspNet.StressFramework.Collectors
{
	public class TotalMemoryCollectorAttribute : Attribute, ICollector
	{
		public void Initialize()
		{
			
		}
		
		public void BeginIteration(StressTestIterationContext iteration)
		{
			iteration.Record(MemorySnapshot.Capture());
		}
		
		public void EndIteration(StressTestIterationContext iteration)
		{
			iteration.Record(MemorySnapshot.Capture());
		}
	}
}