using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TatsumiT_Project6
{
    internal class Dark : CommonCharacter
    {
        private int consiousness;
        private int rage;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name">name of the character</param>
        /// <param name="health">health of the character</param>
        /// <param name="speed">speed of the character(determines which character will attack first)</param>
        /// <param name="level">level of the character(gives attack bonus)</param>
        /// <param name="strength">default attack param.</param>
        /// <param name="rage">rage stats of the Dark, damage multiplier</param>
        public Dark(string name, int health, int speed, int level, int strength, int rage)
            : base(name, health, speed, level, strength)
        {
            this.rage = rage;
        }

        /// <summary>
        /// Dark character will Flee when health is lessthan or equal to 5
        /// </summary>
        /// <returns>bool that this character will flee or not</returns>
        public override bool ReadyToFlee()
        {
            return health <= 5;
        }

        /// <summary>
        /// multiply attack randomly between 0 to rage
        /// if multiplier is lower than a half of the rage, take damage
        /// high risk high return
        /// </summary>
        /// <returns>final calculated stat</returns>
        public override int Attack()
        {
            int multiplier = rng.Next(0, rage + 1);
            int finalAttack = base.Attack() * multiplier;
            if (multiplier < (rage / 2))
            {
                base.TakeDamage(rage);
            }
            return finalAttack;
        }

        /// <summary>
        /// check if damage is not negative, and if randomly generated consiousness is less than 4, damage it will take doubles
        /// </summary>
        /// <param name="amountOfDamage">base damage it got from Attack</param>
        /// <returns>int of calculated amount of damage</returns>
        public override int TakeDamage(int amountOfDamage)
        {

            consiousness = rng.Next(1, rage + 1);
            if (amountOfDamage < 0)
            {
                amountOfDamage = 0;
            }
            if (consiousness < 4)
            {
                amountOfDamage *= 2;
            }
            return base.TakeDamage(amountOfDamage);

        }

        /// <summary>
        /// adds rage to the base.ToString
        /// </summary>
        /// <returns>string of status of the character</returns>
        public override string ToString()
        {
            return base.ToString() + $"| rage : {rage}";
        }

        /// <summary>
        /// multiplies rage by 2
        /// </summary>
        public void Rage()
        {
            if (!abilityUsed)
            {
                rage *= 2;
                abilityUsed = true;
            }
        }
    }
}
