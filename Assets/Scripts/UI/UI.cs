using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace snake
{
    public class UI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI crystalScoreText;
        [SerializeField] private TextMeshProUGUI deathScoreText;
        [SerializeField] private GameObject endGamePanel;
        
        private void Start()
        {
            Core.crystalEvent += UpdateCrystalScore;
            Core.deathlEvent += UpdateDeathScore;
            Core.endGameEvent += ShowEndGamePanel;
        }

        private void UpdateCrystalScore()
        {
            crystalScoreText.text = Core.CrystalScore.ToString();
        }

        private void UpdateDeathScore()
        {
            deathScoreText.text = Core.DeathsScore.ToString();
        }

        private void ShowEndGamePanel()
        {
            endGamePanel.SetActive(true);
        }

        private void OnDisable()
        {
            Core.crystalEvent -= UpdateCrystalScore;
            Core.deathlEvent -= UpdateDeathScore;
            Core.endGameEvent -= ShowEndGamePanel;
        }
    }
}
