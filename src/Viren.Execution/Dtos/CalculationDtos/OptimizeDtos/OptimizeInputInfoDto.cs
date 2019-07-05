namespace Viren.Execution.Dtos.CalculationDtos.OptimizeDtos
{
    public class OptimizeInputInfoDto
    {
        public string RootParameterName { get; set; }
        public NumericOptimizationOptionsDto NumericOptimizationOptions { get; set; }
        public DateTimeOptimizationOptionsDto DateTimeOptimizationOptions { get; set; }
        public StringOptimizationOptionsDto StringOptimizationOptions { get; set; }
    }
}