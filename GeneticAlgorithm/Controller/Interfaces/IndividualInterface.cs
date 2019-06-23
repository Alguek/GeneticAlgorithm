using GeneticAlgorithm.Model;

namespace GeneticAlgorithm.Controller.Interfaces
{
    public interface IndividualInterface
    {

        Individual Mate(Individual parent1, Individual parent2);

        char MutatedGenes();

    }
}
