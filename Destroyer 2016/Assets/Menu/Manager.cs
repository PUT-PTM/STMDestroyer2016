using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{

    void Start()
    {
        Cursor.visible = false; //no show cursor
    }


    public void changeScene(string sceneName)
    {
        if (sceneName != "Exit")
            SceneManager.LoadScene(sceneName);
        else Application.Quit();
    }
}
