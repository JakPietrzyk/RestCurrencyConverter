﻿namespace curRESTAPI.Dtos
{
    public record Rate
    {
        public string no { get; set; }
        public string effectiveDate { get; set; }
        public double mid { get; set; }
    }
}
