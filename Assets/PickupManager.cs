using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupManager : MonoBehaviour
{
    [SerializeField] private GameObject vaccinePickup;
    [SerializeField] private GameObject maskPickup;

    private List<Transform> _locations = new List<Transform>();

    public FloatValue activePickupCounter;
    
    private int _childCount;
    // Start is called before the first frame update
    private void Start()
    {
        _childCount = transform.childCount;
        for (int i = 0; i < _childCount; i++)
        {
           _locations.Add(transform.GetChild(i)); 
        }
        
    }
    public void OnTenTickEvent()
    {
        if (activePickupCounter.runTimeValue > 5) return;
        
        // Chance of vaccine spawn
        if (Probabilities.ChooseBasedOnProbability(Probability.Low))
        {
            Instantiate(vaccinePickup, _locations[Random.Range(0, _childCount)]);
        }
        // Chance of mask spawn
        if (Probabilities.ChooseBasedOnProbability(Probability.Medium))
        {
            Instantiate(maskPickup, _locations[Random.Range(0, _childCount)]);
        }
        
        
    }
}
