using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Player plyr;
    public StateManager SM;

    [Header("Vida")]
    public int vida;
    public bool dead;

    [Header("AtaqueBasico")]
    public int ataqueNormalDMG;
    public GameObject basicoGO;

    [Header("Mordisco")]
    public int mordiscoDMG;
    public GameObject mordiscoGO;

    [Header("Extra")]
    [SerializeField] private float knockbackStrength;

    // [Header("Following")]
    //public float speed;
    //public Transform ObjetoASeguir;
    //public bool playerOnRange;

    //[Header("RangoDeAtaque")]
    //public GameObject rangoAtaque;

    void Start()
    {
        plyr = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        //ObjetoASeguir = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        dead = false;
        basicoGO.SetActive(false);
        mordiscoGO.SetActive(false);
    }

    void Update()
    {
        //Following();
        Muerte();
    }

    /*private void Following()
    {
        transform.position = Vector3.MoveTowards(transform.position, ObjetoASeguir.transform.position, speed * Time.deltaTime);
        transform.forward = ObjetoASeguir.position - transform.position;
        if(playerOnRange == true)
        {
            speed = 0f;
            ChooseAtk();
        }
        else if (playerOnRange == false)
        {
            speed = 1f;
        }
    }*/

    private void Muerte()
    {
        if (vida <= 0)
        {
            plyr.actualvida += 10;
            dead = true;
            Destroy(gameObject);
        }
    }

    public void ChooseAtk()
    {
        if (SM.ps == PlayerState.Normal || SM.ps == PlayerState.Stun || SM.ps == PlayerState.Sangrado)
       {
            StartCoroutine(AtaqueBasico());
        }
        else if (SM.ps == PlayerState.Quemado)
        {
            StartCoroutine(Mordisco());
        }
        
    }

  /*  public void activator()
    {
        switch(Random.Range(0,2))
        {
            case 0: StartCoroutine(AtaqueBasico());
                break;
            case 1: StartCoroutine(Mordisco());
                break;
        }
    }*/

    IEnumerator AtaqueBasico()
    {
        yield return new WaitForSecondsRealtime(1f);
        basicoGO.SetActive(true);
        yield return new WaitForSecondsRealtime(2f);
        basicoGO.SetActive(false);
        yield break;
    }

    IEnumerator Mordisco()
    {
        yield return new WaitForSecondsRealtime(1f);
        mordiscoGO.SetActive(true);
        SM.ps = PlayerState.Sangrado;
        yield return new WaitForSecondsRealtime(2f);
        mordiscoGO.SetActive(false);
        yield break;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("FueraDelMundo")) Destroy(gameObject); // Si toca los colliders de FueraDelMundo, se destruye.
    }

    private void OnTriggerEnter(Collider collider)
    {
        Rigidbody rb = collider.GetComponent<Rigidbody>();

        if(rb != null)
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

  /*  public void NumAlea()
    {
        int numalea = Random.Range(1,2);
    }/*/
}
