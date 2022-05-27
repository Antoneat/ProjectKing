using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MainMenuController : MonoBehaviour
{

    public GameObject optionsMainMenu;

    public GameObject menuFirstButton, optionsFirstButtonMainMenu, optionsCloseButton;

    void Start()
    {
        //AudioManager.instance.Play("MenuSong");
        //clear selected object
        //EventSystem.current.SetSelectedGameObject(null);
        //Set a new selected object
        EventSystem.current.SetSelectedGameObject(menuFirstButton);
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return;
        }
    }


    public void OpenOptions()
    {
        optionsMainMenu.SetActive(true);

        //clear selected object
        EventSystem.current.SetSelectedGameObject(null);
        //Set a new selected object
        EventSystem.current.SetSelectedGameObject(optionsFirstButtonMainMenu);
    }

    public void CloseOptions()
    {
        optionsMainMenu.SetActive(false);

        //clear selected object
        EventSystem.current.SetSelectedGameObject(null);
        //Set a new selected object
        EventSystem.current.SetSelectedGameObject(menuFirstButton);

    }

}
