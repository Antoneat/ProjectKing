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


    void Start()
    {
        textIntPlayer[0].text = player.actualvida.ToString();
        textIntPlayer[1].text = player.speed.ToString();
        textIntPlayer[2].text = player.speedDash.ToString();
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


}
