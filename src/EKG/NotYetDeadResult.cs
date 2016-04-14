using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace EKG
{
    public class ElapsedTime
    {

        [JsonProperty("days")]
        public int Days { get; set; }

        [JsonProperty("hours")]
        public int Hours { get; set; }

        [JsonProperty("minutes")]
        public int Minutes { get; set; }

        [JsonProperty("seconds")]
        public int Seconds { get; set; }

        [JsonProperty("milliseconds")]
        public int Milliseconds { get; set; }
    }

    public class Result
    {

        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("elapsedTime")]
        public ElapsedTime ElapsedTime { get; set; }
    }

    public class NotYetDeadResult
    {

        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("results")]
        public IList<Result> Results { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("notDeadYet")]
        public string NotDeadYet { get; set; }
    }
}
