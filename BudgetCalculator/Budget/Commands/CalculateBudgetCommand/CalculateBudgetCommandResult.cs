namespace BudgetCalculator.Budget.Commands.CalculateBudgetCommand
{
    internal class CalculateBudgetCommandResult
    {
        public decimal Savings { get; set; }
        public decimal Needs { get; set; }
        public decimal Wants { get; set; }
        public decimal NetSalary { get; set; }
    }
}
