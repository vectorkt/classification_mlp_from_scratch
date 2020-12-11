using System;
using System.Collections.Generic;
using System.Linq;

namespace MLPScratch
{
    class Program
    {

      




        static void Main(string[] args)
        {
            Console.WriteLine();

            

            


            double[,] raw_dataset = new double[,] {
                {2.7810836, 2.550537003, 0},
                {1.465489372,2.362125076,0},
                {3.396561688,4.400293529,0},
                {1.38807019,1.850220317,0},
                {3.06407232,3.005305973,0},
                {7.627531214,2.759262235,1},
                {5.332441248,2.088626775,1},
                {6.922596716,1.77106367,1},
                {8.675418651,-0.242068655,1},
                {7.673756466,3.508563011,1}
            };

            double[] arr = new double[] { 1, 2, 23, };




            
            Dataset dataset = new Dataset(raw_dataset);

            NeuralNetwork network = new NeuralNetwork(2,3,2);


            network.train(dataset, 0.5, 100);



            foreach(Datum d in dataset.data) {

                Console.WriteLine("Example \n\n"+network.predict(d.input)+"\n"+d.oneHotEncoding+"\n\n")  ;
            
            
            }


            /*
            Random rnd = new Random();

            int a, b, c;

            Tensor matrixA, matrixB;

            while (true) {

                a = rnd.Next(1, 3);

                b = rnd.Next(1, 3);

                c = rnd.Next(1, 100);



                matrixA = new Tensor(a, b);

                matrixB = new Tensor(a, b);

                matrixA.print();
                //matrixA.printShape();
                //matrixB.print();
                //matrixB.printShape();

                Tensor matrixC = matrixA.applyFunction(x=>2*x + 1) ;

                matrixC.print();


            }


            
            double[,] matrixA = new double[,] {
                { 1, 2 },
                { 3, 5 } };


            double[,] matrixB = new double[,] {
                { 7,13 },
                { 11,17 } };


            Array matrixT = LinearAlgebra.generateTensor(rand, 3, 2);
            Array matrixZ = LinearAlgebra.generateTensor(rand, 2, 3);

            LinearAlgebra.tensorMutiplication(matrixT, matrixZ);            
      

            
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
            Array vectorC = LinearAlgebra.generateTensor(two, 3, 1);
            Array vectorD = LinearAlgebra.generateTensor(three, 3, 1);





            
            double[,] matrix = new double[,] { 
                { 1, 2 }, 
                { 3, 5 } };


            double[,] vector = new double[,] {
                { 7 },
                { 11 } };
            

            double[,] matrix = new double[,] {
                { 1, 2 },
                { 3, 5 } };


            double[,] vector = new double[,] {
                { 7,13 },
                { 11,17 } };
            


            double[,] matrix = new double[,] {
                { 1, 2 },
                { 3, 5 } };


            double[,] vector = new double[,] {
                { 7,13 },
                { 11,17 } };





            
            LinearAlgebra.printTensor(LinearAlgebra.addition(vectorC, vectorD));
            LinearAlgebra.printTensor( LinearAlgebra.subtraction(vectorC, vectorD));
            LinearAlgebra.printTensor(LinearAlgebra.elementWiseMultiplication(vectorC, vectorD));



            LinearAlgebra.printTensor(LinearAlgebra.addition(matrixT, matrixZ));
            LinearAlgebra.printTensor(LinearAlgebra.subtraction(matrixT, matrixZ));
            LinearAlgebra.printTensor(LinearAlgebra.elementWiseMultiplication(matrixT, matrixZ));
            


            LinearAlgebra.printTensor(LinearAlgebra.tensorMutiplication(matrixT, vectorA));

            LinearAlgebra.printTensor(LinearAlgebra.shape(matrixT));
            LinearAlgebra.printTensor(LinearAlgebra.shape(vectorA));
            /**/


        }



        private static double staticdouble()
        {
            Console.WriteLine("hello delegate");
            return 0.7d;

        }

        private static double rand()
        {
            var rand = new Random();
            return (double)(new Random()).NextDouble();

        }


        private static double one()
        {

            return 1d;

        }

        private static double two()
        {

            return 2d;

        }


        private static double three()
        {

            return 3d;

        }


        public static bool checkIfNull(Object input)
        {

            return !(input != null);


        }

        //YIELD INCREMENTOR
        /*
        private static IEnumerable<double> increment() {

            double value = 0;

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

    }
}
