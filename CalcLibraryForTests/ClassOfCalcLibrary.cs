namespace CalcLibraryForTests
{
    public class ClassOfCalcLibrary
    {
        public static int Sum(int firstOperand, int secondOperand)
        {
            int result = firstOperand + secondOperand;
            return result;
        }

        public static int Minus(int firstOperand, int secondOperand)
        {
            int result = firstOperand - secondOperand;
            return result;
        }

        public static int Multiple(int firstOperand, int secondOperand)
        {
            int result = firstOperand * secondOperand;
            return result;
        }

        public static int Devide(int firstOperand, int secondOperand)
        {
            if (secondOperand == 0)
            {
                throw new DivideByZeroException();
            }
            int result = firstOperand / secondOperand;
            return result;
        }

        
    }
}