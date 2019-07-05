namespace Viren.Execution.Dtos.CalculationDtos.OptimizeDtos.Z3
{
    public class Z3InputInfoDto
    {
        public string Parameter { get; set; }
        public NumericOptimizationOptionsDto NumericOptions { get; set; }
        public DateTimeOptimizationOptionsDto DateTimeOptions { get; set; }
        public StringOptimizationOptionsDto StringOptions { get; set; }
    }
}