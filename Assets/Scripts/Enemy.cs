using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Player plyr;

    [Header("Vida")]
    public int vida;

    [Header("Following")]
    public float speed;
    public Transform ObjetoASeguir;
    public bool playerOnRange;

    [Header("RangoDeAtaque")]
    public GameObject rangoAtaque;

    [Header("AtaqueBasico")]
    public float ataqueNormalDMG;
    public GameObject basicoGO;

    [Header("Mordisco")]
    public float mordiscoDMG;
    public GameObject mordiscoGO;

    void Start()
    {
        ObjetoASeguir = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        Following();
        Muerte();
    }

    private void Following()
    {
        transform.position = Vector3.MoveTowards(transform.position, ObjetoASeguir.transform.position, speed * Time.deltaTime);
        transform.forward = ObjetoASeguir.position - transform.position;
        if(playerOnRange == true)
        {
            speed = 0f;
            activator();
        }
        else if (playerOnRange == false)
        {
            speed = 1f;
        }
    }

    private void Muerte()
    {
        if (vida <= 0)
        {
            plyr.vida += 10;
            Destroy(gameObject);
        }
    }

    public void activator()
    {
        switch(Random.Range(0,2))
        {
            case 0: StartCoroutine(AtaqueBasico());
                break;
            case 1: StartCoroutine(Mordisco());
                break;
        }
    }

    IEnumerator AtaqueBasico()
    {
        yield return new WaitForSecondsRealtime(1f);
        basicoGO.SetActive(true);
        yield return new WaitForSecondsRealtime(0.2f);
        basicoGO.SetActive(false);
    }

    IEnumerator Mordisco()
    {
        yield return new WaitForSecondsRealtime(1f);
        mordiscoGO.SetActive(true);
        yield return new WaitForSecondsRealtime(0.2f);
        mordiscoGO.SetActive(false);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("AtaqueUno"))
        {
            vida -= plyr.AttackDmgUno;  // Disminuira cierta cantidad de vida cada que sea golpeado por el primer ataque.
        }

        if (collider.gameObject.CompareTag("AtaqueDos"))
        {
            vida -= plyr.AttackDmgDos;  // Disminuira cierta cantidad de vida cada que sea golpeado por el primer ataque.
        }

        if (collider.gameObject.CompareTag("AtaqueTres"))
        {
            vida -= plyr.AttackDmgTres;  // Disminuira cierta cantidad de vida cada que sea golpeado por el primer ataque.
        }

        if (collider.gameObject.CompareTag("AtaqueCargado"))
        {
            vida -= plyr.AttackDmgCargado;  // Disminuira cierta cantidad de vida cada que sea golpeado por el primer ataque.
        }
    }

    public void NumAlea()
    {
        int numalea = Random.Range(1,2);
    }
}
