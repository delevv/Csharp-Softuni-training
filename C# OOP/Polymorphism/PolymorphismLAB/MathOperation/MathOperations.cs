namespace Operations
{
    public class MathOperations
    {
        public int Add(int number, int secondNumber)
        {
            return number + secondNumber;
        }

        public double Add(double number, double secondNumber, double thirdNumber)
        {
            return number + secondNumber + thirdNumber;
        }

        public decimal Add(decimal number, decimal secondNumber, decimal thirdNumber)
        {
            return number + secondNumber + thirdNumber;
        }
    }
}
