using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InterfazComandos : MonoBehaviour
{
    
    public GameObject interfazComandos;

    [Header("PRIMER PANEL")]
    public GameObject PlayerConfigPanel;
    public GameObject EnemysConfigPanel;
    public GameObject CamaraConfigPanel;

    [Header("ENEMIGOS PANEL")]
    public GameObject BuscadorConfigPanel;
    public GameObject VerdugoConfigPanel;
    public GameObject YaldabaothConfigPanel;

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

    /*////////////////////////////////////////////////////////////
    ENEMYS
    ////////////////////////////////////////////////////////////*/
    public void OpenEnemysConfig()
    {
        EnemysConfigPanel.SetActive(true);
    }
    public void CloseEnemysConfig()
    {
        EnemysConfigPanel.SetActive(false);
    }

    public void OpenBuscadorConfig()
    {
        BuscadorConfigPanel.SetActive(true);
    }
    public void CloseBuscadorconfig()
    {
        BuscadorConfigPanel.SetActive(false);
    }
    public void OpenVerdugoConfig()
    {
        VerdugoConfigPanel.SetActive(true);
    }
    public void CloseVerdugoConfig()
    {
        VerdugoConfigPanel.SetActive(false);
    }

    /*////////////////////////////////////////////////////////////
    CAMARA
    ////////////////////////////////////////////////////////////*/

    public void OpenCameraConfig()
    {
        CamaraConfigPanel.SetActive(true);
    }
    public void CloseCameraConfig()
    {
        CamaraConfigPanel.SetActive(false);
    }
}
