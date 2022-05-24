using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Loading : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string leveToload = LevelLoader.nextLevel;

        StartCoroutine(this.MakeTheLoad(leveToload));
    }

    IEnumerator MakeTheLoad(string level)
    {
        //Quitar esto
        yield return new WaitForSeconds(1f);

        AsyncOperation operation = SceneManager.LoadSceneAsync(level);

        while (operation.isDone == false)
        {
            yield return null;
        }
    }
}
