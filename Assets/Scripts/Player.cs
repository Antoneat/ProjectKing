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
        if (dash)
        {
            //Dash();
            StartCoroutine(Dash());
        }

        if (attackCombo)
        {
            AttackCombo();
            timePressed = 0.9f;
        }

        if (attackCharged){
            StartCoroutine(AttackingCharg());
            timePressed = 0.9f;
        }
        Quieto();
    }

    public void Movimiento(Vector3 direction)
    {
        rb.MovePosition(transform.position + (direction * speed * Time.deltaTime));
        playerMesh.rotation = Quaternion.LookRotation(movement);
    }

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

    private void Quieto()
    {
        if(Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
        {
            rb.velocity = new Vector3(0, 0, 0);
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, radio);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("RangoAtaqueEnemy1"))
        {
            enmy.playerOnRange = true;
        }
        if (collider.gameObject.CompareTag("AtaqueNormalEnemy1"))
        {
            vida -= enmy.ataqueNormalDMG;
        }
        if (collider.gameObject.CompareTag("MordiscoEnemy1"))
        {
            vida -= enmy.mordiscoDMG;
        }
    }
    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.CompareTag("RangoAtaqueEnemy1"))
        {
            enmy.playerOnRange = false;
        }
    }
}
