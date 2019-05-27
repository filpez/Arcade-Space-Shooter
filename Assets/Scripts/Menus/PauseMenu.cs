using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace __Shooter__{
    public class PauseMenu : MonoBehaviour
{
    public void Continue()
    {
        PauseManager.instance.Continue();
        PauseManager.instance.DeactivateMenu();
    }

    public void MainMenu()
    {
        PauseManager.instance.Continue();
        PauseManager.instance.DeactivateMenu();
        SceneManager.LoadScene(0);
    }
}
}

