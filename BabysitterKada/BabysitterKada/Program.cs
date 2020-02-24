using System;
using BabysitterKada.Classes;

namespace BabysitterKada
{
    class Program
    {
        static void Main(string[] args)
        {
            FamilyA a = new FamilyA(DateTime.Parse("7:00PM"));

            Console.WriteLine(a.earlyRateEndsAt);
        }
    }
}
