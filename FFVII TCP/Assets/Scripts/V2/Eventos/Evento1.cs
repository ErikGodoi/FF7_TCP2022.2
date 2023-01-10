using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evento1 : MonoBehaviour
{
    public GameObject portaoE, portaoD;

    public bool ativaEvento;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == ("Player"))
        {
            ativaEvento = true;
        }
    }
    private void FixedUpdate()
    {
        evento01();
    }
    public void evento01()
    {
        if (ativaEvento == true)
        {
            portaoE.transform.Translate(1f * Time.fixedDeltaTime, 0, 0);
            portaoD.transform.Translate(-1f * Time.fixedDeltaTime, 0, 0);
        }
    }
}
