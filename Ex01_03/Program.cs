namespace Ex01_03
{
    public class Program
    {
        public static void Main() 
        {
            PrintDiamondByHeight();

            System.Console.WriteLine("Press 'Enter' to continue...");
            System.Console.ReadLine();
        }

        public static void PrintDiamondByHeight()
        {
            int diamondHeight = getUserInput();

            Ex01_02.Program.PrintDiamond(diamondHeight);
        }

        public static int getUserInput()
        {
            bool   isValidInput = false, parsable;
            string userInput;
            int    diamondHeight = 1;

            System.Console.WriteLine("Please enter the diamond height:");

            while (!isValidInput)
            {
                userInput = System.Console.ReadLine();
                parsable = int.TryParse(userInput, out diamondHeight);

                if (!parsable || diamondHeight < 1)
                {
                    System.Console.WriteLine("The input you entered is invalid. Please try again.");
                }
                else
                {
                    isValidInput = true;
                }
            }

            return diamondHeight;
        }
    }
}
