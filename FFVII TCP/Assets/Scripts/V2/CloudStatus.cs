using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CloudStatus : MonoBehaviour
{
    public static CloudStatus instancia = null;
    // CLOUD STATUS
    public string cNome;
    public int cEXP;
    public int cEXPMax;
    public float cLevel;
    public float cHp, cHpMax;
    public float cMp, cMpMax;
    public float cLimit, cLimitMax;

    public float cDano;
    public float cDanoMagico;

    public float cStr;
    public float cDex;
    public float cVit;
    public float cMagic;
    public float cSpirit;
    public float cLuck;

    public float cAttack;
    public float cDefense;
    public float cMagicAttack;
    public float cMagicDefense;
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
        DefinirStatusInicial();
    }
    private void DefinirStatusInicial()
    {
        cNome = "Ex-SOLDIER";
        cLevel = 7;
        cEXPMax = 350;

        cHpMax = 314;
        cMpMax = 57;
        cLimitMax = 100;

        cStr = 20;
        cDex = 8;
        cVit = 16;
        cMagic = 25;
        cSpirit = 17;
        cLuck = 17;

        cAttack = 38;
        cDefense = 24;
        cMagicAttack = 25;
        cMagicDefense = 17;

        cHp = cHpMax;
        cMp = cMpMax;
    }
    private void Update()
    {
        if (cEXP >= cEXPMax)
        {
            CloudLevelUP();
        }
    }
    public void CloudLevelUP()
    {
        cLevel += 1;
        cEXPMax += 150;
        cEXP = 0;

        cHpMax += 100;
        cMpMax += 50;

        cStr += 3;
        cDex += 2;
        cVit += 2;
        cMagic += 3;
        cSpirit += 3;
        cLuck += 1;

        cAttack += 5;
        cDefense += 3;
        cMagicAttack += 3;
        cMagicDefense += 3;

        cHp = cHpMax;
        cMp = cMpMax;
    }
}
