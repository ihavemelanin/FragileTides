using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void StartGame(){
        SceneManager.LoadScene("hungryScene");
    }
    public void QuitGame(){
        SceneManager.LoadScene("MainMenu");
    }
    public void helpMenu(){
        SceneManager.LoadScene("helpMenu");
    }
    public void backToMainMenu(){
        SceneManager.LoadScene("MainMenu");
    }
    public void exitGame(){
        Application.Quit();
    }
}
