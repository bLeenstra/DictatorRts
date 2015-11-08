using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace DictatorRTS.LifeCycle
{
    public class InteractionPlane
    {
        public List<Person> People = new List<Person>();
        public Random _Random = new Random();
        public decimal PopGrowthPercetange = 0;
        public decimal TaxPercent = 10m;
        public decimal Capital = 0m;
        public bool CentreLinkEnabled = true;

        int _age = 0;
        int _maxAge = 0;
        int _cycle = 0;
        int _years = 0;
        int _days = 0;
        int _births = 0;
        int _deaths = 0;
        int _PreviousPopulation = 0;

        public override string ToString()
        {
            return string.Format("Pop: {0}\nAvg Age: {1}\nMax Age: {2}\nYear: {3}\nDay: {4}\nBirths: {5}\nDeaths: {6}\nTax Rate: {7}%\nMoney: {8:c2}\nCentre Link: {9}\r", People.Count, _age == 0 || People.Count == 0 ? 0 : _age / People.Count, _maxAge, _years, _days, _births, _deaths, TaxPercent, Capital, CentreLinkEnabled);
        }

        public void Kill(int i)
        {
            People[i].IsAlive = false;
            People.RemoveAt(i);
            _deaths++;
        }

        /// <summary>
        /// starting age is in years.
        /// </summary>
        /// <param name="_population"></param>
        /// <param name="startingAgeMin"></param>
        /// <param name="startingAgeMax"></param>
        public InteractionPlane(int _population, int startingAgeMin = 0, int startingAgeMax = 80)
        {
            for (int i = 0; i < _population; i++)
            {
                People.Add(new Person(_Random));
                People.LastOrDefault().age = _Random.Next(startingAgeMin, startingAgeMax);
            }                     
        }

        /// <summary>
        /// TODO: need to make it so other people can't take over relationships.
        /// Needs to be cleaned also structured.
        /// </summary>
        public void Interact()
        {
            for (int f = 0; f < People.Count; f++)
            {
                int m = _Random.Next(0, People.Count);

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
                            if (_Random.Next(0, gen) == 1)
                            {
                                continue;
                            }
                        }
                        int g = People[m].gender == Person.Gender.Female && People[m].age <= 50 ?
                            m : People[f].gender == Person.Gender.Female && People[f].age <= 50 ? 
                            f : -1;
                        if(g > 0)
                        {
                            if (_Random.Next(0, 50 - People[g].age) == 1)
                            {
                                continue;
                            }
                            this.People.Add(new Person(_Random, People[m], People[f]));
                            _births++;
                        }
                    }
                }
            }
            _cycle++;
            _days++;
            if (_cycle > 365) // Year Cycle.
            {                
                _age = 0;
                _maxAge = 0;
                
                for (int i = People.Count - 1; i >= 0; i--)
                {
                    if (People[i].age++ > Person.DeathAge || (_Random.Next(0, 100 - People[i].age) == 1))
                    {
                        Kill(i);
                    }
                    else
                    {
                        _age += People[i].age;

                        // we have lived another year.

                        if (People[i].age >= Person.AgeWork)
                        {
                            if (People[i].age < Person.RetirementAge)
                            {
                                if (People[i].WageIncome == 0m)
                                {
                                    People[i].WageIncome = _Random.Next(50000, 100000);
                                }
                                else
                                {
                                    People[i].WageIncome += People[i].WageIncome * 0.025m; // Wage Increase Per year. needs to be controled. depending on the market.
                                }

                                decimal totalTax = People[i].WageIncome * (TaxPercent == 0m ? 0m : (TaxPercent / 100m));

                                Capital += totalTax;

                                People[i].money += People[i].WageIncome - totalTax;
                            }

                            if (People[i].money > Person.LivingCostPerYear)
                            {
                                People[i].money -= Person.LivingCostPerYear;
                            }
                            else
                            {
                                if (CentreLinkEnabled)
                                {
                                    decimal AmountToPay = Person.LivingCostPerYear - People[i].money;

                                    Capital -= AmountToPay;

                                    People[i].money = 0;
                                }
                                else
                                {
                                    Kill(i);
                                }
                            }
                        }

                        if (People[i].age > _maxAge)
                        {
                            _maxAge = People[i].age;
                        }
                    }                    
                }

                if (_PreviousPopulation != 0 && People.Count != 0)
                {
                    //Original Number - New Number
                    PopGrowthPercetange = ((People.Count - _PreviousPopulation) / (decimal)_PreviousPopulation) * 100.0m;
                    GC.Collect(0);
                }

                _PreviousPopulation = People.Count;

                _cycle = 0;
                _years++;
            }            
        }
    }
}
