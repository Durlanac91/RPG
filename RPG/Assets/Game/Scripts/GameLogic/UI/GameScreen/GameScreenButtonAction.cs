using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.GameLogic.UI
{
    public class GameScreenButtonAction : MonoBehaviour
    {
        public void OpenUIPanelSettings()
        {
            UIPanelSettings.Instance.Show();
        }

        public void OpenUIPanelPlayerGear()
        {
            UIPanelPlayerGear.Instance.Show();
        }

        public void ExitToMain()
        {
            SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
        }
    }
}