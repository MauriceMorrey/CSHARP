using System;

namespace Human
{
    public class Human
    {
        public string name;
        public int strength = 3;
        public int intelligence = 3;
        public int dexterity = 3;
        public int health = 100;
        

        public Human(string name)
        {
            this.name = name;
        }

        public Human(string name, int strength, int intelligence, int dexterity, int health)
        {
            this.name = name;
            this.strength = strength;
            this.intelligence = intelligence;
            this.dexterity = dexterity;
            this.health = health;
        }
        public void attack(Human Enemy)
        {
            Enemy.health -= 5 * this.strength;
            // if(Enemy is Human)
            // {
            //     Human target = Enemy as Human;
            //     target.health -= strength*5;
            //     // System.Console.WriteLine(health);
            // }
        }
        public class Wizard : Human
        {
            public Wizard(string name) : base(name, 3, 25, 3, 50)
            {

            }
            public void heal()
            {
                intelligence += 10 * this.intelligence;
            }
            public void fireball(object adversary) //public void fireball(Human adversary) step 1
            {
                Random rand = new Random(); //step 2
                // adversary.health -= rand.Next(20,50); step 3

                if (adversary is Human)
                {
                    Human NewTarget = adversary as Human;
                    NewTarget.health -= rand.Next(20, 50);
                }
            }
        }
        public class Ninja : Human
        {
            public Ninja(string name) : base(name, 3, 3, 175, 100)
            {

            }
            public void steal()
            {
                health += 10;
            }
            public void get_away()
            {
                health -= 15;
            }
        }

        public class Samurai : Human
        {
            public static int count = 0;
            public Samurai(string name) : base(name)
            {
                count++;
                this.health = 200;
            }
            public void death_blow(object enemy)
            {
                if (enemy is Human)
                {
                    Human TargetOne = enemy as Human;
                    if (TargetOne.health < 50)
                    {
                        TargetOne.health = 0;
                    }
                }
            // public void death_blow(Human enemy) //this works too
            // {
            //     if(enemy.health < 50)
            //     {
            //         enemy.health = 0;
            //     }
            // }
            }
            public void meditate()
            {
                health = 200;
            }
            public static void how_many()
            {
                System.Console.WriteLine(count);
            }

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Human Konrad = new Human("Konrad");
            Human Mike = new Human("Mike");
            Human Maurice = new Human("Maurice", 100, 100, 100, 100);

            Konrad.attack(Mike);
            System.Console.WriteLine($"{Konrad.name} attacked {Mike.name}, current health is {Mike.health}");
            System.Console.WriteLine(Maurice.name);

            Human.Wizard Harry = new Human.Wizard("Harry");
            System.Console.WriteLine(Harry.intelligence);

            Harry.heal();
            System.Console.WriteLine(Harry.intelligence);

            Harry.fireball(Mike);
            System.Console.WriteLine(Mike.health);

            Human.Ninja Net = new Human.Ninja("Net");
            Net.steal();
            System.Console.WriteLine(Net.health);
            Net.get_away();
            System.Console.WriteLine(Net.health);

            Human.Samurai Last = new Human.Samurai("Last");
            System.Console.WriteLine(Last.health);
            Last.death_blow(Konrad);
            System.Console.WriteLine(Konrad.health);
            Last.meditate();
            System.Console.WriteLine(Last.health);

            Human.Samurai.how_many();

        }
    }
}
