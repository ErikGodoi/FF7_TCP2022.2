using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CloudStatus : MonoBehaviour
{
    string nome;
    byte level;
    int eXP;

    short hP,hPMax, mP,mPMax;
    short attack;
    short attackPercentage;
    short defense;
    short defensePercentage;
    short magicAttack;
    short magicDefense;
    short magicDefensePercentage;

    byte str;
    byte dex;
    byte vit;
    byte magic;
    byte spirit;
    byte luck;

    int AP;

    // UI de batalha recebe os status
    public TextMeshProUGUI textoDeNome;
    public TextMeshProUGUI textoDeHP;
    public TextMeshProUGUI textoDeMP;
    public Slider sliderCloud;

    // Turno
    float cloudTurno;
    public bool cloudPodeAgir;
    private void Start()
    {
        Status();
        textoDeNome = GameObject.Find("Chac1").GetComponent<TextMeshProUGUI>();
        textoDeNome.text = (nome);
        textoDeHP = GameObject.Find("CLHP").GetComponent<TextMeshProUGUI>();
        textoDeMP = GameObject.Find("CLMP").GetComponent<TextMeshProUGUI>();
        sliderCloud = GameObject.Find("CTime").GetComponent<Slider>();

        hP = hPMax;
        mP = mPMax;
        
    }
    private void FixedUpdate()
    {
        Turno();
        textoDeHP.text = (hP.ToString() + " / " + hPMax.ToString());
        textoDeMP.text = (mP.ToString());
    }
    public void Status()
    {
        nome = "Ex-SOLDIER";
        level = 6;

        hPMax = 302;
        mPMax = 56;

        str = 18;
        dex = 6;
        vit = 16;
        magic = 23;
        spirit = 17;
        luck = 14;

        attack = 36;
        attackPercentage = 96;
        defense = 24;
        defensePercentage = 1;
        magicAttack = 23;
        magicDefense = 17;
        magicDefensePercentage = 0;

        AP = 0;
    }
    public void Turno()
    {
        sliderCloud.value = cloudTurno;
        cloudTurno += 15f * Time.fixedDeltaTime;
        if (cloudTurno >= 100f)
        {
            cloudTurno = 100f;
            cloudPodeAgir = true;
        }
        else cloudPodeAgir = false;
    }
}
