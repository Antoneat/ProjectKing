using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Header("Movimiento")]
    public float speed = 8f;
    private Vector3 movement;
    public Transform playerMesh;
    public Rigidbody rb;

    [Header("Vida")]
    public float actualvida;
    private float maxVida = 20;

    [Header("Desplazamiento")]
    public bool dash;
    public float speedDash;
    private float dashCooldown = 0.2f;
    [SerializeField] private float dashLength = 0.1f;
    public float dashCounter;
    public float dashCoolCounter;

    [Header("AtaqueCombo")]
    [SerializeField] private int numberOfClicks = 0;
    private float lastClickedTime = 0;
    private float maxComboDelay = 0.8f;
    public int AttackDmgUno = 10;
    public int AttackDmgDos = 20;
    public int AttackDmgTres = 30;
    public GameObject ataqueUnoGO;
    public GameObject ataqueDosGO;
    public GameObject ataqueTresGO;
    public bool attackCombo = false;
    public float attackCooldown = 0.25f;
    private float timePressed = 0.9f;

    [Header("AtaqueCargado")]
    [SerializeField] private float radio = 5f;
    public GameObject ataqueCargGO;
    public int AttackDmgCargado = 5;
    public bool attackCharged = false;

    [Header("Extra")]
    [SerializeField] private Enemy enmy;
    [SerializeField] private int sceneId = 1;
    public TMP_Text vidapersonajeTxt;
    public TMP_Text dmgTxt;
    int a = 0;
    int b = 0;

    [Header("VFX")]
    public GameObject ataqueUno;
    public GameObject ataqueDos;
    public GameObject ataqueTres;

    [Header("Coleccionables")]
    public int collectables = 1;
    public int counterCollectables = 0;
    public TMP_Text collecTxt;
    public GameObject collecTxtGO;
    public float counterNum;


    void Start()
    {
        rb = GetComponent<Rigidbody>();

        actualvida = maxVida;

        collecTxtGO.SetActive(false);

        Console.instance.RegisterCommand("godmode", godmode, "Activar/Desactivar el modo Dios.");
        Console.instance.RegisterCommand("restartlevel", resetlevel, "Reiniciar nivel");
        Console.instance.RegisterCommand("previouslevel", previouslevel, "Nivel anterior");
        Console.instance.RegisterCommand("nextlevel", nextlevel, "Siguiente nivel");
        Console.instance.RegisterCommand("crt", crt, "Creditos");
        Console.instance.RegisterCommand("infinitedmg", infinitedmg, "Daño infinito");
    }

    void Update()
    {
        vidapersonajeTxt.text = "Vida: " + actualvida.ToString();

        dmgTxt.text = "Daño: " + AttackDmgUno.ToString();

        collecTxt.text = counterCollectables.ToString() + " / 5";

        counterNum += Time.deltaTime;

        if (collectables == counterCollectables)
        {
            Collects();
            counterNum = 0;
        }
        if (counterNum > 3)
        {
            collecTxtGO.SetActive(false);
            counterNum = 0;
        }

        movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (dashCoolCounter <= 0f && dashCounter <= 0)
            {
                dash = true;
                dashCounter = dashLength;
                StartCoroutine(Dash(movement));
            }
        }

        if(dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
        }
        
        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;
            if (dashCounter <= 0)
            {
                dash = false;
                dashCoolCounter = dashCooldown;
            }
        }

        attackCooldown -= Time.deltaTime;

        if (Input.GetKey(KeyCode.J))
        {
            timePressed -= Time.deltaTime;
        }
        if (timePressed >= 0 && Input.GetKeyUp(KeyCode.J))
        {
            attackCombo = true;
            attackCharged = false;
        }
        if (timePressed < 0 && Input.GetKeyUp(KeyCode.J))
        {
            attackCombo = false;
            attackCharged = true;
        }

        if (Time.time - lastClickedTime > maxComboDelay)
        {
            numberOfClicks = 0;
            ataqueUnoGO.SetActive(false);
            ataqueDosGO.SetActive(false);
            ataqueTresGO.SetActive(false);
            ataqueUno.SetActive(false);
            ataqueDos.SetActive(false);
            ataqueTres.SetActive(false);
        }
    }

    void FixedUpdate()
    {
        Movimiento(movement);
        
        if (attackCombo)
        {
            AttackCombo();
            timePressed = 0.9f;
        }

        if (attackCharged){
            StartCoroutine(AttackingCharg());
            timePressed = 0.9f;
        }
    }

    public void Movimiento(Vector3 movement)
    {
        if(dash == false) 
        {
            rb.velocity = movement * speed * Time.deltaTime;
            //playerMesh.rotation = Quaternion.LookRotation(rb.velocity.normalized);
        }
    }
    
    IEnumerator Dash(Vector3 movement)
    {
        rb.AddForce(movement * speedDash, ForceMode.Impulse);
        yield return new WaitForSecondsRealtime(0.3f);
    }
    
    private void AttackCombo()
    {
        lastClickedTime = Time.time;
        numberOfClicks++;

        if (numberOfClicks == 1 && attackCooldown <=0)
        {
            ataqueUnoGO.SetActive(true);
            ataqueDosGO.SetActive(false);
            ataqueTresGO.SetActive(false);
            ataqueUno.SetActive(true);
            ataqueDos.SetActive(false);
            ataqueTres.SetActive(false);
            attackCooldown = 0.25f;
        }

        numberOfClicks = Mathf.Clamp(numberOfClicks, 0, 3);

        if (numberOfClicks == 2 && attackCooldown <= 0)
        {
            ataqueUnoGO.SetActive(false);
            ataqueDosGO.SetActive(true);
            ataqueTresGO.SetActive(false);
            ataqueUno.SetActive(false);
            ataqueDos.SetActive(true);
            ataqueTres.SetActive(false);
            attackCooldown = 0.25f;
        }

        if (numberOfClicks == 3 && attackCooldown <= 0)
        {
            ataqueUnoGO.SetActive(false);
            ataqueDosGO.SetActive(false);
            ataqueTresGO.SetActive(true);
            ataqueUno.SetActive(false);
            ataqueDos.SetActive(false);
            ataqueTres.SetActive(true);
            attackCooldown = 0.25f;
            numberOfClicks = 0;
        }
        attackCombo = false;
    }

    IEnumerator AttackingCharg()
    {
        for (int i = 0; i < 5; i++)
        {
            ataqueCargGO.SetActive(true);
            yield return new WaitForSecondsRealtime(0.5f);
            ataqueCargGO.SetActive(false);
        }
        attackCharged = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, radio);
    }

    private void Collects()
    {
        collecTxtGO.SetActive(true);
        collectables++;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("FueraDelMundo")) transform.position = new Vector3(0,0.7f,0);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("RangoAtaqueEnemy1")) enmy.playerOnRange = true;

        if (collider.gameObject.CompareTag("AtaqueNormalEnemy1")) actualvida -= enmy.ataqueNormalDMG;

        if (collider.gameObject.CompareTag("MordiscoEnemy1")) actualvida -= enmy.mordiscoDMG;

    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.CompareTag("RangoAtaqueEnemy1")) enmy.playerOnRange = false;

    }

    public void godmode()
    {
        a++;
        if (a % 2 == 0)
        {
            actualvida = maxVida;
        }
        else if (a % 2 == 1)
        {
            actualvida = 999999;
        }
    }

    public void infinitedmg()
    {
        b++;
        if (b % 2 == 0)
        {
            AttackDmgUno = 10;
            AttackDmgDos = 20;
            AttackDmgTres = 30;
            AttackDmgCargado = 5;
        }
        else if (b % 2 == 1)
        {
            AttackDmgUno = 999;
            AttackDmgDos = 999;
            AttackDmgTres = 999;
            AttackDmgCargado = 999;
        }
    }

    public void resetlevel()
    {
        SceneManager.LoadScene(sceneId);
        // Cuando pase de nivel agregarle en el trigger un +1 al sceneId para el reset de lvl en la consola
    }
    public void nextlevel()
    {
        SceneManager.LoadScene(sceneId + 1);
    }
    public void previouslevel()
    {
        SceneManager.LoadScene(sceneId - 1);
    }
    public void crt()
    {
        SceneManager.LoadScene(2);
    }
}