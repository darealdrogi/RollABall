using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public void EnterLevel()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Exit()
    {

        Application.Quit();

//#if UNITY_EDITOR
//        UnityEditor.EditorApplication.ExitPlaymode();//exits the playmode
//#endif
    }
}
