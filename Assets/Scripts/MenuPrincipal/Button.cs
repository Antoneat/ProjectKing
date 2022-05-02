using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    public Color[] colores;
    public Image BotonImage;
    public bool Seleccionado = false;
    void Start()
    {
        BotonImage = GetComponent<Image>();
        BotonImage.color = colores[0];
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Seleccionado)
        {
            BotonImage.color = colores[1];
        }
        else
        {
            BotonImage.color = colores[0];
        }
    }
}
