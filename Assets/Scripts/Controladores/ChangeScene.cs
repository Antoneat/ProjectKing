using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeScene : MonoBehaviour
{
    [SerializeField]
    private int sceneId;
    public void ChangeSceneOption()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneId);
    }

    // Update is called once per frame
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Saliendo del infierno");
    }
}
