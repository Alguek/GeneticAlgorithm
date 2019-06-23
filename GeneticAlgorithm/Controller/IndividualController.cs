using GeneticAlgorithm.Controller.Interfaces;
using GeneticAlgorithm.Model;
using System;

namespace GeneticAlgorithm.Controller
{
    public class IndividualController : IndividualInterface
    {
        public Individual Mate(Individual parent1, Individual parent2)
        {
            string child_chromosome = "";

            var len = parent2.Chromosome.Length;

            for (int i = 0; i < len; i++)
            {
                int rand = new Random((int) DateTime.Now.Ticks & 0x0000FFFF).Next(0, 100);

                if (rand < 45)
                    child_chromosome += parent1.Chromosome[i];

                else if (rand < 90)
                    child_chromosome += parent2.Chromosome[i];

                else
                    child_chromosome += MutatedGenes();

            }

            return new Individual(child_chromosome);
        }

        public char MutatedGenes()
        {
            int rand = new Random((int) DateTime.Now.Ticks & 0x0000FFFF).Next(0, Constants.GENES.Length);

            return Constants.GENES[rand];
        }

        public string CreateGnome()
        {
            if (Constants.Target == null)
                throw new Exception("Target não pode ser null ou vazio");

            var len = Constants.Target.Length;

            string gnome = "";
	        for (int i = 0; i < len; i++)
		        gnome += MutatedGenes();
	        return gnome;

        }
    }
}
