namespace BattleSimulation.Accessors
{
    public class BattleSimulatorAccessor : IBattleSimulatorAccessor
    {

        private List<Transformer> transformers = new List<Transformer>();

        public void AddTransformer(Transformer transformer)
        {
            transformers.Add(transformer);
            Console.WriteLine($"{transformer.Name} added.");
        }

        public void RemoveTransformer(string name)
        {
            var transformer = transformers.Find(t => t.Name == name);
            if (transformer != null)
            {
                transformers.Remove(transformer);
                Console.WriteLine($"{name} removed.");
            }
            else
            {
                Console.WriteLine($"{name} not found.");
            }
        }

        public void DisplayTransformers()
        {
            foreach (var transformer in transformers)
            {
                transformer.DisplayInfo();
            }
        }

    }
}
