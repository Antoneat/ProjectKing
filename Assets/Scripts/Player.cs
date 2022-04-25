using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movimiento")]
    public float speed;
    public Rigidbody rb;
    public Vector3 movement;
    public Transform playerMesh;

    [Header("Vida")]
    public float vida;
    private float maxVida;


    [Header("Desplazamiento")]
    public bool dash;
    public float dashCooldown;
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

    //[Header("Extra")]


    [Header("VFX")]
    public GameObject ataqueUno;
    public GameObject ataqueDos;
    public GameObject ataqueTres;



    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }


    void Update()
    {
        movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        dashCooldown -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && dashCooldown <= 0f)
        {
            dash = true;
        }

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

    void FixedUpdate()
    {
        Movimiento(movement);
        if (dash)
        {
            //Dash();
            StartCoroutine(Dash());
        }
        
    }

    public void Movimiento(Vector3 direction)
    {
        rb.MovePosition(transform.position + (direction * speed * Time.deltaTime));
        playerMesh.rotation = Quaternion.LookRotation(movement);
    }
    /*
    public void Dash()
    {
        rb.AddForce(transform.forward * speedDash, ForceMode.Impulse);
        dashCooldown = 2;
        dash = false;
        
    
        if (rb.position.x < 0f && Input.GetKeyDown(KeyCode.Space) && dashCooldown <= 0f)
        {
            rb.AddForce( movement * -speedDash, ForceMode.Impulse);
        }
        if (rb.position.z >= 0f && Input.GetKeyDown(KeyCode.Space) && dashCooldown <= 0f)
        {
            rb.AddForce( movement * speedDash, ForceMode.Impulse);
        }
        if (rb.position.z < 0f && Input.GetKeyDown(KeyCode.Space) && dashCooldown <= 0f)
        {
            rb.AddForce( movement * -speedDash, ForceMode.Impulse);
        }
    }*/


    IEnumerator Dash()
    {
        rb.AddForce(transform.forward * speedDash, ForceMode.Impulse);
        dashCooldown = 2;
        dash = false;
        yield return new WaitForSecondsRealtime(0.3f);
        rb.velocity = new Vector3(0,0,0);
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
