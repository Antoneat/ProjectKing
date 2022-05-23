using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LookToCam : MonoBehaviour
{
    public Transform target;


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
    }
}
