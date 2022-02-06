using BudgetCalculator.Budget.Commands.CalculateBudgetCommand;

namespace BudgetCalculator;

public class Program
{
    private static readonly decimal _savingsPercentage = 0.37M;
    private static readonly decimal _needsPercentage = 0.36M;
    private static readonly decimal _wantsPercentage = 0.27M;

    public static void Main()
    {
        var isRunning = true;
        Console.WriteLine("Welcome to the budget calculator");
        while (isRunning)
        {
            var topCommand = Console.ReadLine();
            switch (topCommand)
            {
                case "budget":
                    CalculateAndPrintBudget();
                    break;
                case "quit":
                    isRunning = false;
                    Console.WriteLine();
                    Console.WriteLine("Bye");
                    break;
                case "help":
                    Console.WriteLine();
                    Console.WriteLine("budget - calculate the budget");
                    Console.WriteLine("q - exit");
                    break;
            }
        }
    }

    private static void CalculateAndPrintBudget()
    {
        var grossSalary = GetGrossSalaryInput();
        var budget = CalculateBudget(grossSalary);
        PrintCalculateBudgetResult(budget);

        static decimal GetGrossSalaryInput()
        {
            Console.WriteLine("Provide the gross salary:");
            decimal.TryParse(Console.ReadLine(), out var grossSalary);
            return grossSalary;
        }

        static CalculateBudgetCommandResult CalculateBudget(decimal grossSalary)
        {
            var calculateBudgetCommandHandler = new CalculateBudgetCommandHandler();
            var command = calculateBudgetCommandHandler.Handle(new CalculateBudgetCommand
            {
                SavingsPercentage = _savingsPercentage,
                NeedsPercentage = _needsPercentage,
                WantsPercentage = _wantsPercentage,
                GrossSalary = grossSalary
            });
            return command;
        }

        static void PrintCalculateBudgetResult(CalculateBudgetCommandResult command)
        {
            Console.WriteLine("Budget:");
            PrintResultText("Savings", _savingsPercentage, command.Savings);
            PrintResultText("Needs", _needsPercentage, command.Needs);
            PrintResultText("Wants", _wantsPercentage, command.Wants);
            PrintResultText("NET salary",
                _savingsPercentage + _needsPercentage + _wantsPercentage,
                command.NetSalary);

            static void PrintResultText(string type, decimal percentage, decimal sum)
            {
                Console.WriteLine($"{type}({percentage * 100}%): {sum}");
            }
        }
    }
}