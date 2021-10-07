
using UnityEngine;
using Unity.Collections;
using System.Collections.Generic;


namespace snake
{
    public static class Core
    {
        public static int CrystalScore = 0;
        public static int DeathsScore = 0;
        public static bool IsGameEnded = false;
        public static bool IsFever = false;

        public static int crystalStreak = 0;

        public delegate void CrystalEvent();
        public static CrystalEvent crystalEvent;
        
        public delegate void DeathEvent();
        public static DeathEvent deathlEvent;
        
        public delegate void EndGameEvent();
        public static EndGameEvent endGameEvent;
        
        public delegate void FeverEvent();
        public static FeverEvent feverEvent;
        
        public static void AddCrystalScore()
        {
            CrystalScore = Mathf.Clamp(CrystalScore + 1, 0, 100);
            crystalStreak++;
            crystalEvent();
            if (crystalStreak.Equals(3) && !IsFever)
            {
                EnterFever();
                crystalStreak = 0;
            }
        }

        public static void EnterFever()
        {
            IsFever = true;
            feverEvent();
        }

        public static void ExitFever()
        {
            IsFever = false;
            CrystalScore = 0;
            crystalStreak = 0;
        }
        
        public static void AddDeathScore()
        {
            DeathsScore = Mathf.Clamp(DeathsScore + 1, 0, 100);
            crystalStreak = 0;
            deathlEvent();
        }

        public static void EndGame()
        {
            IsGameEnded = true;
            endGameEvent();
        }

        public static void DiscardScore()
        {
            CrystalScore = 0;
            crystalStreak = 0;
            DeathsScore = 0;
            IsGameEnded = false;
            IsFever = false;
        }
    }
}