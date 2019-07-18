using System;
using System.Collections.Generic;

namespace Morse_Code_Translator
{
    class Program
    {
        static void Main(string[] args)
        {
            var translator = new Dictionary<string, char>
            {
                  [".-"] ='A',
                  ["-..."] ='B',
                  ["-.-."] ='C',
                  ["-.."] ='D',
                  ["."] ='E',
                  ["..-."] ='F',
                  ["--."] ='G',
                  ["...."] ='H',
                  [".."] ='I',
                  [".---"] ='J',
                  ["-.-"] ='K',
                  [".-.."] ='L',
                  ["--"] ='M',
                  ["-."] ='N',
                  ["---"] ='O',
                  [".--."] ='P',
                  ["--.-"] ='Q',
                  [".-."] ='R',
                  ["..."] ='S',
                  ["-"] ='T',
                  ["..-"] ='U',
                  ["...-"] ='V',
                  [".--"] ='W',
                  ["-..-"] ='X',
                  ["-.--"] ='Y',
                  ["--.."]= 'Z'
            };

            string[] message = Console.ReadLine().Split();
            string translatedMessage = "";

            for (int i = 0; i < message.Length; i++)
            {
                if (translator.ContainsKey(message[i]))
                {
                    translatedMessage += translator[message[i]];
                }
                if (message[i] == "|")
                {
                    translatedMessage += ' ';
                }
            }
            Console.WriteLine(translatedMessage);
        }
    }
}
