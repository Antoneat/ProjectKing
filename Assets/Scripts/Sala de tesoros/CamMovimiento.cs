using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovimiento : MonoBehaviour
{
    public Transform[] views;
    public GameObject[] luces;

    public float transitionSpeed;

    public Transform currentView;


    void Start()
    {
        currentView = views[0];   
    }

    
    void Update()
    {

        if (currentView == views[0])
        {
            luces[0].SetActive(true);
            luces[1].SetActive(false);
            if (Input.GetKeyDown(KeyCode.D))
            {
                currentView = views[1];
            }
        }

        if (currentView == views[1])
        {
            luces[0].SetActive(false);
            luces[1].SetActive(true);
            if (Input.GetKeyDown(KeyCode.A))
            {
                currentView = views[0];
            }
            
            if (Input.GetKeyDown(KeyCode.D))
            {
                currentView = views[2];
            }
        }

        if (currentView == views[2])
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                currentView = views[1];
            }
            
            if (Input.GetKeyDown(KeyCode.D))
            {
                currentView = views[3];
            }
        }

        if (currentView == views[3])
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                currentView = views[2];
            }
            
            if (Input.GetKeyDown(KeyCode.D))
            {
                currentView = views[4];
            }
        }

        if (currentView == views[4])
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                currentView = views[3];
            }
            
            if (Input.GetKeyDown(KeyCode.D))
            {
                currentView = views[1];
            }
        }
    }

    private void LateUpdate()
    {
        
        transform.position=Vector3.Lerp(transform.position,currentView.position,Time.deltaTime * transitionSpeed);

        Vector3 currentAngle = new Vector3(
            Mathf.Lerp(transform.rotation.eulerAngles.x, currentView.transform.rotation.eulerAngles.x,
            Time.deltaTime * transitionSpeed),

            Mathf.Lerp(transform.rotation.eulerAngles.y, currentView.transform.rotation.eulerAngles.y,
            Time.deltaTime * transitionSpeed),

            Mathf.Lerp(transform.rotation.eulerAngles.z, currentView.transform.rotation.eulerAngles.z,
            Time.deltaTime * transitionSpeed)

            );

        transform.eulerAngles = currentAngle;
    }
}
