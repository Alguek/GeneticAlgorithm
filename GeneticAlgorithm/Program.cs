using System;
using System.Collections.Generic;
using System.Linq;
using GeneticAlgorithm.Controller;
using GeneticAlgorithm.Model;

namespace GeneticAlgorithm
{
    // Codigo convertido de C para C#
    // https://www.geeksforgeeks.org/genetic-algorithms/
    class Program
    {
        static void Main(string[] args)
        {
            IndividualController _individualController = new IndividualController();

            if(args.Length==0)
                Constants.Target = "Created by Alguek";
            else
                Constants.Target = args[0];

            // Geração atual
            // Current generation
            int generation = 0;

            List<Individual> population = new List<Individual>();
            bool found = false;

            // Cria população inicial
            // Create initial population 
            for (int i = 0; i < Constants.POPULATION_SIZE; i++)
            {
                string gnome = _individualController.CreateGnome();
                population.Add(new Individual(gnome));
            }

            while (!found)
            {
                // Ordena a população na ordem da Accuracy
                // Sort the population by the order of Accuracy score
                population = population.OrderByDescending(x => x.Accuracy).ToList();

                // Se o individual tem mais Accuracy do que o Target
                // significa que ele achou a melhor resposta
                // e o programa vai parar
                // if the individual having highness Accuracy score ie.  
		        // target size then we know that we have reached to the target 
		        // and break the loop
                if (population[0].Accuracy >= Constants.Target.Length)
		        {
			        found = true;
			        break;
		        }

                // Caso contrario cria uma nova geração de filhos
                // Otherwise generate new offsprings for new generation 
                List<Individual> new_generation = new List<Individual>();

                // Pega apenas os melhores, apenas os 10% filhos com mais Accuracy da geração anterior
                // vai para a nova geração
                // Perform Elitism, that mean 10% of fittest population 
                // goes to the next generation 
                int s = (10 * Constants.POPULATION_SIZE) / 100;
                new_generation = population.GetRange(0, s);


                // Os 50% melhores da population vão dar "mate"
                // e criar novos filhos
                // From 50% of fittest population, Individuals 
                // will mate to produce offspring 
                s = (90 * Constants.POPULATION_SIZE) / 100;
                for (int i = 0; i < s; i++)
                {
                    int r1 = new Random((int)DateTime.Now.Ticks & 0x0000FFFF).Next(0, 50);
                    int r2 = new Random((int)DateTime.Now.Ticks & 0x0000FFFF).Next(0, 50);

                    Individual parent1 = population[r1];
                    Individual parent2 = population[r2];

                    Individual offspring = _individualController.Mate(parent1, parent2);

                    new_generation.Add(offspring);
                }

                population = new_generation;

                Console.WriteLine("Generation: " + generation + "\t");

                Console.WriteLine("String: " + population[0].Chromosome + "\t");

                Console.WriteLine("Fitness: " + population[0].Accuracy + "\t \n");

                generation++;
            }

            Console.WriteLine("Generation: " + generation + "\t");

            Console.WriteLine("String: " + population[0].Chromosome + "\t");

            Console.WriteLine("Fitness: " + population[0].Accuracy + "\t");
        }
    }
}
