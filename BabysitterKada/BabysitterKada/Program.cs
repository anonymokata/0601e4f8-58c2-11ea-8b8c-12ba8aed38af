using System;
using BabysitterKada.Classes;

namespace BabysitterKada
{
    class Program
    {
        static void Main(string[] args)
        {
            Night night = new Night("6:00PM", "11:00PM");
            Family family = new FamilyA();
            PayCalculator calc = new PayCalculator(family, night);
            Console.WriteLine(calc.CalculatePay());

            Night night2 = new Night("7:00PM", "1:00AM");
            Family familyB = new FamilyB();
            PayCalculator calcB = new PayCalculator(familyB, night2);
            Console.WriteLine(calcB.CalculatePay());

            Night night3 = new Night("7:00PM", "1:00AM");
            Family familyC = new FamilyC();
            PayCalculator calcC = new PayCalculator(familyC, night3);
            Console.WriteLine(calcC.CalculatePay());


        }
    }
}
