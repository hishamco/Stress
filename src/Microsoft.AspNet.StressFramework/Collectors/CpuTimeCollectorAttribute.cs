namespace Microsoft.AspNet.StressFramework.Collectors
{
	public class CpuTimeCollectorAttribute : Attribute, ICollector
	{
		public void Initialize()
		{
			
		}
		
		public void BeginIteration(StressTestIterationContext iteration)
		{
			iteration.Record(CpuTime.Capture())
		}
		
		public void EndIteration(StressTestIterationContext iteration)
		{
			iteration.Record(CpuTime.Capture());
		}
	}
}