namespace Ex01_05
{
    public class Program
    {
        private const string k_CompareByGreatThan = "Biggest";
        private const string k_CompareByLessThan = "Smallest";
        private const int    k_UserInputDigitsLength = 9;

        public static void Main()
        {
            NumberStatistics();

            System.Console.WriteLine("Press 'Enter' to continue...");
            System.Console.ReadLine();
        }

        public static void NumberStatistics()
        {
            int usersNumber = getUserInput();
            int biggestDigit = getBiggestDigit(usersNumber);
            int smallestDigit = getSmallestDigit(usersNumber);
            int numberOfDigitsDividedByFour = getNumberOfDigitsDividedByFour(usersNumber);
            int numberOfDigitsGreaterThanUnitsDigit = getNumberOfDigitsGreaterThanUnitsDigit(usersNumber);

            printDetails(biggestDigit, smallestDigit, numberOfDigitsDividedByFour, numberOfDigitsGreaterThanUnitsDigit);
        }

        private static int getUserInput()
        {
            bool isValidInput = false, parsable;
            string userInput;
            int userNumber = 0;

            System.Console.WriteLine("Please Enter a number with {0} digits.", k_UserInputDigitsLength);

            while (!isValidInput)
            {
                userInput = System.Console.ReadLine();
                parsable = int.TryParse(userInput, out userNumber);

                if (userInput.Length != k_UserInputDigitsLength || !parsable)
                {
                    System.Console.WriteLine("The input you entered is invalid. Please try again.");
                }
                else
                {
                    isValidInput = true;
                }
            }

            return userNumber;
        }

        private static int getBiggestDigit(int i_Number)
        {
            return getDigit(i_Number, "Biggest");
        }

        private static int getSmallestDigit(int i_Number)
        {
            return getDigit(i_Number, "Smallest");
        }

        private static int getDigit(int i_Number, string i_Condition)
        {
            int wantedDigit = i_Number % 10;
            int numberWithoutUnitsDigit = i_Number / 10;
            int currentUnitsDigit = numberWithoutUnitsDigit % 10;

            for (int i = 1; i < k_UserInputDigitsLength; i++)
            {
                if ((i_Condition == k_CompareByGreatThan && currentUnitsDigit > wantedDigit) ||
                    (i_Condition == k_CompareByLessThan && currentUnitsDigit < wantedDigit))
                {
                    wantedDigit = currentUnitsDigit;
                }

                numberWithoutUnitsDigit /= 10;
                currentUnitsDigit = numberWithoutUnitsDigit % 10;
            }

            return wantedDigit;
        }

        private static int getNumberOfDigitsDividedByFour(int i_Number)
        {
            int numberWithoutUnitsDigit = i_Number / 10;
            int unitsDigit = i_Number % 10;
            int counterDividedDigits = 0;

            for (int i = 0; i < k_UserInputDigitsLength; i++)
            {
                if (unitsDigit % 4 == 0)
                {
                    counterDividedDigits++;
                }

                unitsDigit = numberWithoutUnitsDigit % 10;
                numberWithoutUnitsDigit /= 10;
            }

            return counterDividedDigits;
        }

        private static int getNumberOfDigitsGreaterThanUnitsDigit(int i_Number)
        {
            int unitsDigit = i_Number % 10;
            int numberWithoutUnitsDigit = i_Number / 10;
            int currentDigit = numberWithoutUnitsDigit % 10;
            int counterForDigitsGreaterThanUnitsDigit = 0;

            while (numberWithoutUnitsDigit != 0)
            {
                if (currentDigit > unitsDigit)
                {
                    counterForDigitsGreaterThanUnitsDigit++;
                }

                numberWithoutUnitsDigit /= 10;
                currentDigit = numberWithoutUnitsDigit % 10;
            }

            return counterForDigitsGreaterThanUnitsDigit;
        }

        private static void printDetails(int i_BiggestDigit, int i_SmallestDigit, int i_NumberOfDigitsDividedByFour, int i_NumberOfDigitsGreaterThanUnitsDigit)
        {
            string outputMessage = string.Format(
@"The biggest digit is: {0}.
The smallest digit is: {1}.
The number of digits that divided by four is: {2}.
The number of digits that greater than the units digit is: {3}.", i_BiggestDigit, i_SmallestDigit, i_NumberOfDigitsDividedByFour, i_NumberOfDigitsGreaterThanUnitsDigit);

            System.Console.WriteLine(outputMessage);
        }
    }
}
