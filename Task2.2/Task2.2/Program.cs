namespace Task2._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player("Герой", 10, 15);

            List<IUsableItem> inventory = new List<IUsableItem>
        {
            new HealthPotion(),
            new Sword(),
            new AncientScroll()
        };

            foreach (var item in inventory)
            {
                item.Use(player);
            }

            string status = player.HP > 0 ? "Жив" : "Мёртв";
            Console.WriteLine($"\nИтог для {player.Name}: HP = {player.HP}, Урон = {player.Damage}, Состояние = {status}");
        }
    }
}



public enum Rarity
{
    Common,
    Rare,
    Legendary
}

public interface IUsableItem
{
    string Name { get; }
    string Description { get; }
    Rarity Rarity { get; }
    void Use(Player player);
}

public class Player
{
    public string Name { get; set; }
    public int HP { get; set; }
    public int Damage { get; set; }

    public Player(string name, int hp, int damage)
    {
        Name = name;
        HP = hp;
        Damage = damage;
    }

    public void Heal(int amount)
    {
        HP += amount;
    }

    public void IncreaseDamage(int amount)
    {
        Damage += amount;
    }
}

public class HealthPotion : IUsableItem
{
    public string Name => "Зелье здоровья";
    public string Description => "Восстанавливает 50 единиц здоровья.";
    public Rarity Rarity => Rarity.Common;

    public void Use(Player player)
    {
        player.Heal(50);
        Console.WriteLine($"[{Rarity}] Вы выпили «{Name}» и восстановили 50 HP.");
    }
}

public class Sword : IUsableItem
{
    public string Name => "Стальной меч";
    public string Description => "Увеличивает базовый урон на 10.";
    public Rarity Rarity => Rarity.Rare;

    public void Use(Player player)
    {
        player.IncreaseDamage(10);
        Console.WriteLine($"[{Rarity}] Вы экипировали «{Name}». Урон увеличен на 10.");
    }
}

public class AncientScroll : IUsableItem
{
    public string Name => "Древний свиток силы";
    public string Description => "Наносит 20 урона владельцу, но увеличивает атаку на 30.";
    public Rarity Rarity => Rarity.Legendary;

    public void Use(Player player)
    {
        player.HP = Math.Max(0, player.HP - 20);
        player.IncreaseDamage(30);
        Console.WriteLine($"[{Rarity}] Вы прочли «{Name}». Проклятие отняло 20 HP, но урон вырос на 30!");
    }
}