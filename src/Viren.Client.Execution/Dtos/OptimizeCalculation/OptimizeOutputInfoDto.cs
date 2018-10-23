namespace Viren.Client.Execution.Dtos.OptimizeCalculation
{
    public class OptimizeOutputInfoDto
    {
        public string ResultName { get; set; }
        public OptimizeOutputStrategyDto OptimizeOutputStrategy { get; set; }
        public decimal OutputHintValue { get; set; }
        public decimal AllowedMargin { get; set; }
    }
}