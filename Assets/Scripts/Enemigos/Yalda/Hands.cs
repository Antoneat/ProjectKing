using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hands : MonoBehaviour
{
    public Player plyr;

    public GameObject Hand1;
    public GameObject Hand2;

    public GameObject portalA;
    public GameObject portalB;
    public GameObject portalC;
    public GameObject portalD;

    public HandsPatrol hp;
    public HandsPatrol2 hp2;

    public float actualvida;
    public float maxVida=40;

   // public Transform teleport1;
    //public Transform teleport2;

    public Transform pointa;
    public Transform pointb;

    public Transform pointc;
    public Transform pointd;

    public GameObject itemSp;

    public bool vulnerable;
    bool loop;
    void Start()
    {
        actualvida = maxVida;
         vulnerable = false;
        loop = true;
        portalA.SetActive(false);
        portalB.SetActive(false);
        portalC.SetActive(false);
        portalD.SetActive(false);
    }


    void Update()
    {
        if(actualvida >=20)
        {
            Sequence1();
            portalA.SetActive(false);
            portalB.SetActive(false);
            portalC.SetActive(false);
            portalD.SetActive(false);
        }
        else if(actualvida <20)
        {
            Sequence2();
            portalA.SetActive(true);
            portalB.SetActive(true);
            portalC.SetActive(true);
            portalD.SetActive(true);
        }
    }

    private void Sequence1()
    {
        StartCoroutine(Seq());
    }
    private void Sequence2()
    {
        StartCoroutine(Seq2());
    }

    private IEnumerator Seq()
    {
        while (loop ==true)
        {
                yield return StartCoroutine(Ataquebasico1());
                yield return StartCoroutine(Ataquebasico2());
                yield return StartCoroutine(Especial());
                yield return StartCoroutine(Ataquebasico3());
                yield return StartCoroutine(Ataquebasico4());
                yield return StartCoroutine(Ataquebasico2());
                yield return StartCoroutine(Especial());
                yield return StartCoroutine(Ataquebasico1());
                yield return StartCoroutine(Ataquebasico3());
                yield return StartCoroutine(Ataquebasico5());
                yield return StartCoroutine(Especial());
                yield return StartCoroutine(Ataquebasico6());
        }

    }
    private IEnumerator Seq2()
    {
        while (loop == true)
        {
            yield return StartCoroutine(Ataquebasico1());
            yield return new WaitForSecondsRealtime(0.7f);
            yield return StartCoroutine(Ataquebasico2());
            yield return new WaitForSecondsRealtime(0.7f);
            yield return StartCoroutine(Especial());
            yield return new WaitForSecondsRealtime(0.7f);
            yield return StartCoroutine(Ataquebasico3());
            yield return new WaitForSecondsRealtime(0.7f);
            yield return StartCoroutine(Ataquebasico4());
            yield return new WaitForSecondsRealtime(0.7f);
            yield return StartCoroutine(Ataquebasico2());
            yield return new WaitForSecondsRealtime(0.7f);
            yield return StartCoroutine(Especial());
            yield return new WaitForSecondsRealtime(0.7f);
            yield return StartCoroutine(Ataquebasico1());
            yield return new WaitForSecondsRealtime(0.7f);
            yield return StartCoroutine(Ataquebasico3());
            yield return new WaitForSecondsRealtime(0.7f);
            yield return StartCoroutine(Ataquebasico5());
            yield return new WaitForSecondsRealtime(0.7f);
            yield return StartCoroutine(Especial());
            yield return new WaitForSecondsRealtime(0.7f);
            yield return StartCoroutine(Ataquebasico6());
            yield return new WaitForSecondsRealtime(0.7f);
        }
    }


    IEnumerator Ataquebasico1()
    {
        yield return new WaitForSecondsRealtime(2.5f);
            hp.GotoNextPoint1();
            yield return new WaitForSecondsRealtime(4f);
            hp.GotoNextPoint2();
        vulnerable = true;
        yield return new WaitForSecondsRealtime(4f);
        vulnerable = false;
        yield break;
    }

    IEnumerator Ataquebasico2()
    {
        yield return new WaitForSecondsRealtime(2.5f);
            hp2.GotoNextPoint1();
            yield return new WaitForSecondsRealtime(1f);
            hp2.GotoNextPoint2();
        vulnerable = true;
        yield return new WaitForSecondsRealtime(4f);
        vulnerable = false;
        yield break;
    }

    IEnumerator Ataquebasico3()
    {
        yield return new WaitForSecondsRealtime(2.5f);
            hp2.GotoNextPoint3();
            yield return new WaitForSecondsRealtime(1f);
            hp2.GotoNextPoint4();
        vulnerable = true;
        yield return new WaitForSecondsRealtime(4f);
        vulnerable = false;
        yield break;
    }

    IEnumerator Ataquebasico4()
    {
        yield return new WaitForSecondsRealtime(2.5f);

            hp.GotoNextPoint1();
            yield return new WaitForSecondsRealtime(1f);
            hp.GotoNextPoint2();
        vulnerable = true;
        yield return new WaitForSecondsRealtime(4f);
        vulnerable = false;
        yield break;
    }

    IEnumerator Ataquebasico5()
    {
        yield return new WaitForSecondsRealtime(2.5f);
            hp.GotoNextPoint2();
            yield return new WaitForSecondsRealtime(1f);
            hp.GotoNextPoint1();
        vulnerable = true;
        yield return new WaitForSecondsRealtime(4f);
        vulnerable = false;
        yield break;
    }

    IEnumerator Ataquebasico6()
    {
        yield return new WaitForSecondsRealtime(2.5f);
       
            hp.GotoNextPoint4();
            yield return new WaitForSecondsRealtime(1f);
            hp.GotoNextPoint3();
        vulnerable = true;
        yield return new WaitForSecondsRealtime(4f);
        vulnerable = false;
        yield break;
    }

  

    IEnumerator Especial()
    {
        GotoPointA();
        yield return new WaitForSecondsRealtime(0.5f);
        GotoPointB();
        yield return new WaitForSecondsRealtime(0.5f);
        OndaExpansiva();
        yield return new WaitForSecondsRealtime(1.5f);
        Destroy(itemSp);
        vulnerable = true;
        yield return new WaitForSecondsRealtime(5f);
        vulnerable = false;
        yield break;
    }

    IEnumerator Final()
    {

        yield break;
    }


    public void GotoPointA()
    {
        hp.agent.destination = pointa.position;
        hp2.agent.destination = pointb.position;
    }

    public void GotoPointB()
    {
        hp.agent.destination = pointc.position;
        hp2.agent.destination = pointd.position;
    }

    void OndaExpansiva()
    {
        Vector3 pos = new Vector3(-1,1,0);
        GameObject clone = Instantiate(itemSp, pos, Quaternion.identity);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (vulnerable ==true)
        {
            if (collider.gameObject.CompareTag("AtaqueUno")) actualvida -= plyr.AttackDmgUno; // Baja la vida del enemigo acorde con el valor que se puso en el ataque.

            if (collider.gameObject.CompareTag("AtaqueDos")) actualvida -= plyr.AttackDmgDos; // Lo de arriba x2.

            if (collider.gameObject.CompareTag("AtaqueTres")) actualvida -= plyr.AttackDmgTres; // Lo de arriba x3.

            if (collider.gameObject.CompareTag("AtaqueCargado")) actualvida -= plyr.AttackDmgCargado; // Lo de arriba x4.
        }

    }


}
