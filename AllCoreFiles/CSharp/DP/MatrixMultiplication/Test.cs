namespace AllCoreFiles.CSharp.DP.MatrixMultiplication
{
    public class Test
    {
        public static void Main()
        {
            int[] arr = { 2, 3, 5, 10 };
            MatrixMultiplication matrixMultiplication = new MatrixMultiplication(arr.Length);

            var count = matrixMultiplication.GetMinimumNumberOfMultplication(arr, 1, arr.Length - 1);
            Console.WriteLine("MIN COUNT IS : " + count);

            count = matrixMultiplication.GetMaximumNumberOfMultplication(arr, 1, arr.Length - 1);
            Console.WriteLine("MAX COUNT IS : " + count);

            //matrixMultiplication.PrintOptimalParens(matrixMultiplication.ArrParenthisis, 1, matrixMultiplication.ArrParenthisis.Length -1 );

            Console.ReadLine();
        }
    }
}
