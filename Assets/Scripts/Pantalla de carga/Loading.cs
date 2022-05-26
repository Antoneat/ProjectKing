using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Loading : MonoBehaviour
{
    public int sceneIdLoad;

    [SerializeField]
    private Image progressImage;

    // Start is called before the first frame update
    void Start()
    {
        //star async operation
        StartCoroutine(LoadAsyncOperation());
    }

    IEnumerator LoadAsyncOperation()
    {
        //create async operation
        AsyncOperation gameLevel = SceneManager.LoadSceneAsync(sceneIdLoad);

        while(gameLevel.progress < 1)
        {
            //take the progress bar fll = async operation progress
            progressImage.fillAmount = gameLevel.progress;
            yield return new WaitForEndOfFrame();
        }
    }
}
