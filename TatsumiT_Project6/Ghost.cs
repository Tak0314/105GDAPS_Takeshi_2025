using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace TatsumiT_Project6
{
    internal class Ghost : CommonCharacter
    {
        private int transparency;
        private int curseLevel;

        /// <summary>
        /// constructor if Ghost
        /// </summary>
        /// <param name="name">name of the character</param>
        /// <param name="health">health of the character</param>
        /// <param name="speed">speed of the character(determines which character will attack first)</param>
        /// <param name="level">level of the character(gives attack bonus)</param>
        /// <param name="strength">default attack param.</param>
        /// <param name="curseLevel">curse level of the ghost, bonus to the damage</param>
        public Ghost(string name, int health, int speed, int level, int strength, int curseLevel)
            : base(name, health, speed, level, strength)
        {
            this.curseLevel = curseLevel;
        }


        /// <summary>
        /// flees when it has 30 or less health
        /// </summary>
        /// <returns>bool that this character will flee or not</returns>
        public override bool ReadyToFlee()
        {
            return health <= 30;
        }

        /// <summary>
        /// add attack bonus from curseLevel
        /// </summary>
        /// <returns></returns>
        public override int Attack()
        {
            int finalAttack = base.Attack() + curseLevel;
            return finalAttack;
        }

        /// <summary>
        /// check if damage is not negative, and if random generated transparency is less than 4, damage it takes will be 0
        /// </summary>
        /// <param name="amountOfDamage">base damage it got from Attack</param>
        /// <returns>int of calculated amount of damage</returns>
        public override int TakeDamage(int amountOfDamage)
        {
            transparency = rng.Next(1, 11);
            if (amountOfDamage < 0)
            {
                amountOfDamage = 0;
            }
            if (transparency < 4)
            {
                amountOfDamage = 0;
            }
            return base.TakeDamage(amountOfDamage);
            
        }

        /// <summary>
        /// adds curse level to the base.ToString
        /// </summary>
        /// <returns>string of status of the character</returns>
        public override string ToString()
        {
            return base.ToString()+$"| curse level: {curseLevel}";
        }

        /// <summary>
        /// multiplies curseLevel by 2
        /// I will use it when Hp became lower than 70
        /// </summary>
        public void Fear()
        {
            if (!abilityUsed)
            {
                curseLevel *= 2;
                abilityUsed = true;
            }
        }
    }
}
