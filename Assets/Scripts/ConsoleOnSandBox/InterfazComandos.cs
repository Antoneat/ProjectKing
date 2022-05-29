using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InterfazComandos : MonoBehaviour
{
    
    public GameObject interfazComandos;

    public GameObject PlayerConfigPanel, EnemysConfigPanel, CamaraConfigPanel;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            InterfazPanel();
        }
    }

    public void InterfazPanel()
    {
        if (!interfazComandos.activeInHierarchy)
        {
            interfazComandos.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            interfazComandos.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void OpenPlayerConfig()
    {
        PlayerConfigPanel.SetActive(true);
    }
    public void ClosePlayerConfig()
    {
        PlayerConfigPanel.SetActive(false);
    }

    public void OpenEnemysConfig()
    {
        EnemysConfigPanel.SetActive(true);
    }
    public void CloseEnemysConfig()
    {
        EnemysConfigPanel.SetActive(false);
    }

    public void OpenCameraConfig()
    {
        CamaraConfigPanel.SetActive(true);
    }
    public void CloseCameraConfig()
    {
        CamaraConfigPanel.SetActive(false);
    }
}
