using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yaldabaoth : MonoBehaviour
{
    public Player plyr;
    //public Rigidbody rb;
    int layerMask = 1 << 3;
    float smoothRot = 1f;


    [Header("Vida")]
    [SerializeField] private int vidaYalda;

    [Header("Following")]
    public float speed;
    public Transform playerSeguir;
    public bool playerOnRange;

    [Header("RangoDeAtaque")]
    public GameObject rangoAtaque;
    public bool atacando;

    [Header("Ataque basico")]
    [SerializeField] private float ataqueBasicoDMG;


    void Start()
    {
        playerSeguir = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        Following();
    }

    void FixedUpdate()
    {
        RaycastHit hit;
        
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 5, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.green);
            Debug.Log("Yalda esta a rango de Scarlet");
            if (hit.collider.CompareTag("Player"))
            {
                atacando = true;
            }
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 5, Color.red);
            Debug.Log("Yalda NO esta a rango de Scarlet");
        }
        
    }

    private void Following()
    {
        if (atacando == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerSeguir.transform.position, speed * Time.deltaTime);
            transform.forward = playerSeguir.position - transform.position;
            transform.rotation = Quaternion.Slerp(transform.rotation, playerSeguir.rotation, smoothRot * Time.deltaTime);
        }
        else if(atacando == true)
        {
            speed = 0;
            Ataques();
        }
        /*
        if (playerOnRange == true)
        {
            atacando = true;
        }
        */
    }

    public void Ataques()
    {
        if(atacando == true)
        {
            int numalea = Random.Range(1, 3);
            switch (numalea)
            {
                case 1:
                    StartCoroutine(ataquebasico());
                    break;

                case 2:
                    StartCoroutine(especial());
                    break;
            }
        }
    }
    IEnumerator ataquebasico()
    {
        if (vidaYalda > 50)
        {
            Debug.Log("ataquebasico SIN pasiva");
        }
        else if (vidaYalda <= 50)
        {
            Debug.Log("ataquebasico CON pasiva");
        }
        yield return new WaitForSecondsRealtime(2f);
        atacando = false;
        speed = 1;
        yield break;
    }

    IEnumerator especial()
    { 
        if (vidaYalda > 50)
        {
            Debug.Log("Especial SIN pasiva");
        }
        else if (vidaYalda <= 50)
        {
            Debug.Log("Especial CON pasiva");
        }
        yield return new WaitForSecondsRealtime(2f);
        atacando = false;
        speed = 1;
        yield break;
    }
}

