using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class InfectedArea : MonoBehaviour
{

    [SerializeField] private List<InfectionSpreader> creepAreas = new List<InfectionSpreader>();
    
    public void OnTickEvent()
    {
        if (Probabilities.ChooseBasedOnProbability(Probability.Low))
        {
            int index = Random.Range(0, creepAreas.Count);
            if (creepAreas[index].canSpawn)
            {
                creepAreas[index].Infect();
            }
            
        }
        
    }
    

}
