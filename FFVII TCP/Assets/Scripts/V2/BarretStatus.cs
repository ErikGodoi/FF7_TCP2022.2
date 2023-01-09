using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarretStatus : MonoBehaviour
{
    public static BarretStatus instancia = null;
    // BARRET STATUS
    public string bNome;
    public float bLevel;
    public float bHp, bHpMax;
    public float bMp, bMpMax;
    public float bLimit, bLimitMax;

    public float bDano;
    public float bDanoMagico;

    public float bStr;
    public float bDex;
    public float bVit;
    public float bMagic;
    public float bSpirit;
    public float bLuck;

    public float bAttack;
    public float bDefense;
    public float bMagicAttack;
    public float bMagicDefense;
    // FIM DO STATUS DO BARRET
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
    void Start()
    {
        DefinirStatusInicial();
    }
    private void DefinirStatusInicial()
    {
        bNome = "Barret";
        bLevel = 6;

        bHpMax = 312;
        bMpMax = 44;
        bLimitMax = 100;

        bStr = 20;
        bDex = 11;
        bVit = 20;
        bMagic = 17;
        bSpirit = 14;
        bLuck = 17;

        bAttack = 34;
        bDefense = 28;
        bMagicAttack = 17;
        bMagicDefense = 14;

        bHp = bHpMax;
        bMp = bMpMax;
    }
    public void BarretLevelUP()
    {
        bLevel += 1;

        bHpMax += 100;
        bMpMax += 50;

        bStr += 3;
        bDex += 2;
        bVit += 2;
        bMagic += 3;
        bSpirit += 3;
        bLuck += 1;

        bAttack += 5;
        bDefense += 3;
        bMagicAttack += 3;
        bMagicDefense += 3;

        bHp = bHpMax;
        bMp = bMpMax;
    }
}
