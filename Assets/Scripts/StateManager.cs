using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState { Normal, Quemado, Sangrado, Stun };
public class StateManager : MonoBehaviour
{
    public PlayerState ps;
    Player Pl;

    public float dmgTick; // Damage each tick
    public float timeXTick; // Time in seconds each tick of damage
    public int totalTicks; // how many seconds ( ticks )  damage each tick

    void Start()
    {

        ps = PlayerState.Normal;

    }


    void Update()
    {
        Stados();
    }

    IEnumerator Normal()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        yield break;
    }

    void Stados()
    {
        switch (ps)
        {
            case PlayerState.Normal:
                StartCoroutine(Normal());
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
       
        dmgTick = 2;
        timeXTick = 2;
        totalTicks = 4;

        int ticks = 0;
        int totalTicksTemp = totalTicks;

        while (ticks < totalTicksTemp)
        {
            ticks++;
            Pl.actualvida -= dmgTick;  // Player recive damage
            Pl.speed -= 4;
            yield return new WaitForSecondsRealtime(timeXTick);  // wait second
            ps = PlayerState.Normal;
            yield break;

        }
    }

    IEnumerator Sangrando()
    {

        dmgTick = 4;
        timeXTick = 4;
        totalTicks = 3;

        int ticks = 0;
        int totalTicksTemp = totalTicks;

        while (ticks < totalTicksTemp)
        {
            ticks++;
            Pl.actualvida -= dmgTick;  // Player recive damage
            yield return new WaitForSecondsRealtime(timeXTick);  // wait second
            ps = PlayerState.Normal;
            yield break;
            
        }
      
    }

    IEnumerator Stuneado()
    {
        Pl.speed = 0;
        yield return new WaitForSecondsRealtime(4f);
        ps = PlayerState.Normal;
        yield break;
    }
}
