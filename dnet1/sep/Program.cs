using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;
using sep;

class Program
{
    private static void RegexExercise()
    {
        string td = "<span class=\"cachtel\">Schweiz-Tschechien</span></a><td width =\"80\"> 0:1 </td><span class=\"cachtel\">Portugal-Türkei</span></a><td width=\"80\"> 2:0</td>";
        string pattern = "<span class=\"cachtel\">(?<countries>[A-Za-zäöü]+\\-+[A-Za-zäöü]+)<td width=\"80\">";

        string test = "<span class=\"\\-";

        string landPattern = @"[A-Za-zäöü]+\-+[A-Za-zäöü]+";
        string scorePattern = @"[0-9]+:+[0-9]+";
        var landMatches = Regex.Matches(td, landPattern);
        var scoreMatches = Regex.Matches(td, scorePattern);
        if (landMatches.Count == scoreMatches.Count)
        {
            for (int i = 0; i < landMatches.Count; i++)
            {
                var countries = landMatches[i].ToString();
                var scores = scoreMatches[i].ToString();
                var countrySplit = countries.Split('-');
                var scoreSplit = scores.Split(':');
                Console.WriteLine($"<Land1>{countrySplit[0]}</Land1><Land2>{countrySplit[1]}</Land2><Tore1>{scoreSplit[0]}</Tore1><Tore2>{scoreSplit[1]}</Tore2>");
            }
        }
    }

    class A
    {
        public virtual int Size { get; set; }

        public virtual void Foo()
        {
            Console.WriteLine("A");
        }
    }

    class B : A
    {
        private int size;

        public override int Size {
            get
            {
                return size;
            }
            set
            {
                this.size = value + 5;
            }
        }

        public override void Foo()
        {
            Console.WriteLine("B");
        }
    }

    class C : B
    {
        public new void Foo()
        {
            Console.WriteLine("C");
        }
    }

    class Auto
    {
        public override bool Equals(object obj)
        {
            Console.WriteLine("test");
            return false;
        }
    }

    static void Main(string[] args)
    {
        Auto a1 = new Auto();
        Auto a2 = new Auto();
        if (a1 == a2) Console.WriteLine("==");

        A a = new B();
        a.Size = 5;
        Console.WriteLine(a.Size);

        int[] t = { 1, 2, 3 };
        int s = t.Length;

        Car car1 = new Manta();
        Golf car2 = new GolfGTI();

        ((Opel)car1).WhatAreYou();
        ((GolfGTI)car2).WhatAreYou();
        ((Manta)car1).WhatAreYou();
        ((SportsCar)car1).WhatAreYou();
        car2.WhatAreYou();
        car1.WhatAreYou();
    }
}

