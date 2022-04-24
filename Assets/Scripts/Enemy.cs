using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Player plyr;

    [Header("Vida")]
    public int vida;

    [Header("Following")]
    [SerializeField] private float speed;
    public Transform ObjetoASeguir;
    

    [Header("Ataque")]
    [SerializeField] private float ataqueNormal;
    [SerializeField] private float mordisco;

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
    }

    private void Muerte()
    {
        if (vida <= 0)
        {
            plyr.vida += 10;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("AtaqueUno"))
        {
            vida -= plyr.AttackDmgUno;  // Disminuira cierta cantidad de vida cada que sea golpeado por el primer ataque.
            
            /*
            if (vida <= 0)
            {
                GameObject obj = Instantiate(deathVFX);  //Efectos visuales dsp de morir
                obj.transform.position = transform.position;
            }
            */
        }

        if (collider.gameObject.CompareTag("AtaqueDos"))
        {
            vida -= plyr.AttackDmgDos;  // Disminuira cierta cantidad de vida cada que sea golpeado por el primer ataque.

            /*
            if (vida <= 0)
            {
                GameObject obj = Instantiate(deathVFX);  //Efectos visuales dsp de morir
                obj.transform.position = transform.position;
            }
            */
        }

        if (collider.gameObject.CompareTag("AtaqueTres"))
        {
            vida -= plyr.AttackDmgTres;  // Disminuira cierta cantidad de vida cada que sea golpeado por el primer ataque.

            /*
            if (vida <= 0)
            {
                GameObject obj = Instantiate(deathVFX);  //Efectos visuales dsp de morir
                obj.transform.position = transform.position;
            }
            */
        }

        if (collider.gameObject.CompareTag("AtaqueCargado"))
        {
            vida -= plyr.AttackDmgCargado;  // Disminuira cierta cantidad de vida cada que sea golpeado por el primer ataque.

            /*
            if (vida <= 0)
            {
                GameObject obj = Instantiate(deathVFX);  //Efectos visuales dsp de morir
                obj.transform.position = transform.position;
            }
            */
        }
    }
}
