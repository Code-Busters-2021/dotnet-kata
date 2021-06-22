using System;
using System.Collections.Generic;
using System.Text;

namespace Gladiators.Entities
{
    public class Fight
    {
        Gladiator fighter1 = null;
        Gladiator fighter2 = null;

        External.WeaponLooter weaponLooter = new External.WeaponLooter();

        public bool Join(Gladiator gladiator)
        {
            if (gladiator.IsDead)
            {
                System.Console.WriteLine($"{gladiator.Name} is dead and cannot fight");
                return false;
            }

            if (fighter1 == null)
                fighter1 = gladiator;
            else if (fighter2 == null)
                fighter2 = gladiator;
            else
            {
                System.Console.WriteLine($"Two fighters have already joined");
                return false;
            }
            return true;
        }

        public bool HasEnded { get; private set; }

        public void Start()
        {
            if (HasEnded)
            {
                System.Console.WriteLine("This fight has already ended");
                return;
            }
            if (fighter1 == null || fighter2 == null)
            {
                System.Console.WriteLine("Two gladiators need to join before the fight can start");
                if (fighter1 != null)
                    System.Console.WriteLine($"{fighter1.Name} has already joined, you need a second one");
                return;
            }
            System.Console.WriteLine($"A fight starts between {fighter1.Name} and {fighter2.Name}");
            while (!(fighter1.IsDead || fighter2.IsDead))
            {
                ExecuteInRandomOrder(
                    () => PerformAttack(fighter1, fighter2),
                    () => PerformAttack(fighter2, fighter1)
                );
            }
            System.Console.WriteLine($"{((fighter1.IsDead) ? fighter1.Name : fighter2.Name)} lost the battle");
            System.Console.WriteLine($"{((fighter1.IsDead) ? fighter2.Name : fighter1.Name)} emerges victorious");
            fighter1.UnequipWeapon();
            fighter2.UnequipWeapon();
            HasEnded = true;
        }

        //Private
        void PerformAttack(Gladiator attacker, Gladiator defender)
        {
            if (attacker.IsDead) return;

            External.WeaponTypes weapon = weaponLooter.TryLootSomething();
            if (attacker.TryEquipWeapon(weapon))
                System.Console.WriteLine($"{attacker.Name} equips a {weapon.Name()}");

            int damage = attacker.Damage;
            System.Console.WriteLine($"{attacker.Name} attacks {defender.Name} for {damage} Damage");
            defender.TakeDamage(damage);
        }

        static Random fightRng = new Random();
        static void ExecuteInRandomOrder(Action action1, Action action2)
        {
            if (fightRng.Next(2) == 0)
            {
                action1();
                action2();
            }
            else
            {
                action2();
                action1();
            }
        }
    }
}