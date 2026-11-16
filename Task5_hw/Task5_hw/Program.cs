using System;
using System.IO;
using System.Text.Json;

namespace Task5_hw
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameCharacter hero = new GameCharacter
            {
                Name = "FKN_student",
                Level = 35,
                Health = 250.0,
                Inventory = new[] { "Ноут", "мышка", "блок питния" }
            };

            JsonSerializerOptions options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            string json = JsonSerializer.Serialize(hero, options);

            string filePath = Path.Combine(AppContext.BaseDirectory, "save.json");
            File.WriteAllText(filePath, json);

            string loadedJson = File.ReadAllText(filePath);
            GameCharacter loadedHero = JsonSerializer.Deserialize<GameCharacter>(loadedJson);

            Console.WriteLine("=== Загруженный персонаж ===");
            Console.WriteLine($"Имя: {loadedHero.Name}");
            Console.WriteLine($"Уровень: {loadedHero.Level}");
            Console.WriteLine($"Здоровье: {loadedHero.Health}");
            Console.WriteLine($"Инвентарь: {string.Join(", ", loadedHero.Inventory)}");
        }
    }



















    public class GameCharacter
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public double Health { get; set; }
        public string[] Inventory { get; set; }
    }
}
