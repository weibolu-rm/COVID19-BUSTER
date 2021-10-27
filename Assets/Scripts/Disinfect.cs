using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disinfect : MonoBehaviour
{
    private List<InfectedArea> _proximityList = new List<InfectedArea>();
    private int _proximityCount;

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Infection"))
        {
            var infection = other.GetComponent<InfectedArea>();
            _proximityList.Add(infection);
            _proximityCount++;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Infection"))
        {
            var infection = other.GetComponent<InfectedArea>();
            _proximityList.Remove(infection);
            _proximityCount--;
        }
    }


    public void OnDisinfectInput()
    {
        if (_proximityCount == 0) return;

        foreach (var infection in _proximityList)
        {
            infection.OnDisinfected();
        }
    }
}
