using System;

namespace Modul7
{
    public class Tank
    {
        private string tankName;
        private int ammunitionLevel;
        private int armorLevel;
        private int maneuverabilityLevel;
        private readonly Random random;

        public Tank(string name)
        {
            random = new Random();
            tankName = name;
            ammunitionLevel = GenerateRandomParameter();
            armorLevel = GenerateRandomParameter();
            maneuverabilityLevel = GenerateRandomParameter();
        }

        private int GenerateRandomParameter()
        {
            return random.Next(101);
        }

        public string TankStats()
        {
            return $"Tank Name: {tankName}, Ammunition Level: {ammunitionLevel}%, Armor Level: {armorLevel}%, Maneuverability Level: {maneuverabilityLevel}%";
        }

        public static bool operator ^(Tank tank1, Tank tank2)
        {
            int[] parameters1 = { tank1.ammunitionLevel, tank1.armorLevel, tank1.maneuverabilityLevel };
            int[] parameters2 = { tank2.ammunitionLevel, tank2.armorLevel, tank2.maneuverabilityLevel };
            int count = 0;
            for (int i = 0; i < 3; i++)
            {
                if (parameters1[i] > parameters2[i])
                {
                    count++;
                }
            }
            return count >= 2;
        }

        public void SetAmmunitionLevel(int level)
        {
            if (level < 0 || level > 100)
            {
                throw new ArgumentException("Ammunition level should be between 0 and 100.");
            }
            ammunitionLevel = level;
        }

        public void SetArmorLevel(int level)
        {
            if (level < 0 || level > 100)
            {
                throw new ArgumentException("Armor level should be between 0 and 100.");
            }
            armorLevel = level;
        }

        public void SetManeuverabilityLevel(int level)
        {
            if (level < 0 || level > 100)
            {
                throw new ArgumentException("Maneuverability level should be between 0 and 100.");
            }
            maneuverabilityLevel = level;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Tank t34 = new Tank("Т-34");
            Tank pantera = new Tank("Pantera");

            Console.WriteLine(t34.TankStats());
            Console.WriteLine(pantera.TankStats());

            if (t34 ^ pantera)
            {
                Console.WriteLine("Т-34 победил Pantera!");
            }
            else
            {
                Console.WriteLine("Pantera победила Т-34!");
            }
        }
    }
}
