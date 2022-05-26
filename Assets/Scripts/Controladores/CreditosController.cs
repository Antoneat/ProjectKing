using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CreditosController : MonoBehaviour
{

    public GameObject creditsFirstButton;


    void Start()
    {
        EventSystem.current.SetSelectedGameObject(creditsFirstButton);
    }
}
