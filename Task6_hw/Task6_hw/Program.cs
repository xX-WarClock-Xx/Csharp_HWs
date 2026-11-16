using System.Text.Json;


namespace Task6_hw
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = Path.Combine(AppContext.BaseDirectory, "settings.json");

            if (File.Exists(filePath))
            {
                string existingJson = File.ReadAllText(filePath);
                GameSettings settings = JsonSerializer.Deserialize<GameSettings>(existingJson);

                Console.WriteLine("(づ￣ 3￣)づ Текущие настройки (づ￣ 3￣)づ");
                Console.WriteLine($"Имя игрока: {settings.PlayerName}");
                Console.WriteLine($"Сложность: {settings.Difficulty}");
                Console.WriteLine($"Громкость музыки: {settings.MusicVolume}");
            }
            else
            {
                Console.WriteLine("Файл настроек не найден. Создаём новые настройки.");

                Console.Write("Введите имя игрока: ");
                string name = Console.ReadLine();

                Console.Write("Введите сложность (1 — легко, 2 — нормально, 3 — сложно): ");
                int difficulty = int.Parse(Console.ReadLine());

                Console.Write("Введите громкость музыки (0 - 100): ");
                int volume = int.Parse(Console.ReadLine());

                GameSettings newSettings = new GameSettings
                {
                    PlayerName = name,
                    Difficulty = difficulty,
                    MusicVolume = volume
                };

                JsonSerializerOptions options = new JsonSerializerOptions
                {
                    WriteIndented = true
                };

                string json = JsonSerializer.Serialize(newSettings, options);
                File.WriteAllText(filePath, json);

                Console.WriteLine("Настройки успешно сохранены!");
            }
        }
    }
    public class GameSettings
    {
        public string PlayerName { get; set; }
        public int Difficulty { get; set; }
        public int MusicVolume { get; set; }
    }
}
