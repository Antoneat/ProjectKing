using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState { Normal, Quemado, Sangrado, Stun };
public class StateManager : MonoBehaviour
{
    public PlayerState ps;
    Player Pl;

    void Start()
    {

        ps = PlayerState.Normal;

    }


    void Update()
    {

    }

    void Stados()
    {
        switch (ps)
        {
            case PlayerState.Normal:

                break;

            case PlayerState.Quemado:
                StartCoroutine(OnFire());
                break;

            case PlayerState.Sangrado:
                StartCoroutine(Sangrando());
                break;

            case PlayerState.Stun:
                StartCoroutine(Stuneado());
                break;
        }

    }
    IEnumerator OnFire()
    {
        Pl.actualvida -= 2;
        Pl.speed -= 4;
        yield return new WaitForSecondsRealtime(3f);
        yield break;
    }

    IEnumerator Sangrando()
    {
        Pl.actualvida -= 2;
        yield return new WaitForSecondsRealtime(3f);
        yield break;
    }

    IEnumerator Stuneado()
    {
        Pl.speed = 0;
        yield return new WaitForSecondsRealtime(4f);
        yield break;
    }
}
