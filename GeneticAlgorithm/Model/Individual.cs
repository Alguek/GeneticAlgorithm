using System;

namespace GeneticAlgorithm.Model
{
    public class Individual
    {
        public string Chromosome;
        public int Accuracy;

        public Individual(string chromosome)
        {
            this.Chromosome = chromosome;
            Accuracy = CalAccuracy();
        }

        int CalAccuracy()
        {
            if (Constants.Target == null)
                throw new Exception("Target não pode ser null ou vazio");

            var len = Constants.Target.Length;

            int accuracy = len;
            for (int i = 0; i < len; i++)
            {
                if (Chromosome[i] != Constants.Target[i])
                    accuracy--;
            }

            return accuracy;
        }

    }
}
