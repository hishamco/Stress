namespace Microsoft.AspNet.StressFramework
{
	public class StressTestIterationContext
	{
		private List<DataPoint> _recordings = new List<DataPoint>();
		private List<ICollector> _collectors = new List<ICollector>();
		private Stopwatch _iterationTime = new Stopwatch();
		
		/// <summary>
		/// Record a data point
		/// </summary>
		public void Record<T>(T data)
		{
			var dataPoint = DataPoint.Create(data);
			_recordings.Add(dataPoint);
		}
		
		public void BeginIteration()
		{
			foreach(var collector in _collectors)
			{
				_collectors.BeginIteration(this);
			}
			
			_iterationTime.Start();
		}
		
		public void EndIteration()
		{
			_iterationTime.Stop();
			
			foreach(var collector in _collectors)
			{
				_collectors.EndIteration(this);
			}
		}
	}
}