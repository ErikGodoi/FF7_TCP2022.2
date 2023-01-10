using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigosAnimacao : MonoBehaviour
{
    Animator ani;
    void Start()
    {
        ani = GetComponent<Animator>();
    }
    public void Animacao1()
    {
        ani.SetTrigger("Attack1");
    }
    public void Animacao2()
    {
        ani.SetTrigger("Attack2");
    }
}
