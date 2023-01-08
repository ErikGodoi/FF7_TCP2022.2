using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CloudV2 : MonoBehaviour
{
    GameManager gm;
    // Status
    CloudStatus cStatus;
    // Status HUD
    TMP_Text textNome;
    TMP_Text textHP;
    Slider sliderHP;
    Slider sliderMP;
    Slider sliderLimit;

    // Turno
    public float turno;
    public GameObject painelDeAcaoC;
    public GameObject painelDeInimigosCFisico;
    public GameObject painelListaMagia;
    public GameObject painelGelo;
    public GameObject painelBolt;

    // Troca de cena
    bool emLuta;

    // teste
    bool cenaAtual;
    public GameObject botaoMob1, botaoMob2, botaoMob3, botaoMob4, botaoMob5;
    public GameObject[] botaoGelo;
    public GameObject[] botaoRaio;
    public Mobs[] inimigo;

    // Defesa
    bool defendendo;

    public bool spawnou;
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        cStatus = FindObjectOfType<CloudStatus>();
        emLuta = false;
        StatusHUD();
    }
    private void Update()
    {
        if (spawnou == true)
        {
            gm.VerificacaoDeVitoria();
        }
        cenaAtual = SceneManager.GetSceneByName("Batalha").isLoaded;
        if (cenaAtual == true)
        {
            emLuta = true;
        }
        if (emLuta == true)
        {
            CloudTurno();
        }
    }
    public void StatusHUD()
    {
        // paineis constantes durante batalha
        textNome = GameObject.Find("CNome").GetComponent<TMP_Text>();
        textNome.text = (cStatus.cNome);
        cStatus.cHp = cStatus.cHpMax;
        cStatus.cMp = cStatus.cMpMax;
        textHP = GameObject.Find("CHP").GetComponent<TMP_Text>();
        textHP.text = (cStatus.cHp.ToString() + " / " + cStatus.cHpMax.ToString());
        sliderHP = GameObject.Find("CSHP").GetComponent<Slider>();
        sliderHP.maxValue = cStatus.cHpMax;
        sliderHP.value = cStatus.cHp;
        sliderMP = GameObject.Find("CSMP").GetComponent<Slider>();
        sliderMP.maxValue = cStatus.cMpMax;
        sliderMP.value = cStatus.cMp;
        sliderLimit = GameObject.Find("CSLimit").GetComponent<Slider>();
        sliderLimit.maxValue = cStatus.cLimitMax;
        sliderLimit.value = cStatus.cLimit;

        // paineis de ação durante batalha
        painelDeAcaoC = GameObject.Find("PanelDeAcaoC");
        painelDeInimigosCFisico = GameObject.Find("CloudDanoFisico");
        painelListaMagia = GameObject.Find("AcaoMagicaC");
        painelGelo = GameObject.Find("CloudDanoGelo");
        painelBolt = GameObject.Find("CloudDanoRaio");

        botaoMob1 = GameObject.Find("MobP1C");
        botaoMob2 = GameObject.Find("MobP2C");
        botaoMob3 = GameObject.Find("MobP3C");
        botaoMob4 = GameObject.Find("MobP4C");
        botaoMob5 = GameObject.Find("MobP5C");
        botaoGelo[0] = GameObject.Find("MobP1CGelo");
        botaoGelo[1] = GameObject.Find("MobP2CGelo");
        botaoGelo[2] = GameObject.Find("MobP3CGelo");
        botaoGelo[3] = GameObject.Find("MobP4CGelo");
        botaoGelo[4] = GameObject.Find("MobP5CGelo");
        botaoRaio[0] = GameObject.Find("MobP1CRaio");
        botaoRaio[1] = GameObject.Find("MobP2CRaio");
        botaoRaio[2] = GameObject.Find("MobP3CRaio");
        botaoRaio[3] = GameObject.Find("MobP4CRaio");
        botaoRaio[4] = GameObject.Find("MobP5CRaio");

    }
    void CloudTurno()
    {
        if (turno < 100)
        {
            turno += Time.deltaTime * 50f;
        }
        if (turno >= 100)
        {
            painelDeAcaoC.SetActive(true);
            defendendo = false;
        }
        else
        {
            painelDeAcaoC.SetActive(false);
            painelDeInimigosCFisico.SetActive(false);
            painelListaMagia.SetActive(false);
            painelGelo.SetActive(false);
            painelBolt.SetActive(false);
        }
    }
    public void TomarDanoFisico(float dano)
    {
        if (defendendo == true)
        {
            cStatus.cHp -= (dano + cStatus.cDefense * 0.5f);
        }
        else
        {
            cStatus.cHp -= (dano + cStatus.cDefense);
        }
        textHP.text = (cStatus.cHp.ToString() + " / " + cStatus.cHpMax.ToString());
        sliderHP.value = cStatus.cHp;
        sliderHP.maxValue = cStatus.cHpMax;
    }
    public void TomarDanoMagico(float dano)
    {
        cStatus.cHp -= dano + cStatus.cMagicDefense;
        textHP.text = (cStatus.cHp.ToString() + " / " + cStatus.cHpMax.ToString());
    }
    public void CloudMana(float mana)
    {
        cStatus.cMp -= mana;
        sliderMP.value = cStatus.cMp;
        sliderMP.maxValue = cStatus.cMpMax;
    }
    public void LimitCloud(int ultimate)
    {
        cStatus.cLimit += ultimate;
        sliderLimit.value = cStatus.cLimit;
        sliderLimit.maxValue = cStatus.cLimitMax;
    }
    public void CloudDanoFisico()
    {
        
        if (botaoMob1.gameObject.name == "MobP1C")
        {
            inimigo[0].MobVida(cStatus.cDano);
            turno = 0;
            return;
        }
        if (botaoMob2.gameObject.name == "MobP2C")
        {
            inimigo[1].MobVida(cStatus.cDano);
            turno = 0;
            return;
        }
        if (botaoMob3.gameObject.name == "MobP3C")
        {
            inimigo[2].MobVida(cStatus.cDano);
            turno = 0;
            return;
        }
        if (botaoMob4.gameObject.name == "MobP4C")
        {
            inimigo[3].MobVida(cStatus.cDano);
            turno = 0;
            return;
        }
        if (botaoMob5.gameObject.name == "MobP5C")
        {
            inimigo[4].MobVida(cStatus.cDano);
            turno = 0;
            return;
        }
    }
    public void CloudDanoMagico()
    {
        cStatus.cDanoMagico = 6 * (cStatus.cMagicAttack + cStatus.cLevel);
    }
    public void HUDgelo()
    {
        painelGelo.SetActive(true);
        painelBolt.SetActive(false);
        painelDeInimigosCFisico.SetActive(false);
        AtualizarHUDGelo();
    }
    public void HUDbolt()
    {
        painelBolt.SetActive(true);
        painelGelo.SetActive(false);
        painelDeInimigosCFisico.SetActive(false);
        AtualizarHUDRaio();
    }
    public void CloudIce()
    {
        cStatus.cDanoMagico = 6 * (cStatus.cMagicAttack + cStatus.cLevel);

        if (botaoGelo[0].gameObject.name == "MobP1CGelo")
        {
            inimigo[0].MobVida(cStatus.cDanoMagico * inimigo[0].fIce);
            turno = 0;
            return;
        }
        if (botaoGelo[1].gameObject.name == "MobP2CGelo")
        {
            inimigo[1].MobVida(cStatus.cDanoMagico * inimigo[1].fIce);
            turno = 0;
            return;
        }
        if (botaoGelo[2].gameObject.name == "MobP3CGelo")
        {
            inimigo[2].MobVida(cStatus.cDanoMagico * inimigo[2].fIce);
            turno = 0;
            return;
        }
        if (botaoGelo[3].gameObject.name == "MobP4CGelo")
        {
            inimigo[3].MobVida(cStatus.cDanoMagico * inimigo[3].fIce);
            turno = 0;
            return;
        }
        if (botaoGelo[4].gameObject.name == "MobP5CGelo")
        {
            inimigo[4].MobVida(cStatus.cDanoMagico * inimigo[4].fIce);
            turno = 0;
            return;
        }
    }
    public void CloudBolt()
    {
        cStatus.cDanoMagico = 6 * (cStatus.cMagicAttack + cStatus.cLevel);

        if (botaoRaio[0].gameObject.name == "MobP1CRaio")
        {
            inimigo[0].MobVida(cStatus.cDanoMagico * inimigo[0].fBolt);
            turno = 0;
            return;
        }
        if (botaoRaio[1].gameObject.name == "MobP2CRaio")
        {
            inimigo[1].MobVida(cStatus.cDanoMagico * inimigo[1].fBolt);
            turno = 0;
            return;
        }
        
        if (botaoRaio[2].gameObject.name == "MobP3CRaio")
        {
            inimigo[2].MobVida(cStatus.cDanoMagico * inimigo[2].fBolt);
            turno = 0;
            return;
        }
        if (botaoRaio[3].gameObject.name == "MobP4CRaio")
        {
            inimigo[3].MobVida(cStatus.cDanoMagico * inimigo[3].fBolt);
            turno = 0;
            return;
        }
        if (botaoRaio[4].gameObject.name == "MobP5CRaio")
        {
            inimigo[4].MobVida(cStatus.cDanoMagico * inimigo[4].fBolt);
            turno = 0;
            return;
        }
    }
    public void AcaoDeAtaque()
    {
        cStatus.cDano = ((cStatus.cAttack + cStatus.cLevel) / 32) * ((cStatus.cAttack * cStatus.cLevel) / 32) + cStatus.cAttack;
        Debug.Log(cStatus.cDano);
        painelDeInimigosCFisico.SetActive(true);
        painelListaMagia.SetActive(false);
        painelGelo.SetActive(false);
        painelBolt.SetActive(false);
        inimigo = FindObjectsOfType<Mobs>();
        AtualizarHUD();
    }
    public void AcaoDeMagia()
    {
        painelListaMagia.SetActive(true);
        inimigo = FindObjectsOfType<Mobs>();
    }
    public void AcaoDeItem()
    {

    }
    public void AtualizarHUD()
    {
        if (inimigo.Length < 5)
        {
            botaoMob5.SetActive(false);
        }
        if (inimigo.Length < 4)
        {
            botaoMob4.SetActive(false);
        }
        if (inimigo.Length < 3)
        {
            botaoMob3.SetActive(false);
        }
        if (inimigo.Length < 2)
        {
            botaoMob2.SetActive(false);
        }
        if (inimigo.Length < 1)
        {
            botaoMob1.SetActive(false);
        }
    }
    public void AtualizarHUDGelo()
    {
        if (inimigo.Length < 5)
        {
            botaoGelo[4].SetActive(false);
        }
        if (inimigo.Length < 4)
        {
            botaoGelo[3].SetActive(false);
        }
        if (inimigo.Length < 3)
        {
            botaoGelo[2].SetActive(false);
        }
        if (inimigo.Length < 2)
        {
            botaoGelo[1].SetActive(false);
        }
        if (inimigo.Length < 1)
        {
            botaoGelo[0].SetActive(false);
        }
    }
    public void AtualizarHUDRaio()
    {
        if (inimigo.Length < 5)
        {
            botaoRaio[4].SetActive(false);
        }
        if (inimigo.Length < 4)
        {
            botaoRaio[3].SetActive(false);
        }
        if (inimigo.Length < 3)
        {
            botaoRaio[2].SetActive(false);
        }
        if (inimigo.Length < 2)
        {
            botaoRaio[1].SetActive(false);
        }
        if (inimigo.Length < 1)
        {
            botaoRaio[0].SetActive(false);
        }
    }
    public void Defendendo()
    {
        turno = 0;
        defendendo = true;
    }
}
