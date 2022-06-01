using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{

    public Player plyr;
    public StateManager SM;
    public enemyPatrol2 eP2;

    public float proyectileSpeed = 4;

    [Header("Vida")]
    public float vida;
    public bool dead;

    [Header("AtaqueBasico")]
    public float atkbasDMG;
    public GameObject atkbasGO;

    [Header("GolpeAlPiso")]
    public float golpeDMG;
    public GameObject golpeGO;

    [Header("Rafaga")]
    public float rafagaDMG;
    public GameObject rafagaGO;

    [Header("Extra")]
    [SerializeField] private float knockbackStrength;
    public Vector3 playerpos;

    void Start()
    {
        plyr = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
       
        dead = false;

        atkbasGO.SetActive(false);
        golpeGO.SetActive(false);
        rafagaGO.SetActive(false);
    }

    void Update()
    {
       
        Muerte();
        playerpos = GameObject.FindGameObjectWithTag("Player").transform.position;
    }

    private void Muerte()
    {
        if (vida <= 0)
        {
            plyr.actualvida += 10;
            dead = true;
            Destroy(gameObject);
        }
    }

    public void ChooseAtk2()
    {
        if (SM.ps == PlayerState.Normal || SM.ps == PlayerState.Sangrado || SM.ps == PlayerState.Quemado)
        {
            StartCoroutine(AtaqueBasico());
        }
        else if (SM.ps == PlayerState.Stun)
        {
            StartCoroutine(GolpeAlPiso());
        }
        else if (eP2.playerDistance > eP2.atkRange && eP2.playerDistance < eP2.awareAI)
        {
            StartCoroutine(Rafaga());
        }

    }

    IEnumerator AtaqueBasico()
    {
        eP2.agent.speed = 0;
        yield return new WaitForSecondsRealtime(1.5f);
        eP2.agent.speed = 3;
        atkbasGO.SetActive(true);
        yield return new WaitForSecondsRealtime(4f);
        atkbasGO.SetActive(false);
        yield break;
    }

    IEnumerator GolpeAlPiso()
    {
       
        //wea q lo sigue 
        yield return new WaitForSecondsRealtime(3f);
        GameObject clone = Instantiate(golpeGO, playerpos, Quaternion.identity); 
        golpeGO.SetActive(true);
        SM.ps = PlayerState.Quemado;
        yield return new WaitForSecondsRealtime(1f);
        golpeGO.SetActive(false);
        yield break;
    }

    IEnumerator Rafaga()
    {
        eP2.agent.speed = 0;
        yield return new WaitForSecondsRealtime(1f);
        float step = proyectileSpeed * Time.deltaTime; // calculate distance to move
        rafagaGO.transform.position = Vector3.MoveTowards(transform.position, playerpos, step);
        rafagaGO.SetActive(true);
        SM.ps = PlayerState.Quemado;
        eP2.agent.speed = 3;
        yield return new WaitForSecondsRealtime(2f);
        rafagaGO.SetActive(false);
        yield break;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("FueraDelMundo")) Destroy(gameObject); // Si toca los colliders de FueraDelMundo, se destruye.
    }

    private void OnTriggerEnter(Collider collider)
    {
        Rigidbody rb = collider.GetComponent<Rigidbody>();

        if (rb != null)
        {
            Vector3 direction = collider.transform.position - transform.position;
            direction.y = 0;

            rb.AddForce(direction.normalized * knockbackStrength, ForceMode.Impulse);
        }

        if (collider.gameObject.CompareTag("AtaqueUno")) vida -= plyr.AttackDmgUno; // Baja la vida del enemigo acorde con el valor que se puso en el ataque.

        if (collider.gameObject.CompareTag("AtaqueDos")) vida -= plyr.AttackDmgDos; // Lo de arriba x2.

        if (collider.gameObject.CompareTag("AtaqueTres")) vida -= plyr.AttackDmgTres; // Lo de arriba x3.

        if (collider.gameObject.CompareTag("AtaqueCargado")) vida -= plyr.AttackDmgCargado; // Lo de arriba x4.
    }
}
