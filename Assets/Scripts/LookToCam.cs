using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookToCam : MonoBehaviour
{
    void Update()
    {
        transform.rotation = Quaternion.Euler(45,0,0);
    }
}
