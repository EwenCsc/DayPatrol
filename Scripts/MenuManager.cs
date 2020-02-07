using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void Play()
    {
        GetComponent<AudioSource>().Play();
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        GetComponent<AudioSource>().Play();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public static void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
