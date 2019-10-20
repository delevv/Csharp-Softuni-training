using System;
using System.Collections.Generic;
using System.Linq;

namespace Socks
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var leftArray = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var rightArray = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var leftSocks = new Stack<int>();

            for (int i = 0; i < leftArray.Length; i++)
            {
                leftSocks.Push(leftArray[i]);
            }

            var rightSocks = new Queue<int>();

            for (int i = 0; i < rightArray.Length; i++)
            {
                rightSocks.Enqueue(rightArray[i]);
            }

            var pairs = new Queue<int>();
            var biggestPair = int.MinValue;

            while (leftSocks.Count > 0 && rightSocks.Count > 0)
            {
                var lastLeftSock = leftSocks.Peek();
                var firstRightSock = rightSocks.Peek();

                if (lastLeftSock > firstRightSock)
                {
                    var currentPair = lastLeftSock + firstRightSock;

                    pairs.Enqueue(currentPair);

                    if (currentPair > biggestPair)
                    {
                        biggestPair = currentPair;
                    }

                    leftSocks.Pop();
                    rightSocks.Dequeue();
                }
                else if (firstRightSock > lastLeftSock)
                {
                    leftSocks.Pop();
                }
                else
                {
                    rightSocks.Dequeue();

                    var currentLeftSock = leftSocks.Pop();

                    leftSocks.Push(currentLeftSock + 1);
                }
            }

            Console.WriteLine(biggestPair);
            Console.WriteLine(string.Join(" ",pairs));
        }
    }
}
