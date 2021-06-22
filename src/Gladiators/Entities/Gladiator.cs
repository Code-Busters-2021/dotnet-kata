using System;
using System.Collections.Generic;
using System.Text;

namespace Gladiators.Entities
{
    public class Gladiator
    {
        public Gladiator(string name, uint healthPoints = 50, uint attack = 10)
        {
            if (name.Length < 3 || name.Length > 15) throw new InvalidNameException();

            this.Name = name;
            this.hp = healthPoints;
            this.Attack = attack;
        }

        public string Name { get; private set; }

        uint hp;
        public int HealthPoints
        {
            get { return (int)hp; }
            private set
            {
                if (IsDead) return;
                hp = (value < 0) ? 0 : (uint)value;
                if (hp == 0)
                {
                    hp = 0;
                    IsDead = true;
                }
            }
        }

        public uint Attack { get; private set; }

        public External.WeaponTypes Weapon { get; private set; } = External.WeaponTypes.None;

        public int Damage { get { return (IsDead) ? 0 : (int)Math.Ceiling(Attack * Weapon.AttackModifier() * (0.8 + damageRng.NextDouble() * 0.4)); } }

        public bool IsDead { get; private set; } = false;

        public void TakeDamage(int damage) { HealthPoints -= damage; }

        public bool TryEquipWeapon(External.WeaponTypes weapon)
        {
            if (weapon.AttackModifier() > Weapon.AttackModifier())
            {
                Weapon = weapon;
                return true;
            }
            return false;
        }
        public void UnequipWeapon() { Weapon = External.WeaponTypes.None; }

        // Private
        static Random damageRng = new Random();
    }

    public class InvalidNameException : Exception
    {
        public override string Message => "A gladiator name must have between 3 and 15 characters";
    }
}