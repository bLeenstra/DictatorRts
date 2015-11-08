using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DictatorRTSUnitTest
{
    public class InteractionPlane
    {
        public List<Person> People = new List<Person>();
        public Random _random = new Random();

        public InteractionPlane(int _population)
        {
            for(int i = 0 ; i < _population;i++)
            {
                People.Add(new Person(_random));
            }
        }

        public void Interact()
        {
            Stopwatch sw = Stopwatch.StartNew();
            int age = 0;
            int maxAge = 0;
            int cycle = 0;
            int Years = 0;
            int days = 0;
            int births = 0;
            int deaths = 0;

            while(true)
            {
                sw.Stop();
                for(int f = 0; f < People.Count;  f++)
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

                            if (People[m].gender == Person.Gender.Female && People[m].age <= 50 || People[f].gender == Person.Gender.Female && People[f].age <= 50)
                            {
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
                        if (People[i].age++ > 80)
                        {
                            People.RemoveAt(i);
                            deaths++;
                        }
                        else
                        {
                            age += People[i].age;
                            if(People[i].age > maxAge)
                            {
                                maxAge = People[i].age;
                            }
                        }
                    }
                    cycle = 0;
                    Years++;
                }                
                Console.Write("Pop: {0}\nAvg Age: {1}\nMax Age: {2}\nYear: {3}\nDay: {4}\nBirths: {5}\nDeaths: {6}\r", People.Count, age == 0 || People.Count == 0 ? 0 : age / People.Count, maxAge, Years, days, births, deaths);                
            }

        }
    }
}
