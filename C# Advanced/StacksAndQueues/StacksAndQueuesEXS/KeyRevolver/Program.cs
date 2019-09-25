using System;
using System.Collections.Generic;
using System.Linq;

namespace KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            var bulletPrice = int.Parse(Console.ReadLine());
            var gunBarrelSize = int.Parse(Console.ReadLine());
            var bullets = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var locks = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var intelligenceValue = int.Parse(Console.ReadLine());

            var bulletsStack = new Stack<int>(bullets);
            var lockQueue = new Queue<int>(locks);
            var oneBarrel = gunBarrelSize;

            while (lockQueue.Count > 0)
            {
                var bulletPower = bulletsStack.Pop();
                oneBarrel--;
                var lockPower = lockQueue.Peek();

                if (bulletPower <= lockPower)
                {
                    lockQueue.Dequeue();
                    Console.WriteLine("Bang!");
                }
                else
                {
                    Console.WriteLine("Ping!");
                }
                if (bulletsStack.Count == 0 && lockQueue.Count() > 0)
                {
                    Console.WriteLine($"Couldn't get through. Locks left: {lockQueue.Count}");
                    return;
                }
                if (oneBarrel == 0 && bulletsStack.Count>0)
                {
                    oneBarrel = gunBarrelSize;
                    Console.WriteLine("Reloading!");
                }
            }
            Console.WriteLine($"{bulletsStack.Count} bullets left. Earned ${intelligenceValue - (bullets.Count() - bulletsStack.Count()) * bulletPrice}");
        }
    }
}
