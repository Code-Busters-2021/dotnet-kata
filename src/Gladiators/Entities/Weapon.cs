using System;
using System.Collections.Generic;
using System.Text;
using Gladiators.External;

namespace Gladiators.Entities
{
    public static class WeaponTypesExtensions
    {
        public static string Name(this WeaponTypes weapon)
        {
            return weapon.ToString();
        }

        public static double AttackModifier(this WeaponTypes weapon)
        {
            switch (weapon)
            {
                case WeaponTypes.None:
                    return 1.0;
                case WeaponTypes.Fork:
                    return 1.1;
                case WeaponTypes.Club:
                    return 1.5;
                case WeaponTypes.Sword:
                    return 2;
                default:
                    return 1.0;
            };
        }

    }
}