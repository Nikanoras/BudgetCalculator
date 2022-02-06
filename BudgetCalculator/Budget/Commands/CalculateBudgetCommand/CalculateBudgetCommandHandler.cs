namespace BudgetCalculator.Budget.Commands.CalculateBudgetCommand;

internal class CalculateBudgetCommandHandler
{
    public CalculateBudgetCommandResult Handle(CalculateBudgetCommand command)
    {
        //TODO: Handle parsing issues

        var netSalary = GetNetSalary(command.GrossSalary);

        var savings = RoundDecimalToMoneyStandard(netSalary * command.SavingsPercentage);
        var needs = RoundDecimalToMoneyStandard(netSalary * command.NeedsPercentage);
        var wants = RoundDecimalToMoneyStandard(netSalary * command.WantsPercentage);

        return new CalculateBudgetCommandResult
        {
            Savings = savings,
            Needs = needs,
            Wants = wants,
            NetSalary = netSalary
        };



        static decimal RoundDecimalToMoneyStandard(decimal amount)
        {
            return decimal.Round(amount, 2);
        }

        decimal GetNetSalary(decimal result)
        {
            var incomeTax = RoundDecimalToMoneyStandard(result * 0.20M);
            var compulsoryHealthInsurance = RoundDecimalToMoneyStandard(result * 0.0698M);
            var socialSecurityTax = RoundDecimalToMoneyStandard(result * 0.1252M);
            var mandatoryRetirementSavings = RoundDecimalToMoneyStandard(result * 0.03M);
            return result - incomeTax - compulsoryHealthInsurance -
                   socialSecurityTax - mandatoryRetirementSavings;
        }

       
    }
}