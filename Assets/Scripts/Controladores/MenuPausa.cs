using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    public GameObject panelPausa, optionsMenu;

    public GameObject pauseFirstButton, optionsFirstButton, optionsCloseButton;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PauseUnPause();
        }
    }

    public void PauseUnPause()
    {
        if(!panelPausa.activeInHierarchy)
        {
            panelPausa.SetActive(true);
            Time.timeScale = 0f;

            //clear selected object
            EventSystem.current.SetSelectedGameObject(null);
            //Set a new selected object
            EventSystem.current.SetSelectedGameObject(pauseFirstButton);

        }
        else
        {
            panelPausa.SetActive(false);
            Time.timeScale = 1f;
            optionsMenu.SetActive(false);
        }
    }

    public void ClosePauseMenu()
    {
        panelPausa.SetActive(false);
        Time.timeScale = 1f;
        optionsMenu.SetActive(false);
    }

    public void OpenOptions()
    {
        optionsMenu.SetActive(true);

        //clear selected object
        EventSystem.current.SetSelectedGameObject(null);
        //Set a new selected object
        EventSystem.current.SetSelectedGameObject(optionsFirstButton);
    }

    public void CloseOptions()
    {
        optionsMenu.SetActive(false);

        //clear selected object
        EventSystem.current.SetSelectedGameObject(null);
        //Set a new selected object
        EventSystem.current.SetSelectedGameObject(pauseFirstButton);

    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
