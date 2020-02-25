using System;
using BabysitterKada.Classes;

namespace BabysitterKada
{
    class Program
    {
        static void Main(string[] args)
        {
            FamilyPayCalculator calc = new FamilyPayCalculator();

            Night night = new Night("6:00PM", "11:00PM");
            Family family = new FamilyA();
            Console.WriteLine(calc.CalculatePay(family, night));

            Night night2 = new Night("7:00PM", "1:00AM");
            Family familyB = new FamilyB();
            Console.WriteLine(calc.CalculatePay(familyB, night2));

            Night night3 = new Night("7:00PM", "1:00AM");
            Family familyC = new FamilyC();
            Console.WriteLine(calc.CalculatePay(familyC, night3));
        }
    }
}
