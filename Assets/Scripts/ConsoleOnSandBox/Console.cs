using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Console : MonoBehaviour
{
    public GameObject content;

    public TMP_Text backgroundTxt;
    public TMP_InputField inputTxt;

    public delegate void TemplateMethod();
    public Dictionary<string, CommandData> allCommands = new Dictionary<string, CommandData>();

    // Guarda la unica instancia de esta consola
    public static Console instance;

    void Awake()
    {
        //Clear();
        //TemplateMethod metodo = Clear;

        if(instance != null)
        {
            GameObject.Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            RegisterCommand("clear", Clear, "Limpiar consola");
            RegisterCommand("help", Help, "Ayuda");
            RegisterCommand("exit", ExitGame, "Salir del juego");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            content.SetActive(!content.activeSelf);

            if (content.activeSelf)
            {
                inputTxt.Select(); // Le da el priorizacion a este componente
            }
        }
        // Si la consola esta abierta
        if (content.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                //Write(inputTxt.text);
                if (allCommands.ContainsKey(inputTxt.text))
                {
                    // Intentar
                    try
                    {
                        allCommands[inputTxt.text].comand.Invoke();
                    }
                    catch (NullReferenceException nullError)
                    {
                        Write("Hubo un error de algo nulo." + nullError.Message + "\n\n" + nullError.StackTrace);
                    }
                    catch (Exception error) // Si el try tira un error entra a esta parte
                    {
                        Write("Hubo un error: " + error.Message + "\n\n" + error.StackTrace);
                    }
                    finally
                    {
                        // Se ejecuta siempre.
                    }
                }
                inputTxt.text = "";
            }
        }
    }

    public void RegisterCommand(string cmdName, TemplateMethod cmdCommand, string description)
    {
        var cdata = new CommandData();
        cdata.name = cmdName;
        cdata.comand = cmdCommand;
        cdata.description = description;

        allCommands.Add(cmdName, cdata);
    }

    public void Clear()
    {
        backgroundTxt.text = "";
    }

    public void Help()
    {
        // Por cada item en una coleccion se ejecuta una vez.
        
        foreach (var item in allCommands)
        {
            Write("- " + item.Value.name + " -> " + item.Value.description); 
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Write(string txt)
    {
        // "\n" es un salto de linea
        backgroundTxt.text += "\n" + txt;
    }
}
