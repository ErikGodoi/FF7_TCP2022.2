using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CamPlayer : MonoBehaviour
{
    public CinemachineVirtualCamera vCam;
    public Transform objetoSeguido;
    private void Awake()
    {
        Camera.main.gameObject.TryGetComponent<CinemachineBrain>(out var brain);
        if (brain == null)
        {
            brain = Camera.main.gameObject.AddComponent<CinemachineBrain>();
        }
        vCam = gameObject.GetComponent<CinemachineVirtualCamera>();
        objetoSeguido = GameObject.Find("Player").transform;
        vCam.LookAt = objetoSeguido;
    }
}
