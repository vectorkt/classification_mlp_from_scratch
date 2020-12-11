using System;
using System.Collections.Generic;
using System.Text;

namespace MLPScratch
{
    class Dataset
    {

        public List<Datum> data=new List<Datum>();

        public Dataset(double[,] raw_dataset) {

            double[] input, output;




            for (int r = 0; r < raw_dataset.GetLength(0); r++)
            {

                input = new double[raw_dataset.GetLength(1)-1];
                output = new double[1];


                for (int c = 0; c < raw_dataset.GetLength(1)-1; c++)
                {

                    input[c] = raw_dataset[r, c];

                }

                output[0] = raw_dataset[r, raw_dataset.GetLength(1) - 1];


                this.data.Add(new Datum(input, output));


            }

        }


    }
}
