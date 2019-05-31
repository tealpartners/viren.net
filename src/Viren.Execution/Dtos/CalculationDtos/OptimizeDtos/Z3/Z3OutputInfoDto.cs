namespace Viren.Execution.Dtos.CalculationDtos.OptimizeDtos.Z3
{
    public class Z3OutputInfoDto
    {
        public string ResultName { get; set; }
        public NumericOptimizationOptionsDto Options { get; set; }
        public Z3Strategy Strategy { get; set; }
        public decimal Weight { get; set; }
    }
}