using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using Heroes.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Models.Map
{
    public class Map : IMap
    {
        public string Fight(ICollection<IHero> players)
        {
            List<IHero> knights = players.Where(p => p.GetType().Name == nameof(Knight)).ToList();
            List<IHero> barbarians = players.Where(p => p.GetType().Name == nameof(Barbarian)).ToList();

            bool knightsWin = false;
            bool babariansWin = false;

            int countOfDeadKnights = 0;
            int countOfDeadBarbarians = 0;

            while (true)
            {
                if (knights.All(k => k.IsAlive == false))
                {
                    babariansWin = true;
                    break;
                }
                if (barbarians.All(k => k.IsAlive == false))
                {
                    knightsWin = true;
                    break;
                }

                foreach (var knight in knights.Where(k => k.IsAlive == true))
                {
                    if (knight.Weapon == null)
                    {
                        continue;
                    }
                    foreach (var barbarian in barbarians.Where(b => b.IsAlive == true))
                    {
                        if (knight.IsAlive)
                        {
                            barbarian.TakeDamage(knight.Weapon.DoDamage());
                            if (!barbarian.IsAlive)
                            {
                                countOfDeadBarbarians++;
                            }
                            if (!knight.IsAlive)
                            {
                                countOfDeadKnights++;
                            }
                        }
                    }
                }

                foreach (var barbarian in barbarians.Where(b => b.IsAlive == true))
                {
                    if (barbarian.Weapon == null)
                    {
                        continue;
                    }
                    foreach (var knight in knights.Where(k => k.IsAlive == true))
                    {
                        if (barbarian.IsAlive)
                        {
                            knight.TakeDamage(barbarian.Weapon.DoDamage());
                            if (!knight.IsAlive)
                            {
                                countOfDeadKnights++;
                            }
                            if (!barbarian.IsAlive)
                            {
                                countOfDeadBarbarians++;
                            }
                        }
                    }
                }
            }
            if(knightsWin)
            {
                return String.Format(OutputMessages.MapFightKnightsWin, countOfDeadKnights);
            }
            else 
            {
                return String.Format(OutputMessages.MapFigthBarbariansWin, countOfDeadBarbarians);
            }
        }
    }
}
