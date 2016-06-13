using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour {

    //public Texture2D cursorTexture;

    void Start()
    {
        //int cursorSizeX = 0, cursorSizeY = 0;
        //GUI.DrawTexture(new Rect(Input.mousePosition.x, (Screen.height - Input.mousePosition.y), cursorSizeX, cursorSizeY), cursorTexture);
        Cursor.visible = false; //no show cursor
    }


public void changeScene(string sceneName)
    {
        if (sceneName != "Exit")
            SceneManager.LoadScene(sceneName);
        else Application.Quit();
    }
}
