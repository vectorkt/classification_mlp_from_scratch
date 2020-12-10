using System;
using System.Collections.Generic;
using System.Text;

namespace MLPScratch
{
    class Layer
    {
        public Tensor weights;
        public Tensor output;
        public Tensor delta;

        public Layer(int input_size, int output_size=0) {
            if (output_size == 0)
            {
                this.weights = new Tensor(input_size, input_size);                

            }
            else {

                this.weights = new Tensor(output_size, input_size);
                
            }

        }


    }
}
