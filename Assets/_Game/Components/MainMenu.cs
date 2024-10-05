using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [HideInInspector] public int startScene;
    [SerializeField] GameObject fade;

    public void OpenStartScene()
    {
        fade.SetActive(true);
        fade.LeanScale(new Vector3(25, 25, 25), .3f).setOnComplete(() => SceneManager.LoadScene(startScene));


    }

    public void Quit()
    {
        Application.Quit();
    }
}
