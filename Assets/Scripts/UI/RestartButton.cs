using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace snake
{
    public class RestartButton : MonoBehaviour
    {
        public void RestartGame(int sceneID)
        {
            Core.DiscardScore();
            SceneManager.LoadScene(sceneID);
        }
    }
}
