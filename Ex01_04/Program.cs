namespace Ex01_04
{
    public class Program
    {
        const int k_ExpectedStringLength = 8;

        public static void Main()
        {
            AnalyzeString();

            System.Console.WriteLine("Press 'Enter' to continue...");
            System.Console.ReadLine();
        }

        public static void AnalyzeString()
        {
            bool   isValidInput = false, isPureNumber = false, isPureAlphabetic = false, isDivisible, isPalindrome;
            int    numberOfLowerCasedCharacters;
            string userInput = "";

            System.Console.WriteLine("Please enter a string {0} characters long", k_ExpectedStringLength);

            while (!isValidInput)
            {
                userInput = System.Console.ReadLine();

                isPureNumber = isPureNumericString(userInput);
                isPureAlphabetic = isPureAlphabeticString(userInput);

                if (userInput.Length != k_ExpectedStringLength || (isPureNumber == isPureAlphabetic))
                {
                    System.Console.WriteLine("The input you entered is invalid. Please try again.");
                }
                else
                {
                    isValidInput = true;
                }
            }

            isPalindrome = isPalindromeString(userInput);
            System.Console.WriteLine($"The string {(isPalindrome == true ? "is" : "isn't")} a palindrome.");

            if (isPureNumber == true)
            {
                isDivisible = isDivisibleBy5(userInput);
                System.Console.WriteLine($"The number {(isDivisible == true ? "is" : "isn't")} divisible by 5");
            }
            else if (isPureAlphabetic == true)
            {
                numberOfLowerCasedCharacters = getNumberOfLowerCasedCharacters(userInput);
                System.Console.WriteLine("The number of lowered cased characters in the string is: {0}", numberOfLowerCasedCharacters);
            }
        }

        private static bool isPureNumericString(string i_StringToCheck)
        {
            bool isPureNumber = true;

            for (int i = 0; i < i_StringToCheck.Length && isPureNumber; i++)
            {
                isPureNumber = char.IsDigit(i_StringToCheck[i]);
            }

            return isPureNumber;
        }

        private static bool isPureAlphabeticString(string i_StringToCheck)
        {
            bool isPureLetters = true;

            for (int i = 0; i < i_StringToCheck.Length && isPureLetters; i++)
            {
                isPureLetters = char.IsLetter(i_StringToCheck[i]);
            }

            return isPureLetters;
        }

        private static bool isPalindromeString(string i_StringToCheck)
        {
            bool isPalindromeFlag = true;
            if (i_StringToCheck.Length == 0)
                return isPalindromeFlag;

            int stringLength = i_StringToCheck.Length;

            if (i_StringToCheck[0] == i_StringToCheck[stringLength - 1])
            {
                isPalindromeFlag = isPalindromeString(i_StringToCheck.Substring(1, stringLength - 2));
            }
            else
            {
                isPalindromeFlag = false;
            }

            return isPalindromeFlag;
        }

        private static bool isDivisibleBy5(string i_NumberToCheck)
        {
            int parsedNumber = int.Parse(i_NumberToCheck);

            return (parsedNumber % 5 == 0);
        }

        private static int getNumberOfLowerCasedCharacters(string i_StringToCheck)
        {
            int numberOfLowerCasedCharacters = 0;

            for (int i = 0; i < i_StringToCheck.Length; i++)
            {
                if (char.IsLower(i_StringToCheck[i]))
                {
                    numberOfLowerCasedCharacters++;
                }
            }

            return numberOfLowerCasedCharacters;
        }
    }
}
