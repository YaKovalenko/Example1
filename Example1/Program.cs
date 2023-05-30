using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Net;
using System.Security.Policy;

namespace Example1
{
    internal class Program
    {
        static void Main()
        {
            Player player = new Player();
            Weapon[] inventory = { new Gun(), new ShortGun(), new LazerGun() };

            foreach (var item in inventory)
            {
                player.Fire(item);
                player.CheckInfo(item);
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
    
    interface IHasInfo
    {
        void ShowInfo();
    }

    interface IWeapon
    {
        int Damage { get; }
        void Fire();
    }

    class Player
    {
        public void Fire(Weapon weapon)
        {
            weapon.Fire();
        }
        public void CheckInfo(IHasInfo hasInfo)
        {
            hasInfo.ShowInfo();
        }
    }
    abstract class Weapon : IHasInfo, IWeapon
    {
        public abstract int Damage { get; }
        public abstract void Fire();

        public void ShowInfo()
        {
            Console.WriteLine($"{GetType().Name} Damage: {Damage}");
        }
    }
    class Gun : Weapon
    {
        public override int Damage => 5;

        public override void Fire()
        {
            Console.WriteLine("Puh-puh");
        }
    }
    class ShortGun : Weapon
    {
        public override int Damage => 10;

        public override void Fire()
        {
            Console.WriteLine("Puh");
        }
    }

    class LazerGun : Weapon
    {
        public override int Damage => 7;

        public override void Fire()
        {
            Console.WriteLine("---------");
        }
    }
}
