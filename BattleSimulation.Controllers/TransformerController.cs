namespace BattleSimulation.Controllers
{
    using BattleSimulation.Contracts;
    using BattleSimulation.Manager;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class TransformerController
    {
        private TransformerManager manager;

        public TransformerController(TransformerManager mgr)
        {
            manager = mgr;
        }

        public async Task Start()
        {
            await MainMenu();
        }

        private async Task MainMenu()
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
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    await MainMenu();
                    break;
            }
        }
        private async Task AddTransformer()
        {
            try
            {
                Console.Write("Enter name: ");
                string name = Console.ReadLine();
                Console.Write("Enter faction (Autobot/Decepticon): ");
                string faction = Console.ReadLine();
                Console.Write("Enter strength: ");
                if (!int.TryParse(Console.ReadLine(), out int strength))
                {
                    Console.WriteLine("Invalid strength value. Please enter a valid number.");
                    await MainMenu();
                    return;
                }

                Transformer transformer = new Transformer
                {
                    Id = Guid.NewGuid(),
                    Name = name,
                    Faction = faction,
                    Strength = strength,
                    Wins = 0,
                    Losses = 0
                };

                await manager.AddTransformer(transformer);
                Console.WriteLine($"{name} added.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            finally
            {
                await MainMenu();
            }
        }

        private async Task RemoveTransformer()
        {
            try
            {
                Console.Write("Enter name of transformer to remove: ");
                string name = Console.ReadLine();
                var transformer = (await manager.GetAllTransformers()).FirstOrDefault(t => t == name);
                if (transformer != null)
                {
                    await manager.RemoveTransformer(new Transformer { Name = name });
                    Console.WriteLine($"{name} removed.");
                }
                else
                {
                    Console.WriteLine("Transformer not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            finally
            {
                await MainMenu();
            }
        }
        private async Task BattleTransformers()
        {
            try
            {
                Console.Write("Enter name of first transformer: ");
                string name1 = Console.ReadLine();
                Console.Write("Enter name of second transformer: ");
                string name2 = Console.ReadLine();
                var transformer1 = (await manager.GetAllTransformers()).FirstOrDefault(t => t == name1);
                var transformer2 = (await manager.GetAllTransformers()).FirstOrDefault(t => t == name2);
                if (transformer1 != null && transformer2 != null)
                {
                    var result = await manager.TransformersBattleResult(new Transformer { Name = name1 }, new Transformer { Name = name2 });
                    if (result != null)
                    {
                        if (result.IsTie)
                        {
                            Console.WriteLine("It's a tie!");
                        }
                        else
                        {
                            Console.WriteLine($"{result.Winner.Name} wins! {result.Loser.Name} loses.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("One or both transformers not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            finally
            {
                await MainMenu();
            }
        }
        private async Task GetWinLossRate()
        {
            try
            {
                Console.Write("Enter name of transformer: ");
                string name = Console.ReadLine();
                var transformer = (await manager.GetAllTransformers()).FirstOrDefault(t => t == name);
                if (transformer != null)
                {
                    var winLossRatio = await manager.GetWinLossRatio(new Transformer { Name = name });
                    if (winLossRatio != null)
                    {
                        foreach (var ratio in winLossRatio)
                        {
                            Console.WriteLine(ratio);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Transformer not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            finally
            {
                await MainMenu();
            }
        }

        private async Task DisplayTransformers()
        {
            try
            {
                var transformers = await manager.GetAllTransformers();
                if (transformers != null)
                {
                    Console.WriteLine("Transformers List:");
                    foreach (var transformer in transformers)
                    {
                        Console.WriteLine(transformer);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            finally
            {
                await MainMenu();
            }
        }
    }
}
