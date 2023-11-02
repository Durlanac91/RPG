using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.GameLogic.UI
{
    public class MainScreenButtonAction : MonoBehaviour
    {
        public void StartNewGame()
        {
            GetComponent<PlayerSave>().DeleteAllData();
            GameManager.Instance.LoadGame();
            SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
        }

        public void LoadGame()
        {
            SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
        }

        public void ExitGame()
        {
            Application.Quit();
        }
    }
}