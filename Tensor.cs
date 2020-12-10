using System;
using System.Collections.Generic;
using System.Text;

namespace MLPScratch
{
    class Tensor
    {

        protected Array values;
        private static double rand()
        {
            var rand = new Random();
            return (double)(new Random()).NextDouble();

        }

        public Tensor()
        {
            this.values = LinearAlgebra.generateTensor( ()=>1 ,3,2);
        }

        public Tensor(Array array)
        {
            this.values = array;
        }


        public Tensor(Tensor tensor)
        {
            this.values = tensor.values;
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

        /**/
    }
}
