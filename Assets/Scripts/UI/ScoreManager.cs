using System;
using TMPro;
using UnityEngine;

namespace UI
{
    public class ScoreManager : MonoBehaviour
    {
        [SerializeField] private FloatValue score;
        [SerializeField] private TextMeshProUGUI scoreText;

        private void Start()
        {
            Initialize();
        }

        private void Initialize()
        {
            scoreText.text = score.initialValue.ToString();
        }
        
        public void OnScoreUpdate()
        {
            scoreText.text = score.runTimeValue.ToString();
        }
    }
}
