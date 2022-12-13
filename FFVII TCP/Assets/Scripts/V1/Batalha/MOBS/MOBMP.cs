using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MOBMP : MonoBehaviour
{
    string nome;

    byte level;
    int eXP;

    public int hP, hPMax, mP, mPMax;
    short attack;
    short defense;
    short magicAttack;
    short magicDefense;

    byte dex;
    byte luck;

    int rExp, rGil, rAP;

    void Start()
    {
        Status();
        hP = hPMax;
    }
    void Update()
    {
        if (hP <= 0)
        {
            Destroy(gameObject);
        }
        
    }
    public void Status()
    {
        nome = "MP";
        level = 2;
        
        hPMax = 300;
        mPMax = 0;

        dex = 50;
        luck = 4;

        attack = 6;
        defense = 4;
        magicAttack = 0;
        magicDefense = 0;
    }
    public void Recompensa()
    {
        rExp = 16;
        rGil = 10;
        rAP = 2;
    }
    public void MobVida(int dano)
    {
        hP -= dano;
    }
}
