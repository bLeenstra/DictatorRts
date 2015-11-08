using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace DictatorRTS.LifeCycle
{
    public class InteractionPlane
    {
        public List<Person> People = new List<Person>();
        public Random _random = new Random();

        public override string ToString()
        {
            return string.Format("Pop: {0}\nAvg Age: {1}\nMax Age: {2}\nYear: {3}\nDay: {4}\nBirths: {5}\nDeaths: {6}\nTax Rate: {7}%\nMoney: {8:c2}\nCentre Link: {9}\r", People.Count, age == 0 || People.Count == 0 ? 0 : age / People.Count, maxAge, Years, days, births, deaths, Tax, Money, WePayForPoor);
        }

        public void Kill(int i)
        {
            People[i].IsAlive = false;
            People.RemoveAt(i);
            deaths++;
        }

        public InteractionPlane(int _population, int startingAgeMin = 0, int startingAgeMax = 80)
        {
            for (int i = 0; i < _population; i++)
            {
                People.Add(new Person(_random));
                People.LastOrDefault().age = _random.Next(startingAgeMin, startingAgeMax);
            }
        }

        int age = 0;
        int maxAge = 0;
        int cycle = 0;
        int Years = 0;
        int days = 0;
        int births = 0;
        int deaths = 0;
        public decimal Tax = 10m;
        public decimal Money = 0m;
        public bool WePayForPoor = true;

        public void Interact()
        {
            for (int f = 0; f < People.Count; f++)
            {
                int m = _random.Next(0, People.Count);

                if (People[f] != People[m])
                {
                    int Result = People[f].Action(People[m]); ;
                    int gen = 0;
                    if (Result >= Person.MatchComplex)
                    {
                        People[f].CurrentState = Person.State.Ready;
                    }
                    else if (Result == Person.MateState)
                    {
                        if (People[m].gender == People[f].gender)
                            continue;
                        if (People[m].IsRelation(People[f], ref gen))
                        {
                            if (_random.Next(0, gen) == 1)
                            {
                                continue;
                            }
                        }
                        int g = People[m].gender == Person.Gender.Female && People[m].age <= 50 ?
                            m : People[f].gender == Person.Gender.Female && People[f].age <= 50 ? 
                            f : -1;
                        if(g > 0)
                        {
                            if (_random.Next(0, 50 - People[g].age) == 1)
                            {
                                continue;
                            }
                            this.People.Add(new Person(_random, People[m], People[f]));
                            births++;
                        }
                    }
                }
            }
            cycle++;
            days++;
            if (cycle > 365)
            {                
                age = 0;
                maxAge = 0;

                for (int i = People.Count - 1; i >= 0; i--)
                {
                    if (People[i].age++ > Person.DeathAge || (_random.Next(0, 100 - People[i].age) == 1))
                    {
                        Kill(i);
                    }
                    else
                    {
                        age += People[i].age;

                        // we have lived another year.

                        if (People[i].age >= Person.AgeWork)
                        {
                            if (People[i].age < Person.RetirementAge)
                            {
                                if (People[i].WageIncome == 0m)
                                {
                                    People[i].WageIncome = _random.Next(50000, 100000);
                                }
                                else
                                {
                                    People[i].WageIncome += People[i].WageIncome * 0.025m;
                                }

                                decimal totalTax = People[i].WageIncome * (Tax == 0m ? 0m : (Tax / 100m));

                                Money += totalTax;

                                People[i].money += People[i].WageIncome - totalTax;
                            }

                            if (People[i].money > Person.LivingCostPerYear)
                            {
                                People[i].money -= Person.LivingCostPerYear;
                            }
                            else
                            {
                                if (WePayForPoor)
                                {
                                    decimal AmountToPay = Person.LivingCostPerYear - People[i].money;

                                    Money -= AmountToPay;

                                    People[i].money = 0;
                                }
                                else
                                {
                                    Kill(i);
                                }
                            }
                        }

                        if (People[i].age > maxAge)
                        {
                            maxAge = People[i].age;
                        }
                    }
                }
                cycle = 0;
                Years++;
            }            
        }
    }
}
