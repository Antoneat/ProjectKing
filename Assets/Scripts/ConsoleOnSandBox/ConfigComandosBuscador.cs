using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.AI;

public class ConfigComandosBuscador : MonoBehaviour
{
    public Enemy enemy;

    public NavMeshAgent navMeshAgent;

    public enemyPatrol enemyPatrol;

    public CapsuleCollider capsuleColliderAtqBasico;
    public CapsuleCollider capsuleColliderMordisco;

    public TMP_Text[] textIntBuscador;


    void Start()
    {
        textIntBuscador[0].text = enemy.vida.ToString();
        textIntBuscador[1].text = navMeshAgent.speed.ToString();
        textIntBuscador[2].text = enemyPatrol.awareAI.ToString(); //rango de seguimiento
        textIntBuscador[3].text = enemyPatrol.atkRange.ToString(); //rango de ataque

        textIntBuscador[4].text = capsuleColliderAtqBasico.radius.ToString(); //rango de atqBasico
        textIntBuscador[5].text = enemy.ataqueNormalDMG.ToString(); //daño del atq basico

        textIntBuscador[6].text = capsuleColliderMordisco.radius.ToString(); //rango de mordisco
        textIntBuscador[7].text = enemy.mordiscoDMG.ToString(); //rango de mordisco
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeLifeBuscador(string Life)
    {
        int lifeNew = Int32.Parse(Life);

        enemy.vida = lifeNew;
        textIntBuscador[0].text = Life;
    }

    public void ChangeSpeedBuscador(string SpeedB)
    {
        int speedNew = Int32.Parse(SpeedB);

        navMeshAgent.speed = speedNew;
        textIntBuscador[1].text = SpeedB;
    }

    public void ChangeAwareAIBuscador(string AwareAI) //modficar distancia de seguimiento
    {
        int awareAiNew = Int32.Parse(AwareAI);

        enemyPatrol.awareAI = awareAiNew;
        textIntBuscador[2].text = AwareAI;
    }

    public void ChangeAtaqueRangoBuscador(string atqRange) //modficar distancia de ataque
    {
        int atqRangeNew = Int32.Parse(atqRange);

        enemyPatrol.atkRange = atqRangeNew;
        textIntBuscador[3].text = atqRange;
    }
    public void ChangeAtqBasicoBuscador(string atqBasico) //modficar distancia de ataque basico
    {
        int atqBasicoNew = Int32.Parse(atqBasico);

        capsuleColliderAtqBasico.radius = atqBasicoNew;
        textIntBuscador[4].text = atqBasico;
    }
    public void ChangeAtqBasicoDMGBuscador(string atqBasicoDMG) //modficar daño del atq basico
    {
        int atqBasicoDMGNew = Int32.Parse(atqBasicoDMG);

        enemy.ataqueNormalDMG = atqBasicoDMGNew;
        textIntBuscador[5].text = atqBasicoDMG;
    }

    public void ChangeMordiscoBuscador(string mordisco) //modficar distancia de mordisco
    {
        int atqBasicoNew = Int32.Parse(mordisco);

        capsuleColliderMordisco.radius = atqBasicoNew;
        textIntBuscador[6].text = mordisco;
    }
    public void ChangeMordiscoDMGBuscador(string mordiscoDMG) //modficar daño del mordisco
    {
        int mordiscoDMGNew = Int32.Parse(mordiscoDMG);

        enemy.mordiscoDMG = mordiscoDMGNew;
        textIntBuscador[7].text = mordiscoDMG;
    }
}
