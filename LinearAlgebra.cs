using System;
using System.Collections.Generic;
using System.Text;

namespace MLPScratch
{
    class LinearAlgebra
    {


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

        static private void printNArrayRecursive(Array array, int[] index, int dim)
        {

            //Console.WriteLine(dim);
            //Console.WriteLine(array.Rank);
            //Console.WriteLine(array.GetLength(dim-1));




            if (dim == array.Rank-1)
            {
                
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


        static public Array shape(Array tensor) {

            int[] shape = new int[tensor.Rank];

            for (int d = 0; d < tensor.Rank; d++) {

                shape[d] = tensor.GetLength(d);
            
            }

            return shape;
            
        }


        static public Array generateTensor(Func<double>  generatorFunction, params int[] dims ) {

            int[] myLengthsArray = dims;


            Array array = Array.CreateInstance(typeof(double), dims);


            int[] index = dims;


            for (int i = 0; i < index.Length;i++) {
               index[i] = 0;
            }

            

            generateTensorRecursive(array, index, 0 ,generatorFunction);

            

            return array;


        }



        static private void generateTensorRecursive(System.Array array, int[] index, int dim, Func<double> generatorFunction)
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


       
        static public Array scalarMultiplication(double scalar, Array tensorInput)
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

        static private void scalarMultiplicationRecursive(System.Array array, int[] index, int dim,double scalar)
        {
            
            if (dim == array.Rank - 1)
            {

                for (int i = 0; i < array.GetLength(dim); i++)
                {

                    index[dim] = i;
                    
                    double value = (double) array.GetValue(index);                  

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


        static public Array applyFunction(Array tensorInput, Func<double, double> function)
        {

            Array tensor = (Array)tensorInput.Clone();

            int[] index = new int[tensor.Rank];// = new int[] { 0, 0, 0 };

            //initialize indexes
            for (int i = 0; i < index.Length; i++)
            {

                index[i] = 0;

            }



            applyFunctionRecursive(tensor, index, 0, function);

            return tensor;

        }

        static private void applyFunctionRecursive(System.Array array, int[] index, int dim, Func<double,double> function)
        {

            if (dim == array.Rank - 1)
            {

                for (int i = 0; i < array.GetLength(dim); i++)
                {

                    index[dim] = i;

                    double value = (double)array.GetValue(index);

                    value = function(value);

                    array.SetValue(value, index);

                }

            }
            else
            {

                for (int i = 0; i < array.GetLength(dim); i++)
                {

                    index[dim] = i;

                    applyFunctionRecursive(array, index, dim + 1, function);

                }

            }

        }


        static public Array addition(Array tensorInputA, Array tensorInputB) {


            return applyOperation(tensorInputA, tensorInputB, (x, y) => x + y);


        }



        static public Array subtraction(Array tensorInputA, Array tensorInputB)
        {


            return applyOperation(tensorInputA, tensorInputB, (x, y) => x - y);


        }

        static public Array elementWiseMultiplication(Array tensorInputA, Array tensorInputB)
        {


            return applyOperation(tensorInputA, tensorInputB, (x, y) => x * y);


        }


        static public Array concatenateRows(Array tensorInputA, Array tensorInputB)
        {


            double[,] tensorA = (double[,])tensorInputA.Clone();
            double[,] tensorB = (double[,])tensorInputB.Clone();

            int rowsA  = tensorA.GetLength(0);
            int colsA = tensorA.GetLength(1);

            int rowsB  = tensorB.GetLength(0);
            int colsB = tensorB.GetLength(1);

            if (colsA != colsB) {

                throw new System.ArgumentException("tensor sizes don't match");

            }

            //Console.WriteLine("A: " + rowsA + " " + colsA);
            //Console.WriteLine("B: " + rowsB + " " + colsB);

            

            double[,] result = new double[rowsA + rowsB, colsA];

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


            double[,] tensorA = (double[,])tensorInputA.Clone();
            double[,] tensorB = (double[,])tensorInputB.Clone();

            int rowsA = tensorA.GetLength(0);
            int colsA = tensorA.GetLength(1);

            int rowsB  = tensorB.GetLength(0);
            int colsB = tensorB.GetLength(1);


            if (rowsA != rowsB)
            {

                throw new System.ArgumentException("tensor sizes don't match: (" +
                    rowsA + " " + colsA + ") (" + rowsB + " " + colsB + ")");

            }

            //Console.WriteLine("A: " + rowsA  + " " + colsA);
            //Console.WriteLine("B: " + rowsB  + " " + colsB);

            //Console.WriteLine();

            double[,] result = new double[rowsA, colsA + colsB];

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

            
            double[,] tensor = (double[,])tensorInput.Clone();

            int rows = tensor.GetLength(0);
            int cols = tensor.GetLength(1);

            double[,] transposed = new double[cols, rows];

            for (int c = 0; c < cols; c++) {


                for (int r = 0; r < rows; r++) {

                    transposed[c, r] = tensor[r, c];
                
                }
            
            }

            return transposed;


        }



        static private Array  getRow(Array tensorInput, int row ) {

            double[,] tensor = (double[,])tensorInput.Clone();

            int cols = tensor.GetLength(1);

            double[,] result = new double[1, cols];


            for (int c = 0; c < cols; c++) {
                
                result[0, c] = tensor[row, c];
            }

            return result;


        }


        static private Array getCol(Array tensorInput, int col)
        {

            double[,] tensor = (double[,])tensorInput.Clone();

            int rows = tensor.GetLength(0);

            double[,] result = new double[rows, 1];


            for (int r = 0; r < rows; r++)
            {
                result[r, 0] = tensor[r, col];
            }

            return result;


        }


        static private Array matrixToVector(Array matrixInput,Array vectorInput) {



            double[,] matrix = (double[,])matrixInput.Clone();
            double[,] vector = (double[,])vectorInput.Clone();

            int rowsM = matrix.GetLength(0);
            int colsM = matrix.GetLength(1);
            int rowsV = vector.GetLength(0);
            int colsV = vector.GetLength(1);


            if (colsM != rowsV) {

                throw new System.ArgumentException("tensor sizes don't match");

            }

            double[,] transpose = (double[,]) LinearAlgebra.transpose(vector);
            double[,] result = new double[rowsM,1];


            Array col;

            for (int c = 0; c < colsM; c++) {
                
                col = LinearAlgebra.getCol(matrix, c);
                
                col = LinearAlgebra.scalarMultiplication(transpose[0, c], col);
                
                result = (double[,])LinearAlgebra.addition(result, col);
                


            }

            

            return result;
        
        
        }


        static public Array tensorMutiplication(Array tensorInputA, Array tensorInputB)
        {


            if (tensorInputA.Rank>2 || tensorInputB.Rank>2)
            {

                throw new System.ArgumentException("tensor operations greater than 2d currently not supported");

            }


            double[,] tensorA = (double[,])tensorInputA.Clone();
            double[,] tensorB = (double[,])tensorInputB.Clone();

            int rowsA = tensorA.GetLength(0);
            int colsA = tensorA.GetLength(1);

            int rowsB = tensorB.GetLength(0);
            int colsB = tensorB.GetLength(1);


            if (colsA != rowsB)
            {

                throw new System.ArgumentException("tensor sizes don't match: ("+
                    rowsA + " " + colsA + ") ("+rowsB + " " +colsB+")");

            }

            Array nextColumn = LinearAlgebra.getCol(tensorB, 0);

            /*
            Console.Write("tensorA");
            LinearAlgebra.printTensor(LinearAlgebra.shape(tensorA));
            Console.Write("nextColumn");
            LinearAlgebra.printTensor(LinearAlgebra.shape(nextColumn));
            /**/


            Array result = LinearAlgebra.matrixToVector(tensorA, nextColumn);

            Array toConcatenate;

            /*
            Console.Write("result");
            LinearAlgebra.printTensor(LinearAlgebra.shape(result));
            /**/

            for (int c = 1; c < colsB; c++) {
                
                nextColumn = LinearAlgebra.getCol(tensorB, c);


                /*
                Console.Write("tensorA");
                LinearAlgebra.printTensor(LinearAlgebra.shape(tensorA));
                Console.Write("nextColumn");
                LinearAlgebra.printTensor(LinearAlgebra.shape(nextColumn));
                /**/

                toConcatenate = LinearAlgebra.matrixToVector(tensorA, nextColumn);

                /*
                Console.Write("result");
                LinearAlgebra.printTensor(LinearAlgebra.shape(result));
                Console.Write("toConcatenate");
                LinearAlgebra.printTensor(LinearAlgebra.shape(toConcatenate));
                /**/

                result = LinearAlgebra.concatenateColumns(result, toConcatenate);
                
            }

            return result;

        }


        static public Array applyOperation(Array tensorInputA, Array tensorInputB, Func<double, double, double> operation)
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



            applyOperationRecursive(tensorA, tensorB, index, 0, operation);

            return tensorA;

        }

        static private void applyOperationRecursive(System.Array tensorA, System.Array tensorB, int[] index, int dim, Func<double, double, double> operation)
        {

            if (dim == tensorA.Rank - 1)
            {

                for (int i = 0; i < tensorA.GetLength(dim); i++)
                {

                    index[dim] = i;

                    double valueA = (double)tensorA.GetValue(index);
                    double valueB = (double)tensorB.GetValue(index);

                    double value = operation(valueA,valueB);

                    tensorA.SetValue(value, index);

                }

            }
            else
            {

                for (int i = 0; i < tensorA.GetLength(dim); i++)
                {

                    index[dim] = i;

                    applyOperationRecursive(tensorA, tensorB, index, dim + 1,operation);

                }

            }

        }


        static public double sum(Array tensorInput)
        {

            Array tensor = (Array)tensorInput.Clone();

            int[] index = new int[tensor.Rank];// = new int[] { 0, 0, 0 };

            //initialize indexes
            for (int i = 0; i < index.Length; i++)
            {

                index[i] = 0;

            }



            return sumRecursive(tensor, index, 0);

            

        }

        static private double sumRecursive(System.Array array, int[] index, int dim)
        {


            double sum = 0;

            if (dim == array.Rank - 1)
            {

                for (int i = 0; i < array.GetLength(dim); i++)
                {

                    index[dim] = i;

                    sum += (double)array.GetValue(index);

                }

                

            }
            else
            {

                for (int i = 0; i < array.GetLength(dim); i++)
                {

                    index[dim] = i;

                    sum += sumRecursive(array, index, dim + 1);

                }

            }

            return sum;

        }

    }
}
