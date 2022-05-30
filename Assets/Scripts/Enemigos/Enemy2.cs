using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{

    public Player plyr;
    public StateManager SM;
    public enemyPatrol2 eP2;

    [Header("Vida")]
    public float vida;
    public bool dead;

    [Header("AtaqueBasico")]
    public int atkbasDMG;
    public GameObject atkbasGO;

    [Header("GolpeAlPiso")]
    public int golpeDMG;
    public GameObject golpeGO;

    [Header("Rafaga")]
    public int rafagaDMG;
    public GameObject rafagaGO;

    [Header("Extra")]
    [SerializeField] private float knockbackStrength;

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
        yield return new WaitForSecondsRealtime(1f);
        atkbasGO.SetActive(true);
        yield return new WaitForSecondsRealtime(4f);
        atkbasGO.SetActive(false);
        yield break;
    }

    IEnumerator GolpeAlPiso()
    {
        yield return new WaitForSecondsRealtime(1f);
        golpeGO.SetActive(true);
        SM.ps = PlayerState.Quemado;
        yield return new WaitForSecondsRealtime(2f);
        golpeGO.SetActive(false);
        yield break;
    }

    IEnumerator Rafaga()
    {
        yield return new WaitForSecondsRealtime(1f);
        rafagaGO.SetActive(true);
        SM.ps = PlayerState.Quemado;
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
