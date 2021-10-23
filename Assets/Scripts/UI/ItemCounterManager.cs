using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ItemCounterManager : MonoBehaviour
    {

        [SerializeField] private Image[] items;
        public FloatValue itemCounter;
    
        private void Start()
        {
            InitCounter();
        }

        public void InitCounter()
        {
            for (int i = 0; i < itemCounter.initialValue; i++)
            {
                items[i].gameObject.SetActive(true);
            }
        }

        public void UpdateItemUsed()
        {
            for (int i = 0; i < itemCounter.initialValue; i++)
            {
                if(i >= itemCounter.runTimeValue)
                    items[i].gameObject.SetActive(false);
            }
        }
        
        
    }
}
