namespace Microsoft.AspNet.StressFramework
{
	public class StressTestIterationContext
	{
		private List<DataPoint> _recordings = new List<DataPoint>();
		
		/// <summary>
		/// Record a data point
		/// </summary>
		public void Record<T>(T data)
		{
			var dataPoint = DataPoint.Create(data);
			_recordings.Add(dataPoint);
		}
	}
}