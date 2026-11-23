namespace Task2._3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Unit target = new Unit("Голем", 300, 40);
            int incomingDamage = 60;

            DamageSystem physicalSystem = new DamageSystem(new PhysicalDamageCalculator());
            physicalSystem.ApplyDamage(target, incomingDamage);

            DamageSystem magicSystem = new DamageSystem(new MagicDamageCalculator());
            magicSystem.ApplyDamage(target, incomingDamage);

            DamageSystem fireSystem = new DamageSystem(new FireDamageCalculator());
            fireSystem.ApplyDamage(target, incomingDamage);
        }
    }
}



public interface IDamageCalculator
{
    int CalculateDamage(int baseDamage, int targetArmor);
}

public class PhysicalDamageCalculator : IDamageCalculator
{
    public int CalculateDamage(int baseDamage, int targetArmor)
    {
        int damage = baseDamage - targetArmor / 2;
        return Math.Max(1, damage);
    }
}

public class MagicDamageCalculator : IDamageCalculator
{
    public int CalculateDamage(int baseDamage, int targetArmor)
    {
        if (targetArmor == 0)
        {
            return Math.Max(1, baseDamage * 2);
        }

        int damage = baseDamage - targetArmor / 4;
        return Math.Max(1, damage);
    }
}

public class FireDamageCalculator : IDamageCalculator
{
    public int CalculateDamage(int baseDamage, int targetArmor)
    {
        int damage = baseDamage - targetArmor / 10;
        if (baseDamage > 50)
        {
            damage += 10;
        }

        return Math.Max(1, damage);
    }
}

public class Unit
{
    public string Name { get; set; }
    public int HP { get; set; }
    public int Armor { get; set; }

    public Unit(string name, int hp, int armor)
    {
        Name = name;
        HP = hp;
        Armor = armor;
    }
}

public class DamageSystem
{
    private readonly IDamageCalculator _calculator;

    public DamageSystem(IDamageCalculator calculator)
    {
        _calculator = calculator;
    }

    public void ApplyDamage(Unit target, int baseDamage)
    {
        int damage = _calculator.CalculateDamage(baseDamage, target.Armor);
        target.HP = Math.Max(0, target.HP - damage);
        Console.WriteLine($"Юнит {target.Name} получил {damage} урона. Осталось HP: {target.HP}");
    }
}
