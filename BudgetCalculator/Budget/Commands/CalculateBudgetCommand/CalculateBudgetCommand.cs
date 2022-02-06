namespace BudgetCalculator.Budget.Commands.CalculateBudgetCommand
{
    internal class CalculateBudgetCommand
    {
        public decimal GrossSalary { get; set; }
        public decimal SavingsPercentage { get; set; }
        public decimal NeedsPercentage { get; set; }
        public decimal WantsPercentage { get; set; }
    }
}
