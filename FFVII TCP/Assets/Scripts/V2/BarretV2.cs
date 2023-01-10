using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class BarretV2 : MonoBehaviour
{
    GameManager gm;
    // Status
    BarretStatus bStatus;
    // Status HUD
    TMP_Text textNome;
    TMP_Text textHP;
    Slider sliderHP;
    Slider sliderMP;
    Slider sliderLimit;

    // Turno
    public float turno;
    public GameObject painelDeAcaoB;
    public GameObject painelDeInimigosBFisico;

    // Troca de cena
    bool emLuta;
    
    // teste
    public bool cenaAtual;
    public GameObject[] botaoMob;
    public Mobs[] inimigo;
    [SerializeField] Animator ani;

    // Defesa
    bool defendendo;
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        bStatus = FindObjectOfType<BarretStatus>();
        emLuta = false;
        StatusHUD();
    }
    private void Update()
    {
        cenaAtual = SceneManager.GetSceneByName("Batalha").isLoaded;
        if (cenaAtual == true)
        {
            emLuta = true;
        }
        if (emLuta == true)
        {
            BarretTurno();
        }
    }
    public void StatusHUD()
    {
        // paineis constantes durante batalha
        textNome = GameObject.Find("BNome").GetComponent<TMP_Text>();
        textNome.text = (bStatus.bNome);
        bStatus.bHp = bStatus.bHpMax;
        bStatus.bMp = bStatus.bMpMax;
        textHP = GameObject.Find("BHP").GetComponent<TMP_Text>();
        textHP.text = (bStatus.bHp.ToString() + " / " + bStatus.bHpMax.ToString());
        sliderHP = GameObject.Find("BSHP").GetComponent<Slider>();
        sliderHP.maxValue = bStatus.bHpMax;
        sliderHP.value = bStatus.bHp;
        sliderMP = GameObject.Find("BSMP").GetComponent<Slider>();
        sliderMP.maxValue = bStatus.bMpMax;
        sliderMP.value = bStatus.bMp;
        sliderLimit = GameObject.Find("BSLimit").GetComponent<Slider>();
        sliderLimit.maxValue = bStatus.bLimitMax;
        sliderLimit.value = bStatus.bLimit;

        // Acao HUD
        painelDeAcaoB = GameObject.Find("PanelDeAcaoB");
        painelDeInimigosBFisico = GameObject.Find("BarretDanoFisico");
        botaoMob[0] = GameObject.Find("MobP1B");
        botaoMob[1] = GameObject.Find("MobP2B");
        botaoMob[2] = GameObject.Find("MobP3B");
        botaoMob[3] = GameObject.Find("MobP4B");
        botaoMob[4] = GameObject.Find("MobP5B");
    }
    void BarretTurno()
    {
        if (turno < 100)
        {
            turno += Time.deltaTime * 10f;
        }
        if (turno >= 100)
        {
            painelDeAcaoB.SetActive(true);
            defendendo = false;
        }
        else
        {
            painelDeAcaoB.SetActive(false);
            painelDeInimigosBFisico.SetActive(false);
        }
    }
    public void TomarDanoFisico(float dano)
    {
        if (defendendo == true)
        {
            bStatus.bHp -= (dano + bStatus.bDefense * 0.5f);
        }
        else
        {
            bStatus.bHp -= (dano + bStatus.bDefense);
        }
        textHP.text = (bStatus.bHp.ToString() + " / " + bStatus.bHpMax.ToString());
        sliderHP.value = bStatus.bHp;
        sliderHP.maxValue = bStatus.bHpMax;
    }
    public void TomarDanoMagico(float dano)
    {
        bStatus.bHp -= dano + bStatus.bMagicDefense;
        textHP.text = (bStatus.bHp.ToString() + " / " + bStatus.bHpMax.ToString());
    }
    public void PerderMana(float mana)
    {
        bStatus.bMp -= mana;
        sliderMP.value = bStatus.bMp;
        sliderMP.maxValue = bStatus.bMpMax;
    }
    public void LimitBarret(int ultimate)
    {
        bStatus.bLimit += ultimate;
        sliderLimit.value = bStatus.bLimit;
        sliderLimit.maxValue = bStatus.bLimitMax;
    }
    public void BarretDanoFisico()
    {
        ani.SetTrigger("ATTACK");
        if (botaoMob[0].gameObject.name == "MobP1B")
        {
            inimigo[0].MobVida(bStatus.bDano);
            turno = 0;
            return;
        }
        if (botaoMob[1].gameObject.name == "MobP2B")
        {
            inimigo[1].MobVida(bStatus.bDano);
            turno = 0;
            return;
        }
        if (botaoMob[2].gameObject.name == "MobP3B")
        {
            inimigo[2].MobVida(bStatus.bDano);
            turno = 0;
            return;
        }
        if (botaoMob[3].gameObject.name == "MobP4B")
        {
            inimigo[3].MobVida(bStatus.bDano);
            turno = 0;
            return;
        }
        if (botaoMob[4].gameObject.name == "MobP5B")
        {
            inimigo[4].MobVida(bStatus.bDano);
            turno = 0;
            return;
        }
    }
    public void AcaoDeAtaque()
    {
        bStatus.bDano = (int)bStatus.bAttack + ((bStatus.bAttack + bStatus.bLevel / 32) * (bStatus.bAttack * bStatus.bLevel / 32));
        Debug.Log(bStatus.bDano);
        painelDeInimigosBFisico.SetActive(true);
        inimigo = FindObjectsOfType<Mobs>();
        AtualizarHUD();
    }
    public void AtualizarHUD()
    {
        if (inimigo.Length < 5)
        {
            botaoMob[4].SetActive(false);
        }
        if (inimigo.Length < 4)
        {
            botaoMob[3].SetActive(false);
        }
        if (inimigo.Length < 3)
        {
            botaoMob[2].SetActive(false);
        }
        if (inimigo.Length < 2)
        {
            botaoMob[1].SetActive(false);
        }
        if (inimigo.Length < 1)
        {
            botaoMob[0].SetActive(false);
        }
    }
    public void Defendendo()
    {
        turno = 0;
        defendendo = true;
    }
}
