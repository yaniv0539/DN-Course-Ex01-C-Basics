using System.Text;

namespace Ex01_02
{
    public class Program
    {
        const int k_DefaultDiamondHeight = 9;

        public static void Main() 
        {
            PrintDiamond();

            System.Console.WriteLine("Press 'Enter' to continue...");
            System.Console.ReadLine();
        }

        public static void PrintDiamond(int i_DiamondHeight = k_DefaultDiamondHeight)
        {
            int           diamondLevel = i_DiamondHeight / 2;
            StringBuilder diamondBuilder = new StringBuilder(i_DiamondHeight * i_DiamondHeight + i_DiamondHeight);

            i_DiamondHeight = (i_DiamondHeight % 2 == 0 ? i_DiamondHeight + 1 : i_DiamondHeight);

            AddUpperPyramid(ref diamondBuilder, i_DiamondHeight, diamondLevel);
            buildLineForDiamondBuilder(ref diamondBuilder, 0, i_DiamondHeight);
            AddLowerPyramid(ref diamondBuilder, i_DiamondHeight, diamondLevel);

            System.Console.WriteLine(diamondBuilder.ToString());
        }

        private static void AddUpperPyramid(ref StringBuilder io_DiamondBuilder, int i_DiamondHeight, int i_DiamondLevel)
        {
            if (i_DiamondLevel == 0)
            {
                return;
            }

            int numberOfSpaces = i_DiamondLevel;
            int numberOfStars = i_DiamondHeight - (numberOfSpaces * 2);

            buildLineForDiamondBuilder(ref io_DiamondBuilder, numberOfSpaces, numberOfStars);
            AddUpperPyramid(ref io_DiamondBuilder, i_DiamondHeight, i_DiamondLevel - 1);
        }

        private static void AddLowerPyramid(ref StringBuilder io_DiamondBuilder, int i_DiamondHeight, int i_DiamondLevel)
        {
            if (i_DiamondLevel == 0)
            {
                return;
            }

            int numberOfStars = i_DiamondLevel * 2 - 1;
            int numberOfSpaces = (i_DiamondHeight - numberOfStars) / 2;

            buildLineForDiamondBuilder(ref io_DiamondBuilder, numberOfSpaces, numberOfStars);
            AddLowerPyramid(ref io_DiamondBuilder, i_DiamondHeight, i_DiamondLevel - 1);
        }

        private static void buildLineForDiamondBuilder(ref StringBuilder o_DiamondBuilder, int i_NumberOfSpaces,int i_NumberOfStars)
        {
            o_DiamondBuilder.Append(new string(' ', i_NumberOfSpaces));
            o_DiamondBuilder.Append(new string('*', i_NumberOfStars));
            o_DiamondBuilder.Append(System.Environment.NewLine);
        }
    }
}
