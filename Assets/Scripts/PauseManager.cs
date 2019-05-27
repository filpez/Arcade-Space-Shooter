using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace __Shooter__
{
    public class PauseManager : MonoBehaviour
    {
        public static PauseManager instance;
        public GameObject pauseMenu;

        public bool paused = false;

        void Awake()
        {
            instance = this;
        }

        public void Pause()
        {
            Time.timeScale = 0;
            paused = true;
        }

        public void Continue()
        {
            Time.timeScale = 1;
            paused = false;
        }

        public void ActivateMenu()
        {
            pauseMenu.SetActive(true);
        }

        public void DeactivateMenu()
        {
            pauseMenu.SetActive(false);
        }
    }
}
