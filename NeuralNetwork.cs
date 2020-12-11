using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MLPScratch
{
    class NeuralNetwork
    {

        List<Layer> layers;

        public NeuralNetwork(int input_size, int hidden_layer_size, int output_size)
        {

            this.layers = new List<Layer>();
            this.addFullLayer(input_size, hidden_layer_size);
            this.addHiddenLayer(hidden_layer_size);
            //self.addHiddenLayer(hidden_layer_size)
            this.addFullLayer(hidden_layer_size, output_size);

        }

        private void addHiddenLayer(int hidden_layer_size) {

            this.layers.Add(new Layer(hidden_layer_size));
        }

        private void addFullLayer(int input_size,int hidden_layer_size) { 
            this.layers.Add(new Layer(input_size, hidden_layer_size));
        }

        private double sigmoid(double number) {
            
            return 1.0 / (1.0 + Math.Exp(-(number)));          


        }

 

        private Tensor activation(Tensor vector)
        {

            return new Tensor(vector).applyFunction(this.sigmoid);


        }


        private Tensor forwardProp(Tensor input_vector) {

            Tensor result = new Tensor(input_vector);

            foreach (Layer l in this.layers) {

                result = l.weights * result;
                result = result.applyFunction(this.sigmoid);
                l.output = new Tensor(result);
            }

            return result;
        
        }



        private double sigmoid_derivative(double number) {

            return number * (1.0 - number);

        }


        private Tensor transfer_derivative(Tensor vector) {

            return new Tensor(vector).applyFunction(this.sigmoid_derivative);
        
        }


        private void backProp(Tensor expected) {

            Layer layer, next_layer;
            Tensor error, delta, output_derivative, transposed_weights;

            int nr_layers = this.layers.Count;
            int[] reversed_layers_indices = Enumerable.Range(0, nr_layers).Select(x => x ).Reverse().ToArray();

            foreach (int l in reversed_layers_indices) {

                layer = this.layers[l];
                

                if (l == nr_layers-1)
                {

                    error = expected - layer.output;

                }
                else {

                    next_layer = this.layers[l + 1];

                    transposed_weights = next_layer.weights.transpose();

                    error = transposed_weights*next_layer.delta;
                
                }

                output_derivative = this.transfer_derivative(layer.output);

                layer.delta = error.elementWise(output_derivative);
            
            }

        }




        //training example first
        private void updateWeights(Tensor datum_input, double learning_rate) {


            Tensor input;
            Layer layer,previous_layer;

            for (int l = 0; l<this.layers.Count; l++) {

                layer = this.layers[l];


                input = new Tensor(datum_input);

                if (l != 0) {
                    previous_layer = this.layers[l - 1];
                    input = previous_layer.output;
                }

                layer.weights = new Tensor(layer.weights + learning_rate * (layer.delta * input.transpose()));



                
            
            }
        
        
        }


        public void train(Dataset dataset, double learning_rate, int epochs) {

            Tensor prediction,expected;

            Double MSE;


            Console.WriteLine("starring trainig");

            for (int e = 0; e < epochs; e++) {

                MSE = 0;

                foreach (Datum d in dataset.data) {

                    prediction = this.forwardProp(d.input);

                    expected = d.oneHotEncoding;


                    MSE += Math.Pow((expected - prediction).sum(),2);

                    this.backProp(expected);

                    this.updateWeights(d.input, learning_rate);                
                
                }

                Console.WriteLine("Epoch: " + e + " MSE: " + MSE);
            
            
            }

            
        
        }



        public Tensor predict(Tensor input_vector)
        {

            Tensor result = new Tensor(input_vector);

            foreach (Layer l in this.layers)
            {

                result = l.weights * result;
                result = result.applyFunction(this.sigmoid);
                
            }

            result = result.applyFunction(Math.Round);

            return result;

        }

    }
}
