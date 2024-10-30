namespace LabCalculator.Models
{
    public class CalculatorModel
    {
        public double FirstOperand { get; set; }
        public required string Operation { get; set; }

        // Второй операнд может быть необязательным
        public double? SecondOperand { get; set; } // Изменили на Nullable
    }
}
