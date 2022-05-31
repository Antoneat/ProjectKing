using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ConfigComandosPlayer : MonoBehaviour
{

    public Player player;

    public TMP_Text[] textIntPlayer;

    public BoxCollider[] boxColliders;
    public SphereCollider sphereCollider;


    void Start()
    {
        textIntPlayer[0].text = player.actualvida.ToString();
        textIntPlayer[1].text = player.speed.ToString();
        textIntPlayer[2].text = player.speedDash.ToString();
        textIntPlayer[3].text = boxColliders[0].size.x.ToString();
        textIntPlayer[4].text = boxColliders[1].size.x.ToString();
        textIntPlayer[5].text = boxColliders[2].size.x.ToString();
        textIntPlayer[6].text = sphereCollider.radius.ToString();
        textIntPlayer[7].text = player.AttackDmgUno.ToString();
        textIntPlayer[8].text = player.AttackDmgDos.ToString();
        textIntPlayer[9].text = player.AttackDmgTres.ToString();
        textIntPlayer[10].text = player.AttackDmgCargado.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeLifePlayer(string Life)
    {
        int lifeNew = Int32.Parse(Life);

        player.actualvida = lifeNew;
        textIntPlayer[0].text = Life;
    }

    public void ChangeSpeedPlayer(string SpeedP)
    {
        int speedNew = Int32.Parse(SpeedP);

        player.speed = speedNew;
        textIntPlayer[1].text = SpeedP;
    }

    public void ChangeSpeedDashPlayer(string SpeedDashP)
    {
        int speedDashNew = Int32.Parse(SpeedDashP);

        player.speedDash = speedDashNew;
        textIntPlayer[2].text = SpeedDashP;
    }
    public void ChangeAtqRange1Player(string atqRg1)
    {
        float atqRg1New = float.Parse(atqRg1);

        boxColliders[0].size = new Vector3(atqRg1New, 1, 0.5f);
        textIntPlayer[3].text = atqRg1;
    }
    public void ChangeAtqRange2Player(string atqRg2)
    {
        float atqRg2New = float.Parse(atqRg2);

        boxColliders[1].size = new Vector3(atqRg2New, 1, 0.5f);
        textIntPlayer[4].text = atqRg2;
    }
    public void ChangeAtqRange3Player(string atqRg3)
    {
        float atqRg3New = float.Parse(atqRg3);

        boxColliders[2].size = new Vector3(atqRg3New, 1, 0.5f);
        textIntPlayer[5].text = atqRg3;
    }
    public void ChangeAtqRangeChPlayer(string atqRgCH)
    {
        float atqRgChNew = float.Parse(atqRgCH);

        sphereCollider.radius = atqRgChNew;
        textIntPlayer[6].text = atqRgCH;
    }
    public void ChangeAtqDmg1Player(string atqDmg1)
    {
        int atqDMG1New = Int32.Parse(atqDmg1);

        player.AttackDmgUno = atqDMG1New;
        textIntPlayer[7].text = atqDmg1;
    }
    public void ChangeAtqDmg2Player(string atqDmg2)
    {
        int atqDMG2New = Int32.Parse(atqDmg2);

        player.AttackDmgDos = atqDMG2New;
        textIntPlayer[8].text = atqDmg2;
    }
    public void ChangeAtqDmg3Player(string atqDmg3)
    {
        int atqDMG3New = Int32.Parse(atqDmg3);

        player.AttackDmgTres = atqDMG3New;
        textIntPlayer[9].text = atqDmg3;
    }
    public void ChangeAtqDmgChPlayer(string atqDmgCH)
    {
        int atqDMGchNew = Int32.Parse(atqDmgCH);

        player.AttackDmgCargado = atqDMGchNew;
        textIntPlayer[10].text = atqDmgCH;
    }

}
