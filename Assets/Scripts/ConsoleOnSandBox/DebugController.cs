using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugController : MonoBehaviour
{
    bool showConsole;

    string inputField;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            OnToogleDebug();
        }
    }

    public void OnToogleDebug()
    {
        showConsole = !showConsole;
    }

    private void OnGUI()
    {
        if(!showConsole) { return; }

        float y = 0f;

        GUI.Box(new Rect(0, y, Screen.width, 60), "");
        GUI.backgroundColor = new Color(0, 0, 0, 0);
        inputField = GUI.TextField(new Rect(10f, y + 15f,Screen.width -20f, 20f), inputField);
    }
}
