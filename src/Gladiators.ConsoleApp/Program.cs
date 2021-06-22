using System;

namespace Gladiators.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var gregor = new Entities.Gladiator("Gregor", 80, 40);

            System.Console.WriteLine($"{gregor.Name} is a healthy fighter, with {gregor.HealthPoints} HP");

            while (!gregor.IsDead)
            {
                System.Console.WriteLine($"Write the amount of damage you would like to inflict to {gregor.Name}");
                int damage = Int32.Parse(System.Console.ReadLine());

                gregor.TakeDamage(damage);
                System.Console.WriteLine($"{gregor.Name} has {gregor.HealthPoints} HP left");
            }
            System.Console.WriteLine($"{ gregor.Name } is dead ");

        }
    }
}