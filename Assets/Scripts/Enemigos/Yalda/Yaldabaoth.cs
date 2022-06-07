using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yaldabaoth : MonoBehaviour
{
    public Player plyr;
    //public Rigidbody rb;
   // int layerMask = 1 << 3;
    //float smoothRot = 1f;


    [Header("Vida")]
    public float actualvida;
    public float maxVida = 40;

    [Header("AtaqueBasico")]
    public float basico1DMG;
    public GameObject basico1GO;
    public GameObject basico1Txt;

    public float basico3DMG;
    public GameObject basico3GO;
    public GameObject basico3Txt;

    [Header("Especial")]
    public float especialDMG;
    public GameObject especialGO;
    public GameObject especialTxt;

    /* [Header("AtaqueFinal")]
     public GameObject goA;
     public GameObject goB;
     public GameObject goC;
    */
    public YaldaPatrol yp;


    void Start()
    {
        plyr = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        basico1GO.SetActive(false);
        basico3GO.SetActive(false);
        especialGO.SetActive(false);

        basico1Txt.SetActive(false);
        basico3Txt.SetActive(false);
        especialTxt.SetActive(false);
    }

    void Update()
    {

    }

    void FixedUpdate()
    {

        
    }

    /* private void Following()
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
     }*/

    public void ChooseAtk3()
    {
        if ((yp.playerDistance < yp.atkRange))
        {
            StartCoroutine(ataqueBasico());
        }
        else if (yp.playerDistance > yp.atkRange && yp.playerDistance < yp.awareAI)
        {
            StartCoroutine(especial());
        }
        else if (actualvida <= 20)
        {
            StartCoroutine(ataqueFinal());
        }

    }

    IEnumerator ataqueBasico()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        basico1GO.SetActive(true);
        basico1Txt.SetActive(true);
        yield return new WaitForSecondsRealtime(1.5f);
        yp.agent.speed = 0;
        basico1GO.SetActive(false);
        basico3GO.SetActive(true);
        basico1Txt.SetActive(false);
        basico3Txt.SetActive(true);
        yield return new WaitForSecondsRealtime(3f);
        yp.agent.speed = 3;
        basico3GO.SetActive(false);
        basico3Txt.SetActive(false);
        yield break;
    }
    IEnumerator especial()
    {
        especialTxt.SetActive(true);
        yp.agent.speed = 0;
        yield return new WaitForSecondsRealtime(3f);
        yp.agent.speed = 7;
        yp.agent.destination = yp.goal.position;

        yield return new WaitForSecondsRealtime(3f);
        especialTxt.SetActive(false);
    }

    IEnumerator ataqueFinal()
    {
        // Varios dash con patron y cuando termine, generar un triangulo en el suelo que haga daño al player y se quede quieto por 3s.
        yield break;
    }



    private void OnTriggerEnter(Collider collider)
    {
       
            if (collider.gameObject.CompareTag("AtaqueUno")) actualvida -= plyr.AttackDmgUno; // Baja la vida del enemigo acorde con el valor que se puso en el ataque.

            if (collider.gameObject.CompareTag("AtaqueDos")) actualvida -= plyr.AttackDmgDos; // Lo de arriba x2.

            if (collider.gameObject.CompareTag("AtaqueTres")) actualvida -= plyr.AttackDmgTres; // Lo de arriba x3.

            if (collider.gameObject.CompareTag("AtaqueCargado")) actualvida -= plyr.AttackDmgCargado; // Lo de arriba x4.
        

    }
}

