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

    [Header("Pasiva")]
    //[SerializeField] private GameObject portales;

    [Header("AtaqueFinal")]
    public GameObject goA;
    public GameObject goB;
    public GameObject goC;
      

    void Start()
    {
        playerSeguir = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        //portales.SetActive(false);
    }

    void Update()
    {
        Following();
        if (vidaYalda <= 50)
        {
            StopAllCoroutines();
            StartCoroutine(ataqueFinal());
            Pasiva();
        }
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
            AtaqueBasicoSinPasiva();
        }
        else if (vidaYalda <= 50)
        {
            Debug.Log("ataquebasico CON pasiva");
            AtaqueBasicoConPasiva();
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
            EspecialSinPasiva();
        }
        else if (vidaYalda <= 50)
        {
            Debug.Log("Especial CON pasiva");
            EspecialConPasiva();
        }
        yield return new WaitForSecondsRealtime(2f);
        atacando = false;
        speed = 1;
        yield break;
    }

    IEnumerator ataqueFinal()
    {
        // Varios dash con patron y cuando termine, generar un triangulo en el suelo que haga daño al player y se quede quieto por 3s.
        yield break;
    }

    private void AtaqueBasicoSinPasiva()
    {
        // 
    }
    private void AtaqueBasicoConPasiva()
    {
        // 2 ataques normales consecutivos y dsp de 1.5s(? lanzar un ataque con mas dmg.
    }

    private void Pasiva()
    {
        //portales.SetActive(true);
    }

    private void EspecialSinPasiva()
    {
        // 
    }
    private void EspecialConPasiva()
    {
        // Cuando el jugador esta lejos, carga un dash por 2s y se impulsa hacia la ultima posicion del player.
    }
}

