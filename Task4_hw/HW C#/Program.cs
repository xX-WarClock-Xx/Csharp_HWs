using System.Text.Json;
using System.Text.Json.Serialization;

namespace HW_C_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameCharacter hero = new GameCharacter
            {
                Name = "Артас",
                Level = 12,
                Health = 145.5,
                Inventory = new[] { "Стальной меч", "Зелье здоровья", "Щит стража" }
            };

            JsonSerializerOptions options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            string json = JsonSerializer.Serialize(hero, options);
            Console.WriteLine("Сформированный JSON:");
            Console.WriteLine(json);

            GameCharacter restoredHero = JsonSerializer.Deserialize<GameCharacter>(json);
            Console.WriteLine($"\nВосстановленный персонаж: {restoredHero.Name}");
            Console.WriteLine($"Количество предметов в инвентаре: {restoredHero.Inventory.Length}");
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




