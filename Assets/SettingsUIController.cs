using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SettingsUIController : MonoBehaviour
{
    // Reloads the presentation scene
    public void ResetPresentation()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Returns to the title screen
    public void ReturnToTitle()
    {
        SceneManager.LoadScene("TitleScreen");
    }
}
