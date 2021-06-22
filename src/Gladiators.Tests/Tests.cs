using System;
using Gladiators.Entities;

public class Tests
{
    public static void Main()
    {
        Step1Tests();
    }

    static void Step1Tests()
    {
        var glad1 = new Gladiator("Jean-Louis");
        var glad2 = new Gladiator("15charactername", 10000, 30);
        PrintGladiator(glad1);
        PrintGladiator(glad2);
        for (int i = 0; i < 3; i++)
        {
            glad1.TakeDamage(glad2.Damage);
            PrintGladiator(glad1);
        }

        int totalDamage = 0;
        int maxDamage = int.MinValue;
        int minDamage = int.MaxValue;
        for (int i = 0; i < 1000; i++)
        {
            int damage = glad2.Damage;
            if (damage > maxDamage) maxDamage = damage;
            if (damage < minDamage) minDamage = damage;
            totalDamage += damage;
        }
        System.Console.WriteLine($"Mean damage: {totalDamage / 1000}");
        System.Console.WriteLine($"Max damage: {maxDamage}");
        System.Console.WriteLine($"Min damage: {minDamage}");

        try { new Gladiator("16charactersname"); }
        catch (InvalidNameException) { System.Console.WriteLine("Too long"); }

        try { new Gladiator("2c"); }
        catch (InvalidNameException) { System.Console.WriteLine("Too short"); }
    }

    static void PrintGladiator(Gladiator gladiator)
    {
        System.Console.WriteLine($"{gladiator.Name} has {gladiator.HealthPoints} HP");
    }
}