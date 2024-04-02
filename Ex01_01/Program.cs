namespace Ex01_01
{
    public class Program
    {
        private const int k_BinaryDigitLength = 9;
        private const int k_ExpectedInputNumbers = 3;
        private const int k_NotInitialized = 0;

        public static void Main()
        {
            BinarySeries();

            System.Console.WriteLine("Press 'Enter' to continue...");
            System.Console.ReadLine();
        }

        public static void BinarySeries()
        {
            string currentBinaryNumber;
            int    currentDecimalNumber, minDecimalNumber, midDecimalNumber, maxDecimalNumber,
                   countTotalOnes, countTotalZeros, countPowerOf2, countAscendingDigits;
            float  avgZeroAppearence, avgOneAppearence;

            minDecimalNumber = midDecimalNumber = maxDecimalNumber = k_NotInitialized;
            countTotalOnes = countTotalZeros = countPowerOf2 = countAscendingDigits = 0;

            System.Console.WriteLine("Please enter 3 numbers with {0} digits each:", k_BinaryDigitLength);

            for (int i = 0; i < k_ExpectedInputNumbers; i++)
            {
                currentBinaryNumber = getInputFromUser();
                currentDecimalNumber = convertBinaryToDecimal(currentBinaryNumber);
                updateNumbersOrder(ref minDecimalNumber, ref midDecimalNumber, ref maxDecimalNumber, currentDecimalNumber);

                countZerosAndOnes(currentBinaryNumber, out int currentNumberOfZeros, out int currentNumberOfOnes);
                countTotalZeros += currentNumberOfZeros;
                countTotalOnes += currentNumberOfOnes;
                countPowerOf2 = (checkIfPowerOf2(currentNumberOfOnes) ? countPowerOf2 + 1 : countPowerOf2);
                countAscendingDigits = (checkIfDigitsAscending(currentDecimalNumber) ? countAscendingDigits + 1 : countAscendingDigits);
            }

            avgZeroAppearence = countTotalZeros / (float)(k_BinaryDigitLength * k_ExpectedInputNumbers);
            avgOneAppearence = countTotalOnes / (float)(k_BinaryDigitLength * k_ExpectedInputNumbers);

            printStatistics(avgOneAppearence, avgZeroAppearence, countPowerOf2, countAscendingDigits, minDecimalNumber, midDecimalNumber, maxDecimalNumber);
        }

        private static string getInputFromUser()
        {
            bool   isValidInput = false, parsable;
            string userInput = "";

            while (!isValidInput)
            {
                userInput = System.Console.ReadLine();
                parsable = int.TryParse(userInput, out _);

                if (userInput.Length != k_BinaryDigitLength || !parsable)
                {
                    System.Console.WriteLine("The input you entered is invalid. Please try again.");
                }
                else
                {
                    isValidInput = true;
                }
            }

            return userInput;
        }

        private static int convertBinaryToDecimal(string i_BinaryNumber)
        {
            int decimalCalculation = 0;

            for(int i = 0; i < k_BinaryDigitLength; i++)
            {
                if (i_BinaryNumber[i_BinaryNumber.Length - i - 1] == '1')
                {
                    decimalCalculation += (int)System.Math.Pow(2,i);
                }
            }

            return decimalCalculation;
        }

        private static void updateNumbersOrder(ref int io_MinNumber, ref int io_MidNumber, ref int io_MaxNumber, int i_NumberToAdd)
        {
            if (System.Math.Max(io_MaxNumber, i_NumberToAdd) == i_NumberToAdd)
            {
                io_MinNumber = io_MidNumber;
                io_MidNumber = io_MaxNumber;
                io_MaxNumber = i_NumberToAdd;
            }
            else if (System.Math.Max(io_MidNumber, i_NumberToAdd) == i_NumberToAdd)
            {
                io_MinNumber = io_MidNumber;
                io_MidNumber = i_NumberToAdd;
            }
            else
            {
                io_MinNumber = i_NumberToAdd;
            }
        }

        private static void countZerosAndOnes(string i_BinaryNumber, out int o_NumberOfZeros, out int o_NumberOfOnes)
        {
            int countZeros = 0;
            int countOnes = 0;

            for (int i = 0; i < k_BinaryDigitLength; i++)
            {
                if (i_BinaryNumber[i_BinaryNumber.Length - i - 1] == '1')
                {
                    countOnes++;
                }
            }
            
            countZeros = k_BinaryDigitLength - countOnes;
            o_NumberOfZeros = countZeros;
            o_NumberOfOnes = countOnes;
        }
        
        private static bool checkIfPowerOf2(int i_NumberOfBinaryOnes)
        {
            return (i_NumberOfBinaryOnes == 1);
        }

        private static bool checkIfDigitsAscending(int i_Number)
        {
            int  previousRemainder;
            int  currentReminder = i_Number % 10;
            bool ascending = true;

            i_Number /= 10;

            while (i_Number > 0 && ascending)
            {
                previousRemainder = currentReminder;
                currentReminder = i_Number % 10;
                
                if (previousRemainder <= currentReminder)
                {
                    ascending = false;
                }
                else
                {
                    i_Number /= 10;
                }
            }

            return ascending;
        }

        private static void printStatistics(float i_AvgOneAppearence, float i_AvgZeroAppearence, int i_CountPowerOf2, int i_CountAscendingDigits,
                                             int i_MinDecimalNumber, int i_MidDecimalNumber, int i_MaxDecimalNumber)
        {
            string outputMessage = string.Format(
@"The numbers are: {0}, {1}, {2}
The average number of zero digits is: {3}.
The average number of one digits is: {4}.
The quantity of numbers that are powers of 2: {5}.
The quantity of numbers have digits in ascending order: {6}. 
The smallest number is {0} and the biggest number is {2}.", i_MinDecimalNumber, i_MidDecimalNumber, i_MaxDecimalNumber, i_AvgZeroAppearence, i_AvgOneAppearence, i_CountPowerOf2, i_CountAscendingDigits);

            System.Console.WriteLine(outputMessage);
        }
    }
}
