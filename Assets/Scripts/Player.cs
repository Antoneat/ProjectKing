using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movimiento")]
    public float speed;
    private float directionX;
    private float directionZ;

    [Header("Vida")]
    public float vida;
    private float maxVida;
    //private float vidaRobada;


    [Header("Desplazamiento")]
    public bool dash;
    public float dashTime;
    public float speedDash;

    [Header("AtaqueCombo")]
    [SerializeField] private float cooldowntime = 0f;
    [SerializeField] private float nextFireTime = 1f;
    [SerializeField] private int numberOfClicks = 0;
    private float lastClickedTime = 0;
    private float maxComboDelay = 0.8f;
    public int AttackDmgUno = 10;
    public int AttackDmgDos = 20;
    public int AttackDmgTres = 30;
    public GameObject ataqueUnoGO;
    public GameObject ataqueDosGO;
    public GameObject ataqueTresGO;

    [Header("AtaqueCargado")]
    [SerializeField] private float radio = 5f;
    private float tiempo = 2f;
    public GameObject ataqueCargGO;
    private float attackChargedDelay = 5f;
    public int AttackDmgCargado = 5;
    private float lastClickedTimeDos = 0;

    [Header("Extra")]
    public Rigidbody rb;


    [Header("VFX")]
    public GameObject ataqueUno;
    public GameObject ataqueDos;
    public GameObject ataqueTres;



    void Start()
    {

    }


    void Update()
    {
        Movimiento();
        Dash();
        
        /*
        if (Input.GetKeyDown(KeyCode.J))
        {
            cooldowntime = 1 * Time.time;
            if (cooldowntime > nextFireTime)
            {
                AttackCombo();
            }
        }
        */
        
        AttackCombo();

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
        
        AttackCharged();

        if (Time.time - lastClickedTimeDos > attackChargedDelay)
        {

        }
        
    }
    private void Movimiento()
    {
        directionX = Input.GetAxis("Horizontal");
        directionZ = Input.GetAxis("Vertical");

        transform.position += new Vector3(directionX * speed * Time.deltaTime, 0, directionZ * speed * Time.deltaTime);
    }
    private void Dash()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            dashTime += 1 * Time.deltaTime;
            if(dashTime < 1)
            {
                dash = true;
                if(directionX < 0)
                    transform.Translate(Vector3.left * speedDash * Time.fixedDeltaTime);
                else if (directionX > 0)
                    transform.Translate(Vector3.right * speedDash * Time.fixedDeltaTime);
                else if (directionZ < 0)
                    transform.Translate(Vector3.back * speedDash * Time.fixedDeltaTime);
                else if (directionZ > 0)
                    transform.Translate(Vector3.forward * speedDash * Time.fixedDeltaTime);
            }
            else
            {
                dash = false;
            }
        }
        else
        {
            dash = false;
            dashTime = 0;
        }
    }

    private void AttackCombo()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            cooldowntime = 1 * Time.time;
            if (cooldowntime > nextFireTime)
            {
                lastClickedTime = Time.time;
                cooldowntime *= 0;
                numberOfClicks++;

                if (numberOfClicks == 1)
                {
                    ataqueUnoGO.SetActive(true);
                    ataqueDosGO.SetActive(false);
                    ataqueTresGO.SetActive(false);
                    ataqueUno.SetActive(true);
                    ataqueDos.SetActive(false);
                    ataqueTres.SetActive(false);
                }
                //numberOfClicks = Mathf.Clamp(numberOfClicks, 0, 3);

                if (numberOfClicks == 2)
                {
                    ataqueUnoGO.SetActive(false);
                    ataqueDosGO.SetActive(true);
                    ataqueTresGO.SetActive(false);
                    ataqueUno.SetActive(false);
                    ataqueDos.SetActive(true);
                    ataqueTres.SetActive(false);
                }

                if (numberOfClicks == 3)
                {
                    ataqueUnoGO.SetActive(false);
                    ataqueDosGO.SetActive(false);
                    ataqueTresGO.SetActive(true);
                    ataqueUno.SetActive(false);
                    ataqueDos.SetActive(false);
                    ataqueTres.SetActive(true);
                    numberOfClicks = 0;
                }
            }
        }
        
    }

    private void AttackCharged()
    {
        
        if (Input.GetKeyDown(KeyCode.K))
        {
            StartCoroutine(AttackingCharg());
            /*
            CuentaAtras();
            lastClickedTimeDos = Time.time;
            Debug.Log(tiempo);
            if (tiempo < 0)
            {
                Destroy(this);
            }
            */
        }
        
        //ataqueCargGO.SetActive(true);
    }
    IEnumerator AttackingCharg()
    {
        for (int i = 0; i < 10; i++)
        {
            ataqueCargGO.SetActive(true);

            yield return new WaitForSecondsRealtime(0.3f);

            ataqueCargGO.SetActive(false);

        }
    }

    public void CuentaAtras()
    {
        tiempo -= Time.deltaTime;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, radio);
    }
}
