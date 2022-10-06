using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOBMP : MonoBehaviour
{
    string nome;

    byte level;
    int eXP;

    short hP, hPMax, mP, mPMax;
    short attack;
    short defense;
    short defensePercentage;
    short magicAttack;
    short magicDefense;

    byte dex;
    byte luck;

    int recompensaExp, recompensaGil, recompensaAP;

    void Start()
    {

    }
    void Update()
    {

    }
    public void Status()
    {
        nome = "MP";
        level = 2;

        hPMax = 30;
        mPMax = 0;

        dex = 50;
        luck = 4;

        attack = 6;
        defense = 4;
        defensePercentage = 0;
        magicAttack = 0;
        magicDefense = 0;
    }
    public void Recompensa()
    {
        recompensaExp = 16;
        recompensaGil = 10;
        recompensaAP = 2;
    }
}
