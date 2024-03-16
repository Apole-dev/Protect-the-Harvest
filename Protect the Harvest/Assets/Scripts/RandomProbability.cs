using System;
using System.Linq;
using Singleton;
using UnityEngine;
using Random = UnityEngine.Random;


public class RandomProbability:MonoBehaviour
{
    /// <summary>
    /// Given an array of probabilities and an array of numbers, returns the index of the number with the probability
    /// </summary>
    /// <param name="probabilities"></param>
    /// <param name="numbers"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static float WeightedProbability(float[] probabilities, float[] numbers)    
    {
        
        if (numbers.Length != probabilities.Length)
            throw new ArgumentException("Probabilities and numbers must have the same length.");

        float[] weights = probabilities; 

        float totalWeight = weights.Sum();
        float randomValue = Random.Range(0f, totalWeight);
        float accumulatedWeight = 0f;
        
        for (int i = 0; i < weights.Length; i++)
        {
            accumulatedWeight += weights[i];
            
            if (randomValue <= accumulatedWeight)
                return numbers[i];
        }
        return -1;
    }
    
    /// <summary>
    /// Given an array of probabilities and an array of numbers, returns the index of the number with the probability
    /// </summary>
    /// <param name="probabilities"></param>
    /// <param name="numbers"></param>
    /// <returns> </returns>
    /// <exception cref="ArgumentException"></exception>
    public static int WeightedProbability(int[] probabilities, int[] numbers)    
    {
        if (numbers.Length != probabilities.Length)
            throw new ArgumentException("Probabilities and numbers must have the same length.");
        
        
        int[] weights = probabilities;
        int totalWeight = weights.Sum();
        
        int randomValue = (int)Random.Range(0f, totalWeight);
        int accumulatedWeight = 0;
        
        for (int i = 0; i < weights.Length; i++)
        {
            accumulatedWeight += weights[i];
            
            if (randomValue <= accumulatedWeight)
                return numbers[i];
            
        }
        return -1;
    }
    
}