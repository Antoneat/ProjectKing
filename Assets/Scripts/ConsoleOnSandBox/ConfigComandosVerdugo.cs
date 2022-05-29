using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.AI;
public class ConfigComandosVerdugo : MonoBehaviour
{
    public Enemy2 enemy2;

    public NavMeshAgent navMeshAgent;

    public enemyPatrol2 enemyPatrol2;

    public CapsuleCollider capsuleColliderAtqBasico;
    public CapsuleCollider capsuleColliderGolpe;
    public CapsuleCollider capsuleColliderRafaga;

    public TMP_Text[] textIntBuscador;


    void Start()
    {
        textIntBuscador[0].text = enemy2.vida.ToString();
        textIntBuscador[1].text = navMeshAgent.speed.ToString();
        textIntBuscador[2].text = enemyPatrol2.awareAI.ToString(); //rango de seguimiento
        textIntBuscador[3].text = enemyPatrol2.atkRange.ToString(); //rango de ataque

        textIntBuscador[4].text = capsuleColliderAtqBasico.radius.ToString(); //rango de atqBasico
        textIntBuscador[5].text = enemy2.atkbasDMG.ToString(); //daño del atq basico

        textIntBuscador[6].text = capsuleColliderGolpe.radius.ToString(); //rango de golpe al piso
        textIntBuscador[7].text = enemy2.golpeDMG.ToString(); //daño de golpe al piso

        textIntBuscador[8].text = capsuleColliderRafaga.radius.ToString(); //rango de rafaga
        textIntBuscador[9].text = enemy2.rafagaDMG.ToString(); //daño de rafaga
    }

    public void ChangeLifeVerdugo(string Life)
    {
        int lifeNew = Int32.Parse(Life);

        enemy2.vida = lifeNew;
        textIntBuscador[0].text = Life;
    }

    public void ChangeSpeedVerdugo(string SpeedV)
    {
        int speedNew = Int32.Parse(SpeedV);

        navMeshAgent.speed = speedNew;
        textIntBuscador[1].text = SpeedV;
    }

    public void ChangeAwareAIVerdugo(string AwareAI) //modficar distancia de seguimiento
    {
        int awareAiNew = Int32.Parse(AwareAI);

        enemyPatrol2.awareAI = awareAiNew;
        textIntBuscador[2].text = AwareAI;
    }

    public void ChangeAtaqueRangoVerdugo(string atqRange) //modficar distancia de ataque
    {
        int atqRangeNew = Int32.Parse(atqRange);

        enemyPatrol2.atkRange = atqRangeNew;
        textIntBuscador[3].text = atqRange;
    }
    public void ChangeAtqBasicoVerdugo(string atqBasico) //modficar distancia de ataque basico
    {
        int atqBasicoNew = Int32.Parse(atqBasico);

        capsuleColliderAtqBasico.radius = atqBasicoNew;
        textIntBuscador[4].text = atqBasico;
    }
    public void ChangeAtqBasicoDMGVerdugo(string atqBasicoDMG) //modficar daño del atq basico
    {
        int atqBasicoDMGNew = Int32.Parse(atqBasicoDMG);

        enemy2.atkbasDMG = atqBasicoDMGNew;
        textIntBuscador[5].text = atqBasicoDMG;
    }

    public void ChangeGolpePisoVerdugo(string golpePiso) //modficar distancia de Golpe piso
    {
        int golpePisoNew = Int32.Parse(golpePiso);

        capsuleColliderGolpe.radius = golpePisoNew;
        textIntBuscador[6].text = golpePiso;
    }
    public void ChangeGolpePisoDMGVerdugo(string golpePisoDMG) //modficar daño del golpe piso
    {
        int mordiscoDMGNew = Int32.Parse(golpePisoDMG);

        enemy2.golpeDMG = mordiscoDMGNew;
        textIntBuscador[7].text = golpePisoDMG;
    }
    public void ChangeRafagaVerdugo(string rafaga) //modficar distancia de rafaga
    {
        int rafagaNew = Int32.Parse(rafaga);

        capsuleColliderRafaga.radius = rafagaNew;
        textIntBuscador[8].text = rafaga;
    }
    public void ChangeRafagaDMGVerdugo(string rafagaDMG) //modficar daño de rafaga
    {
        int rafagaNew = Int32.Parse(rafagaDMG);

        enemy2.rafagaDMG = rafagaNew;
        textIntBuscador[9].text = rafagaDMG;
    }
}
