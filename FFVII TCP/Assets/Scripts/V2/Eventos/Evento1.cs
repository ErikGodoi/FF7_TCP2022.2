using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evento1 : MonoBehaviour
{
    public GameObject[] Portoes;

    bool ativaEvento;

    float desliza = 0.3f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == ("Player"))
        {
            ativaEvento = true;
        }
    }
    private void FixedUpdate()
    {
        Evento01();
    }
    void Evento01()
    {
        if (ativaEvento == true)
        {
            if (Portoes[0].transform.position.x >= 30)
            {
                Portoes[0].transform.position = new Vector3(Portoes[0].transform.position.x, 1, 0);
                Portoes[1].transform.position = new Vector3(Portoes[0].transform.position.x, 1, 0);
            }
            if (Portoes[0].transform.position.x <= 29.9)
            {
                Portoes[0].transform.position = new Vector3(Portoes[0].transform.position.x + desliza, 1, 0);
                Portoes[1].transform.position = new Vector3(Portoes[0].transform.position.x - desliza, 1, 0);
            }
        }
        
    }
}
