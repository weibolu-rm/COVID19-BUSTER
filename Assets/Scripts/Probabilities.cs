using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public enum Probability
{
    Low,
    Medium,
    High,
    Guaranteed
}
public static class Probabilities
{

    public static bool ChooseBasedOnProbability(Probability p)
    {
        float threshold = p switch
        {
            Probability.Low => 0.2f,
            Probability.Medium => 0.5f,
            Probability.High => 0.8f,
            Probability.Guaranteed => 1f,
            _ => 0f
        };

        // [0.0, 1.0]
        float val = Random.value;

        return (val <= threshold);
    }
}
