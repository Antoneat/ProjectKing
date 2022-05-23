using System.Collections;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private GameObject dialogueMark;    // Marca el cual aparece encima del npc.
    [SerializeField] private GameObject dialoguePanel;   // Panel del dialogo en el Canvas.
    [SerializeField] private GameObject dialogueGO;      // GameObject que activa el texto.
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField, TextArea(4, 6)] public string[] dialogueLines;     // Array de texto que guarda los dialogos (se pueden modificar su orden en el inspector)

    public float typingTime = 0.05f;    // Tiempo en el que aparece caracter por caracter.

    public bool PlayerInRange;  // Collider on trigger que detecta si esta en rango para ejecutar el dialogo.
    public bool didDialogueStart;   // Comprobante si el dialogo todavia no empieza.
    public int lineIndex;   // Indice que se usara para comprobar 

    public Player plyr;

    void Start()
    {
        plyr = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void Update()
    {
        if (PlayerInRange && Input.GetKeyDown(KeyCode.E)) // Si el jugador esta en rango y da click izquierdo
        {
            if (!didDialogueStart) // Y si el jugador todavia no empieza un dialogo
            {
                StartDialogue();
            }
            else if(dialogueText.text == dialogueLines[lineIndex]) // Si el texto mostrado en pantalla es igual al string que le corresponde;
            {
                NextDialogueLine();
            }
            else
            {
                StopAllCoroutines();
                dialogueText.text = dialogueLines[lineIndex];
            }
        }
    }

    public void StartDialogue()
    {
        didDialogueStart = true;
        dialoguePanel.SetActive(true);
        dialogueGO.SetActive(true);
        dialogueMark.SetActive(false);
        lineIndex = 0;
        Time.timeScale = 0f;
        StartCoroutine(ShowLine());
    }

    public void NextDialogueLine()
    {
        lineIndex++;
        if (lineIndex < dialogueLines.Length)
        {
            StartCoroutine(ShowLine());
        }
        else
        {
            didDialogueStart = false;
            dialoguePanel.SetActive(false);
            dialogueGO.SetActive(false);
            dialogueMark.SetActive(true);
            Time.timeScale = 1f;

            plyr.rb.velocity = new Vector3(0,0,0);
        }
    }

    public IEnumerator ShowLine()
    {
        dialogueText.text = string.Empty;   // Muestra en un inicio el texto vacio.

        foreach(char ch in dialogueLines[lineIndex]) // Por cada caracter en el indice actual del array, se mostrara 1 por 1 en el texto del canvas.
        {
            dialogueText.text += ch;
            yield return new WaitForSecondsRealtime(typingTime); // "WaitForSecondsRealTime" para que no se pause cuando pongamos el Time.timeScale en 0.
        }
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player")) // Chequea si el jugador esta dentro del trigger.
        {
            PlayerInRange = true;
            dialogueMark.SetActive(true);
        }
    }

    public void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player")) // Chequea si el jugador esta afuera del trigger.
        {
            PlayerInRange = false;
            dialogueMark.SetActive(false);
        }
    }
}
