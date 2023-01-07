using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CamPersistente : MonoBehaviour
{
    public static CamPersistente instancia = null;

    public Transform playerPos;
    public Vector3 offSet;
    void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
        }
        else if (instancia != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        playerPos = GameObject.Find("Player").transform;
    }
    private void LateUpdate()
    {
        transform.position = playerPos.position + offSet;
    }
}

