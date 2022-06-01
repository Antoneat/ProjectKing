using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForPlayerRender : MonoBehaviour
{
    void Update()
    {
        transform.SetPositionAndRotation(new Vector3(0,0.134f,0.36f), Quaternion.Euler(30, 0, 0));
    }
}
