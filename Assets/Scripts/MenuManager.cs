using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // ABSTRACTION start game
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    // ABSTRACTION quit game (within editor and stand alone)
    public void QuitGame()
    {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        Application.Quit();
    #endif
    }
}
