using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncontroAleatorio : MonoBehaviour
{
    bool emBatalha;
    float cdDeBatalha;
    void Start()
    {
        
    }
    private void FixedUpdate()
    {
        if (cdDeBatalha > 0 || emBatalha == false)
        {
            cdDeBatalha -= Time.fixedDeltaTime;
        }
    }
    void EncontroDeBatalha()
    {
        if (emBatalha == true)
        {
            Debug.Log("Encontrou inimigos");
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == ("Prerigo"))
        {

        }
    }
}
