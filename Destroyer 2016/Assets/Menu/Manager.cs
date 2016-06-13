using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour {

    void Start()
    {
        
    }


public void changeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
