using System.Collections.Generic;

namespace ShareWatch.API.Models
{
    public class TimeSeriesIntradayData
    {
        public TimeSeriesMetaData MetaData { get; set; } = new TimeSeriesMetaData();
        public List<TimeSeriesData> Data { get; set; } = new List<TimeSeriesData>();
    }
}
