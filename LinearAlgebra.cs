using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNet
{
    class LinearAlgebra
    {

        static public void printArray(int[] arr) {

            Console.Write("[ ");
            foreach(var a in arr)
            {

                Console.Write(a+" ");

            }
            Console.Write("]");

        }

        static public void printTensor(System.Array array)
        {



            
            int[] index =  new int[array.Rank];// = new int[] { 0, 0, 0 };

            //initialize indexes
            for (int i = 0; i < index.Length; i++) {

                index[i] = 0;
            
            }


            Console.WriteLine();
            printNArrayRecursive(array, index, 0);



            //[time,depth,row,col]
            //Console.WriteLine(array[1, 0, 0]);


            //Console.WriteLine(array.GetValue(index));


        }

        static private void printNArrayRecursive(System.Array array, int[] index, int dim)
        {

            //Console.WriteLine(dim);
            //Console.WriteLine(array.Rank);
            //Console.WriteLine(array.GetLength(dim-1));




            if (dim == array.Rank-1)
            {
                //Console.WriteLine();
                Console.Write("[ ");

                for (int i = 0; i < array.GetLength(dim); i++)
                {

                    index[dim] = i;

                    Console.Write(array.GetValue(index) + " ");

                }

                Console.WriteLine("]");




            }
            else {

                //Console.Write("[ ");
                for (int i = 0; i < array.GetLength(dim); i++)
                {

                    index[dim] = i;

                    printNArrayRecursive(array, index, dim + 1);

                }
                //Console.WriteLine("]");
                Console.WriteLine();
               
            }
            /**/

            //Console.WriteLine(array.Rank);
            //if()


        }


        public delegate decimal generatorFunctionDelegate();


        private static decimal staticDecimal()
        {
            Console.WriteLine("hello delegate");
            return 0.7M;

        }

        static public Array generateTensor(generatorFunctionDelegate generatorFunction, params int[] dims ) {

            int[] myLengthsArray = dims;


            Array array = Array.CreateInstance(typeof(decimal), dims);


            int[] index = dims;


            for (int i = 0; i < index.Length;i++) {
               index[i] = 0;
            }

            

            generateTensorRecursive(array, index, 0 ,generatorFunction);

            

            return array;


        }



        static private void generateTensorRecursive(System.Array array, int[] index, int dim, generatorFunctionDelegate generatorFunction)
        {

           

            if (dim == array.Rank - 1)
            {
                
                for (int i = 0; i < array.GetLength(dim); i++)
                {
                    
                    index[dim] = i;
                    
                    array.SetValue(generatorFunction(), index);
                    
                }
                
            }
            else
            {
                for (int i = 0; i < array.GetLength(dim); i++)
                {
                    
                    index[dim] = i;
                    
                    generateTensorRecursive(array, index, dim + 1, generatorFunction);

                }
                
                

            }


        }





        static public Array scalarMultiplication(Decimal scalar, Array tensorInput)
        {

            Array tensor = (Array)tensorInput.Clone();

            int[] index = new int[tensor.Rank];// = new int[] { 0, 0, 0 };

            //initialize indexes
            for (int i = 0; i < index.Length; i++)
            {

                index[i] = 0;

            }


            
            scalarMultiplicationRecursive(tensor, index, 0, scalar);

            return tensor;

        }

        static private void scalarMultiplicationRecursive(System.Array array, int[] index, int dim,Decimal scalar)
        {
            
            if (dim == array.Rank - 1)
            {

                for (int i = 0; i < array.GetLength(dim); i++)
                {

                    index[dim] = i;
                    
                    Decimal value = (Decimal) array.GetValue(index);                  

                    value *= scalar;

                    array.SetValue(value, index);

                }

            }
            else
            {

                for (int i = 0; i < array.GetLength(dim); i++)
                {

                    index[dim] = i;

                    scalarMultiplicationRecursive(array, index, dim + 1,scalar);

                }             

            }     

        }



        static public Array addition(Array tensorInputA, Array tensorInputB)
        {

            Array tensorA = (Array)tensorInputA.Clone();
            Array tensorB = (Array)tensorInputB.Clone();

            if (tensorA.Rank != tensorB.Rank) { 
            
                throw new System.ArgumentException("tensor sizes don't match");

            }
            else
            {

                for (int d = 0; d < tensorA.Rank; d++)
                {

                    if (tensorA.GetLength(d) != tensorB.GetLength(d))
                    {

                        throw new System.ArgumentException("tensor sizes don't match");

                    }


                }


            }

            int[] index = new int[tensorA.Rank];// = new int[] { 0, 0, 0 };

            //initialize indexes
            for (int i = 0; i < index.Length; i++)
            {

                index[i] = 0;

            }


            
            additionRecursive(tensorA, tensorB, index, 0);

            return tensorA;

        }

        static private void additionRecursive(System.Array tensorA, System.Array tensorB, int[] index, int dim)
        {

            if (dim == tensorA.Rank - 1)
            {

                for (int i = 0; i < tensorA.GetLength(dim); i++)
                {

                    index[dim] = i;

                    Decimal valueA = (Decimal)tensorA.GetValue(index);
                    Decimal valueB = (Decimal)tensorB.GetValue(index);

                    Decimal value = valueA+valueB;

                    tensorA.SetValue(value, index);

                }

            }
            else
            {

                for (int i = 0; i < tensorA.GetLength(dim); i++)
                {

                    index[dim] = i;

                    additionRecursive(tensorA, tensorB, index, dim + 1);

                }

            }

        }


        static public Array subtraction(Array tensorInputA, Array tensorInputB)
        {

            Array tensorA = (Array)tensorInputA.Clone();
            Array tensorB = (Array)tensorInputB.Clone();

            if (tensorA.Rank != tensorB.Rank)
            {

                throw new System.ArgumentException("tensor sizes don't match");




            }
            else {

                for (int d = 0; d < tensorA.Rank; d++) {

                    if (tensorA.GetLength(d) != tensorB.GetLength(d)) {

                        throw new System.ArgumentException("tensor sizes don't match");

                    }
                    
                
                }
                
            
            }

            int[] index = new int[tensorA.Rank];// = new int[] { 0, 0, 0 };

            //initialize indexes
            for (int i = 0; i < index.Length; i++)
            {

                index[i] = 0;

            }


            
            subtractionRecursive(tensorA, tensorB, index, 0);

            return tensorA;

        }

        static private void subtractionRecursive(System.Array tensorA, System.Array tensorB, int[] index, int dim)
        {

            if (dim == tensorA.Rank - 1)
            {

                for (int i = 0; i < tensorA.GetLength(dim); i++)
                {

                    index[dim] = i;

                    Decimal valueA = (Decimal)tensorA.GetValue(index);
                    Decimal valueB = (Decimal)tensorB.GetValue(index);

                    Decimal value = valueA - valueB;

                    tensorA.SetValue(value, index);

                }

            }
            else
            {

                for (int i = 0; i < tensorA.GetLength(dim); i++)
                {

                    index[dim] = i;

                    subtractionRecursive(tensorA, tensorB, index, dim + 1);

                }

            }

        }


        static public Array elementWiseMultiplication(Array tensorInputA, Array tensorInputB)
        {

            Array tensorA = (Array)tensorInputA.Clone();
            Array tensorB = (Array)tensorInputB.Clone();

            if (tensorA.Rank != tensorB.Rank)
            {

                throw new System.ArgumentException("tensor sizes don't match");

            }
            else
            {

                for (int d = 0; d < tensorA.Rank; d++)
                {

                    if (tensorA.GetLength(d) != tensorB.GetLength(d))
                    {

                        throw new System.ArgumentException("tensor sizes don't match");

                    }


                }


            }

            int[] index = new int[tensorA.Rank];// = new int[] { 0, 0, 0 };

            //initialize indexes
            for (int i = 0; i < index.Length; i++)
            {

                index[i] = 0;

            }



            elementWiseMultiplicationRecursive(tensorA, tensorB, index, 0);

            return tensorA;

        }

        static private void elementWiseMultiplicationRecursive(System.Array tensorA, System.Array tensorB, int[] index, int dim)
        {

            if (dim == tensorA.Rank - 1)
            {

                for (int i = 0; i < tensorA.GetLength(dim); i++)
                {

                    index[dim] = i;

                    Decimal valueA = (Decimal)tensorA.GetValue(index);
                    Decimal valueB = (Decimal)tensorB.GetValue(index);

                    Decimal value = valueA * valueB;

                    tensorA.SetValue(value, index);

                }

            }
            else
            {

                for (int i = 0; i < tensorA.GetLength(dim); i++)
                {

                    index[dim] = i;

                    elementWiseMultiplicationRecursive(tensorA, tensorB, index, dim + 1);

                }

            }

        }


        static public Array concatenateRows(Array tensorInputA, Array tensorInputB)
        {


            Decimal[,] tensorA = (Decimal[,])tensorInputA.Clone();
            Decimal[,] tensorB = (Decimal[,])tensorInputB.Clone();

            int rowsA  = tensorA.GetLength(0);
            int colsA = tensorA.GetLength(1);

            int rowsB  = tensorB.GetLength(0);
            int colsB = tensorB.GetLength(1);

            if (rowsA != rowsB) {

                throw new System.ArgumentException("tensor sizes don't match");

            }

            //Console.WriteLine("A: " + rowsA + " " + colsA);
            //Console.WriteLine("B: " + rowsB + " " + colsB);

            //Console.WriteLine();

            Decimal[,] result = new Decimal[rowsA + rowsB, colsA];

            int rr = 0;


            for (int r = 0; r < rowsA; r++, rr++)
            {

                for (int c = 0; c < colsA; c++)
                {
                    Console.WriteLine(tensorA[r, c]);
                    result[rr, c] = tensorA[r, c];
                }

                
            }

            for (int r = 0; r < rowsB; r++, rr++)
            {
                for (int c = 0; c < colsB; c++ )
                {
                    Console.WriteLine(tensorB[r, c]);
                    result[rr, c] = tensorB[r, c];
                }



            }



            return result;

        }




        static public Array concatenateColumns(Array tensorInputA, Array tensorInputB)
        {


            Decimal[,] tensorA = (Decimal[,])tensorInputA.Clone();
            Decimal[,] tensorB = (Decimal[,])tensorInputB.Clone();

            int rowsA = tensorA.GetLength(0);
            int colsA = tensorA.GetLength(1);

            int rowsB  = tensorB.GetLength(0);
            int colsB = tensorB.GetLength(1);


            if (colsA != colsB)
            {

                throw new System.ArgumentException("tensor sizes don't match");

            }

            //Console.WriteLine("A: " + rowsA  + " " + colsA);
            //Console.WriteLine("B: " + rowsB  + " " + colsB);

            //Console.WriteLine();

            Decimal[,] result = new Decimal[rowsA, colsA + colsB];

            int cr = 0;

            for (int c = 0; c < colsA; c++, cr++) {
                for (int r = 0; r < rowsA; r++) {
                    
                    result[r, cr] = tensorA[r, c];
                }
            }
            

            for (int c = 0; c < colsB; c++, cr++)
            {
                for (int r = 0; r < rowsB; r++)
                {
                    
                    result[r, cr] = tensorB[r, c];
                }
            }


            return result;

        }


        /**/


        static public Array transpose(Array tensorInput) {

            
            Decimal[,] tensor = (Decimal[,])tensorInput.Clone();

            int rows = tensor.GetLength(0);
            int cols = tensor.GetLength(1);

            Decimal[,] transposed = new Decimal[cols, rows];

            for (int c = 0; c < cols; c++) {


                for (int r = 0; r < rows; r++) {

                    transposed[c, r] = tensor[r, c];
                
                }
            
            }

            return transposed;


        }



        static private Array  getRow(Array tensorInput, int row ) {

            Decimal[,] tensor = (Decimal[,])tensorInput.Clone();

            int cols = tensor.GetLength(1);

            Decimal[,] result = new decimal[1, cols];


            for (int c = 0; c < cols; c++) {
                
                result[0, c] = tensor[row, c];
            }

            return result;


        }


        static private Array getCol(Array tensorInput, int col)
        {

            Decimal[,] tensor = (Decimal[,])tensorInput.Clone();

            int rows = tensor.GetLength(0);

            Decimal[,] result = new decimal[rows, 1];


            for (int r = 0; r < rows; r++)
            {
                result[r, 0] = tensor[r, col];
            }

            return result;


        }


        static public Array matrixToVector(Array matrixInput,Array vectorInput) {



            Decimal[,] matrix = (Decimal[,])matrixInput.Clone();
            Decimal[,] vector = (Decimal[,])vectorInput.Clone();

            int rowsM = matrix.GetLength(0);
            int colsM = matrix.GetLength(1);
            int rowsV = vector.GetLength(0);
            int colsV = vector.GetLength(1);


            if (colsM != rowsV) {

                throw new System.ArgumentException("tensor sizes don't match");

            }

            Decimal[,] transpose = (decimal[,]) LinearAlgebra.transpose(vector);
            Decimal[,] result = new Decimal[rowsM,1];


            Array col;

            for (int c = 0; c < colsM; c++) {
                
                col = LinearAlgebra.getCol(matrix, c);
                
                col = LinearAlgebra.scalarMultiplication(transpose[0, c], col);
                
                result = (decimal[,])LinearAlgebra.addition(result, col);
                


            }

            

            return result;
        
        
        }


        static public Array tensorMutiplication(Array tensorInputA, Array tensorInputB)
        {


            Decimal[,] tensorA = (Decimal[,])tensorInputA.Clone();
            Decimal[,] tensorB = (Decimal[,])tensorInputB.Clone();

            int rowsA = tensorA.GetLength(0);
            int colsA = tensorA.GetLength(1);

            int rowsB = tensorB.GetLength(0);
            int colsB = tensorB.GetLength(1);


            if (colsA != rowsB)
            {

                throw new System.ArgumentException("tensor sizes don't match");

            }

            Array nextColumn = LinearAlgebra.getCol(tensorB, 0);

            Array result = LinearAlgebra.matrixToVector(tensorA, nextColumn);

            Array toConcatenate;

            for (int c = 1; c < colsB; c++) {
                
                nextColumn = LinearAlgebra.getCol(tensorB, c);
                
                toConcatenate = LinearAlgebra.matrixToVector(tensorA, nextColumn);
                
                result = LinearAlgebra.concatenateColumns(result, toConcatenate);
                
            }

            return result;

        }





    }
}
