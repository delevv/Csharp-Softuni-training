using System;

namespace PasswordValidator
{
    class Program
    {
        static void PasswordCheck(string password)
        {
            bool LenghtValid = password.Length >= 6 && password.Length <= 10;
            bool letterAndDigits = true;
            bool atLeastTwoDigits = false;
            int digitsCount = 0;
            for (int i = 0; i < password.Length; i++)
            {
                char currentDigit = password[i];
                if (currentDigit < '0' || (currentDigit > '9' && currentDigit < 'A') || (currentDigit > 'Z' && currentDigit < 'a') || currentDigit > 'z')
                {
                    letterAndDigits = false;
                }

                if (currentDigit >= '0' && currentDigit <= '9')
                {
                    digitsCount++;
                }
                if (digitsCount >= 2) atLeastTwoDigits = true;
            }
            if (!LenghtValid) Console.WriteLine("Password must be between 6 and 10 characters");
            if (!letterAndDigits) Console.WriteLine("Password must consist only of letters and digits");
            if (!atLeastTwoDigits) Console.WriteLine("Password must have at least 2 digits");
            if (LenghtValid && letterAndDigits && atLeastTwoDigits) Console.WriteLine("Password is valid");
        }
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            PasswordCheck(password);
        }
    }
}