using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Enemy enmy;
    public float Timer;
    public float Cooldown;
    public GameObject Enemy;
    public string EnemyName;
    GameObject LastEnemy;

    void Start()
    {
        
        enmy.dead = false;
        this.gameObject.name = EnemyName + " spawn point";
    }

    void Update()
    {
        if (enmy.dead == true)
        {
            Timer += Time.deltaTime;        // Si el enemigo esta muerto inicia el timer.
        }

        if (Timer >= Cooldown) // Si el timer es mayor al cooldown...
        {
            Enemy.transform.position = transform.position;      // Creara un nuevo enemigo en el spawn.

            Instantiate(Enemy);
            LastEnemy = GameObject.Find(Enemy.name + "(Clone)");
            LastEnemy.name = EnemyName;
            enmy = GameObject.FindGameObjectWithTag("Enemigo").GetComponent<Enemy>();

            enmy.dead = false;      // El enemigo no esta muerto

            Timer = 0;      // El timer se resetea
        }
    }
 }