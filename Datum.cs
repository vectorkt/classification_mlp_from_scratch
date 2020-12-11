using System;
using System.Collections.Generic;
using System.Text;

namespace MLPScratch
{
    class Datum
    {
        public Tensor input { get; }
        public Tensor output { get; }

        public Tensor oneHotEncoding { get; }


        public Datum(double[] input, double[] output) {

            this.input = new Tensor(input);
            this.output = new Tensor(output);
            this.oneHotEncoding = new Tensor(this.oneHotEncode(output));


        }

        public double[] oneHotEncode(double[] output) {

            double[] encoding = new double[((int[])input.getShape())[0]];

           encoding[((int)output[0])] = 1;


            return encoding;
        }

        public override String ToString() {

            String output_string = "";

            output_string += "Input:\n";
            output_string += this.input.ToString();            
            output_string += "\n\n";

            output_string += "Output:\n";
            output_string += this.output.ToString();
            output_string += "\n\n";

            output_string += "One Hot Encoding:\n";
            output_string += this.oneHotEncoding.ToString();
            output_string += "\n\n";
            /**/

            return output_string;



        }


        /*
        public override String ToString() {

            String output_string = "input: [ ";

            for (int i = 0; i < input.Length; i++) {

                output_string += this.input[i].ToString()+", ";
            
            }

            output_string += "]";

            output_string += " output: [ " + this.output[0].ToString() + " ] ";

            output_string += " onehot: [ ";


            for (int i = 0; i < oneHotEncoding.Length; i++)
            {

                output_string += this.oneHotEncoding[i].ToString() + ", ";

            }

            output_string += "]";

            return output_string;
            
        
        }
        /**/


    }
}
