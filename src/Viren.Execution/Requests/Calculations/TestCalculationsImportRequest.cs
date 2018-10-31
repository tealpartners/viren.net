using System;

namespace Viren.Execution.Requests.Calculations
{
    public class TestCalculationsImportRequest
    {
        public string Project { get; set; }
        public string Model { get; set; }
        public int Version { get; set; }
        public int? Revision { get; set; }
        public string EntryPoint { get; set; }

        public string Comment { get; set; }

        public int TotalCalculations { get; set; }

        public bool? Full { get; set; }
    }

    public class TestCalculationsImportResponse
    {
        public Guid ImportId { get; set; }
    }
}