using System;
using System.Collections.Generic;



namespace NeuralNet
{
    class Program
    {

        private static decimal staticDecimal()
        {
            Console.WriteLine("hello delegate");
            return 0.7M;

        }

        private static Decimal rand() {
            var rand = new Random();
            return (Decimal)(new Random()).NextDouble();

        }

        private static Decimal one()
        {
            
            return 1M;

        }

        //YIELD INCREMENTOR
        /*
        private static IEnumerable<Decimal> increment() {

            Decimal value = 0;

            for (int i = 0; ; i++)
            {
                yield return value += 1;
            }

        }


        public static IEnumerable<int> getInt()
        {
            for (int i = 0; i < 10; i++)
            {
                yield return i;
            }
        }

        IEnumerator<int> enumerator = getInt().GetEnumerator();
            while (enumerator.MoveNext())
            {
                int n = enumerator.Current;
        Console.WriteLine(n);
            }

        /**/

    private static int[][] Concat(int[][] array1, int[][] array2)
    {
        int[][] result = new int[array1.Length + array2.Length][];

        array1.CopyTo(result, 0);
        array2.CopyTo(result, array1.Length);

        return result;
    }




        static void Main(string[] args)
        {
            Console.WriteLine();

            int[] array1D = new int[] {  1, 2 ,  3, 4  };

            

            int[,] array2D = new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } };

            int[,,] array3D = new int[,,] { 
                { { 1, 2, 3 }, 
                { 4, 5, 6 } },

                { { 7, 8, 9 }, 
                { 10, 11, 12 } },

                { { 13, 14, 15 },
                { 16, 17, 18 } }

            };
            

            Array matrixT = LinearAlgebra.generateTensor(rand, 3, 2);
            Array matrixZ = LinearAlgebra.generateTensor(rand, 3, 2);
            Array vectorA = LinearAlgebra.generateTensor(rand, 2, 1);
            Array vectorB = LinearAlgebra.generateTensor(rand, 2, 1);
            Array vectorC = LinearAlgebra.generateTensor(one, 3, 1);
            Array vectorD = LinearAlgebra.generateTensor(one, 3, 1);





            /*
            Decimal[,] matrix = new Decimal[,] { 
                { 1, 2 }, 
                { 3, 5 } };


            Decimal[,] vector = new Decimal[,] {
                { 7 },
                { 11 } };
            

            Decimal[,] matrix = new Decimal[,] {
                { 1, 2 },
                { 3, 5 } };


            Decimal[,] vector = new Decimal[,] {
                { 7,13 },
                { 11,17 } };
            /**/


            Decimal[,] matrix = new Decimal[,] {
                { 1, 2 },
                { 3, 5 } };


            Decimal[,] vector = new Decimal[,] {
                { 7,13 },
                { 11,17 } };



            //LinearAlgebra.printTensor(LinearAlgebra.tensorMutiplication(matrix, vector));

            LinearAlgebra.printTensor(LinearAlgebra.elementWiseMultiplication(matrix, vector));

        }


    }
}
