using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Question : MonoBehaviour
{
    public GameObject dialogueMark;
    public GameObject dialoguePanel;
    public GameObject questionGO;
    public TMP_Text dialogueText;

    [TextArea(4, 6)] public string[] dialogueLines;
    [TextArea(2, 3)] public string[] dialogueFinal;

    public GameObject opciones;
    public GameObject opcionUNO;
    public GameObject opcionDOS;

    public bool recompensa = false;

    public float typingTime = 0.05f;

    public bool PlayerInRange;
    public bool didDialogueStart;
    public int lineIndex;
    public int lineIndexFinal;

    void Update()
    {
        if (PlayerInRange && Input.GetButtonDown("Fire1") && recompensa == false)
        {
            if (!didDialogueStart)
            {
                StartDialogue();
            }
            else if (dialogueText.text == dialogueLines[lineIndex])
            {
                NextDialogueLine();
            }
            else
            {
                StopAllCoroutines();
                dialogueText.text = dialogueLines[lineIndex];
            }
        }
        
        if(PlayerInRange && Input.GetButtonDown("Fire1") && recompensa == true)
        {
            if (!didDialogueStart)
            {
                StartDialogueFinal();
            }
            else if (dialogueText.text == dialogueFinal[lineIndexFinal])
            {
                NextDialogueLineFinal();
            }
            else
            {
                StopAllCoroutines();
                dialogueText.text = dialogueFinal[lineIndexFinal];
            }
        }
    }

    public void StartDialogue()
    {
        ActivingPanels();

        questionGO.SetActive(true);

        lineIndex = 0;

        Time.timeScale = 0f;

        StartCoroutine(ShowLine());
    }
    public void StartDialogueFinal()
    {
        ActivingPanels();

        questionGO.SetActive(true);

        opciones.SetActive(false);

        lineIndexFinal = 0;

        Time.timeScale = 0f;

        StartCoroutine(ShowLineFinal());
    }

    public void ActivingPanels()
    {
        didDialogueStart = true;
        dialoguePanel.SetActive(true);
        dialogueMark.SetActive(false);
    }

    public void NextDialogueLine()
    {
        lineIndex++;
        if (lineIndex < dialogueLines.Length)
        {
            StartCoroutine(ShowLine());
        }
        else if (lineIndex == dialogueLines.Length && recompensa == false)
        {
            opciones.SetActive(true);
            lineIndex --;
        }
        else
        {
            didDialogueStart = false;
            dialoguePanel.SetActive(false);
            questionGO.SetActive(false);
            dialogueMark.SetActive(true);
            
            Time.timeScale = 1f;
        }
    }
    public void NextDialogueLineFinal()
    {
        lineIndexFinal++;
        if (lineIndexFinal < dialogueFinal.Length)
        {
            StartCoroutine(ShowLineFinal());
        }
        else
        {
            didDialogueStart = false;
            dialoguePanel.SetActive(false);
            questionGO.SetActive(false);
            dialogueMark.SetActive(true);
            Time.timeScale = 1f;
        }
    }

    public void BotonUNO()
    {
        recompensa = true;
        NextDialogueLine();
    }

    public void BotonDOS()
    {
        recompensa = true;
        NextDialogueLine();
    }

    public IEnumerator ShowLine()
    {
        dialogueText.text = string.Empty;

        foreach (char ch in dialogueLines[lineIndex])
        {
            dialogueText.text += ch;
            yield return new WaitForSecondsRealtime(typingTime);
        }
    }

    public IEnumerator ShowLineFinal()
    {
        dialogueText.text = string.Empty;

        foreach (char ch in dialogueFinal[lineIndexFinal])
        {
            dialogueText.text += ch;
            yield return new WaitForSecondsRealtime(typingTime);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerInRange = true;
            dialogueMark.SetActive(true);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerInRange = false;
            dialogueMark.SetActive(false);
        }
    }
}