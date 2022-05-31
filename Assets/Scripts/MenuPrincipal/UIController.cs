using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIController : MonoBehaviour
{
    private GameObject lastSelected;
    private EventSystem eventSystem;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        eventSystem = GetComponent<EventSystem>();
        lastSelected = eventSystem.firstSelectedGameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(eventSystem.currentSelectedGameObject==null)
        {
            eventSystem.SetSelectedGameObject(lastSelected);
        }
        else
        {
            lastSelected = eventSystem.currentSelectedGameObject;
        }
    }
}
