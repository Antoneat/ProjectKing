using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using Cinemachine;

public class ConfigComandosCamara : MonoBehaviour
{
    public Transform TransformCam;
    
    public CinemachineVirtualCamera VirtualCamera;

    public int posXp, posYp, posZp;

    public TMP_Text[] textIntCamara;


    void Start()
    {
        textIntCamara[0].text = TransformCam.rotation.x.ToString();
        textIntCamara[1].text = TransformCam.rotation.y.ToString();
        textIntCamara[2].text = TransformCam.rotation.z.ToString();
        textIntCamara[3].text = VirtualCamera.m_Lens.FieldOfView.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangePosX(string posX)
    {
        int posXNew = Int32.Parse(posX);
        posXp = posXNew;

        //TransformCam.rotation.Equals(transform.rotation.x == posXNew);
        textIntCamara[0].text = posX;


        TransformCam.eulerAngles.Set(posXNew,posYp, posZp);
    }

    public void ChangePosY(string posY)
    {
        int posYNew = Int32.Parse(posY);
        posYp = posYNew;

        //TransformCam.rotation.Equals(transform.rotation.y == posYNew);
        textIntCamara[1].text = posY;

        TransformCam.eulerAngles.Set(posXp, posYNew, posZp);
    }

    public void ChangePosZ(string posZ)
    {
        int posZNew = Int32.Parse(posZ);
        posZp = posZNew;

        //TransformCam.rotation.Equals(transform.rotation.z == posZNew);
        textIntCamara[2].text = posZ;

        TransformCam.eulerAngles.Set(posXp, posYp, posZNew);
    }
    public void ChangeFOVCamara(string FOVCamara)
    {
        int FOVCamaraNew = Int32.Parse(FOVCamara);

        VirtualCamera.m_Lens.FieldOfView = FOVCamaraNew;
        textIntCamara[3].text = FOVCamara;
    }
}
