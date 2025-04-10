namespace BattleSimulation.Contracts;


public class Battle
{

    private readonly IRepository repo;

    public Battle(IRepository repository)
    {
        repo = repository;
    }

    public async Task MainMenu()
    {
        Console.WriteLine("\nTransformer Manager");
        Console.WriteLine("1. Add Transformer");
        Console.WriteLine("2. Remove Transformer");
        Console.WriteLine("3. Battle Transformers");
        Console.WriteLine("4. Get Win/Loss Rate");
        Console.WriteLine("5. Display Transformers");
        Console.WriteLine("6. Exit");
        Console.Write("Choose an option: ");
        string option = Console.ReadLine();
        switch (option)
        {
            case "1":
                await AddTransformer();
                break;
            case "2":
                await RemoveTransformer();
                break;
            case "3":
                await BattleTransformers();
                break;
            case "4":
                await GetWinLossRate();
                break;
            case "5":
                await DisplayTransformers();
                break;
            case "6":
                throw new OperationCanceledException();
            default:
                Console.WriteLine("Invalid option. Please try again.");
                await MainMenu();
                break;
        }
    }

    public Task AddTransformer() => Task.CompletedTask;
    public Task RemoveTransformer() => Task.CompletedTask;
    public Task BattleTransformers() => Task.CompletedTask;
    public Task GetWinLossRate() => Task.CompletedTask;
    public Task DisplayTransformers() => Task.CompletedTask;

}
