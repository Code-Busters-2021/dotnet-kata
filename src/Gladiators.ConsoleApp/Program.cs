using System;

namespace Gladiators.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var gregor = new Entities.Gladiator("Gregor", 200, 40);
            var jane = new Entities.Gladiator("Jane", 160, 50);

            var fight = new Entities.Fight();
            fight.Join(gregor);
            fight.Join(jane);
            fight.Start();

        }
    }
}