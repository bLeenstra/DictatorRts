using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DictatorRTS.LifeCycle
{
    public class Person
    {
        public byte[] innerCode = new byte[4];
        public Hashtable Relation = new Hashtable();
        private Random _r;
        public int age = 0;
        public Gender gender;
        public bool IsAlive = false;

        public decimal WageIncome = 0m;

        public decimal money = 0;

        public Person P1, P2;
        public State CurrentState = State.None;

        public static int MatchComplex = 2;
        public static int MateState = -1;

        public static int MateAgeLimit = 18;
        public static int AgeWork = 15;
        public static int RetirementAge = 65;
        public static int DeathAge = 80;

        public static int LivingCostPerYear = 30000;

        public static int LowIncomePerYear = 43000;
        public static int HowIncomePerYear = 79000;

        public enum Gender
        {
            Male,
            Female
        }

        public enum State
        {
            None,
            Ready
        }

        public Person(Random r, Person _p1 = null, Person _p2 = null)
        {
            r.NextBytes(innerCode);
            _r = r;

            gender = r.Next(0, 2) == 0 ? Gender.Male : Gender.Female;

            P1 = _p1;
            P2 = _p2;
        }

        public bool IsRelation(Person p, ref int Gen)
        {
            if ((p.P1 == null && p.P2 == null) || (this.P1 == null && this.P2 == null))
                return false;
            if (Gen == 3)
                return false;
            if (p.P1 == this.P1 || p.P2 == this.P2 ||
                this == p.P1 || this == p.P2 ||
                this.P1 == p || this.P2 == p) // Parent or Kid!
            {
                Gen++;
                return true;
            }
            else if (this.P1.IsRelation(p, ref Gen) || this.P2.IsRelation(p, ref Gen)) // is GrandParent?
            {
                return true;
            }
            return false;
        }

        public int Action(Person p)
        {
            if (this.age < MateAgeLimit || p.age < MateAgeLimit)
            {
                return 0;
            }

            int code = Relation.ContainsKey(p) ? (int)Relation[p] : 0;

            for (int i = 0; i < p.innerCode.Length; i++)
            {
                for (int x = 0; x < this.innerCode.Length; x++)
                {
                    if (p.innerCode[i] == this.innerCode[x])
                    {
                        Relation[p] = ++code;

                        if (this.CurrentState == State.Ready && p.Relation.ContainsKey(this) &&
                             (int)p.Relation[this] >= MatchComplex)
                        {
                            Relation[p] = code = 0;
                            p.Relation[this] = 0;
                            return -1;
                        }

                        return code;
                    }
                    else
                    {
                        this.innerCode[x] = (byte)_r.Next(0, 255);
                    }
                }
            }
            return code;
        }
    }
}
