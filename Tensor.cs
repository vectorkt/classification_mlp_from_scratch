using System;
using System.Collections.Generic;
using System.Text;

namespace MLPScratch
{
    class Tensor
    {

        public Array values;
        private static double rand()
        {
            var rand = new Random();
            return (double)(new Random()).NextDouble();

        }

        public Tensor()
        {
            this.values = LinearAlgebra.generateTensor( ()=>1 ,3,2);
        }


        public Tensor(Array arrayInput)
        {


            if (arrayInput.Rank == 1) {

               
                int cols = arrayInput.Length;

                double[] linearArray = (double[])arrayInput;

                double[,] array1D = new double[1, cols];




                for (int c = 0; c < cols; c++)
                {
                    array1D[0, c] = linearArray[c];
                }
                
                this.values = LinearAlgebra.transpose(array1D);                
             
            }

            else { 

            
                Array array = (Array)arrayInput.Clone();

                this.values = array;

            }
        }




        public Tensor(Tensor tensor)
        {

            Array array = (Array)tensor.values.Clone();
            this.values = array;
        }


        public Tensor(Func<double> generatorFunction, params int[] dims)
        {
            this.values = LinearAlgebra.generateTensor(generatorFunction, dims);
        }


        public Tensor( params int[] dims)
        {
            this.values = LinearAlgebra.generateTensor(rand, dims);
        }


        public void print()
        {

            LinearAlgebra.printTensor(this.values);

        }

        public void printShape() {

            LinearAlgebra.printTensor(LinearAlgebra.shape(this.values));
        
        }

        public Array getShape() {

            return LinearAlgebra.shape(this.values);


        }
        
        public static Tensor operator +(Tensor a, Tensor b)
        {

            return new Tensor(LinearAlgebra.addition(a.values, b.values));
            
            
        }


        public static Tensor operator -(Tensor a, Tensor b)
        {

            return new Tensor(LinearAlgebra.subtraction(a.values, b.values));


        }


        public static Tensor operator *(Tensor a, Tensor b)
        {

            return new Tensor(LinearAlgebra.tensorMutiplication(a.values, b.values));


        }




        public static Tensor operator *(double a, Tensor b)
        {

            return new Tensor(LinearAlgebra.scalarMultiplication(a, b.values));


        }


        public static Tensor operator *(Tensor b, double a)
        {

            return new Tensor(LinearAlgebra.scalarMultiplication(a, b.values));


        }



        public Tensor elementWise(Tensor b)
        {

            return new Tensor(LinearAlgebra.elementWiseMultiplication(this.values, b.values));

        }

        public Tensor applyFunction(Func<double, double> function)
        {

            return new Tensor(LinearAlgebra.applyFunction(this.values, function)) ;

        }

        public Tensor transpose() {

            return new Tensor(LinearAlgebra.transpose(this.values));
        
        }



        public double sum() {

            return LinearAlgebra.sum(this.values);
        
        
        }

        public override string ToString()
        {           

            if (this.values.Rank > 2) {

                throw new System.ArgumentException("only 2D tensor ToString() supported");

            }
            
            double[,] values = (double[,]) this.values;
            
            int rows = values.GetLength(0);
            int cols = values.GetLength(1);



            String output_string = "[ \n";

            for (int r = 0; r < rows; r++)
            {
                output_string += " [ ";

                for (int c = 0; c < cols; c++) {

                    output_string += values[r,c].ToString() + ", ";

                }
                output_string += "]\n";


            }
            output_string += "]";

            return output_string;



        }


 

        /**/
    }
}
