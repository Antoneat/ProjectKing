using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{

    public Button[] botones;
    public int Position = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            botones[Position].Seleccionado = false;
            Position++;

            if(Position < 0)
            {
                Position = botones.Length - 1;
                botones[Position].Seleccionado = true;
                return;
            }

            if(Position > botones.Length - 1)
            {
                Position = 0;
                botones[Position].Seleccionado=true;
                return;
            }

            botones[Position].Seleccionado=true;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            botones[Position].Seleccionado = false;
            Position++;

            if (Position < 0)
            {
                Position = botones.Length - 1;
                botones[Position].Seleccionado = true;
                return;
            }

            if (Position > botones.Length -1)
            {
                Position= 0;
                botones[Position].Seleccionado = true;
                return;
            }

            botones[Position].Seleccionado = true;
        }
    }
}
