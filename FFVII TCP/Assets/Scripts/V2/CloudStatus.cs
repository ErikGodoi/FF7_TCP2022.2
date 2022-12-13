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
    // FIM DO STATUS DO CLOUD
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
    public void CloudLevelUP()
    {

    }
}
