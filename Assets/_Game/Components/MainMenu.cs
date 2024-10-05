using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [HideInInspector] public int startScene;
    

    public void OpenStartScene()
    {
        SceneManager.LoadScene(startScene);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
