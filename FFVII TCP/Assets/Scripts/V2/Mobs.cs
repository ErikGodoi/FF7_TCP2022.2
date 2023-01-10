using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mobs : MonoBehaviour
{
    GameManager gm;

    float level;
    public float hp, hpMax;
    float mp, mpMax;
    float attack;
    float def;
    int EXP;

    // Qual Mob vai ser Spawnado
    public bool MobMP, MobGH, MobMD, MobGr, MobRay, MobSweep;
    public bool MobBoss;

    // Dano Causado
    float dano;
    float danoMagico;

    // Turno
    Vector3 posicaoAtual;
    public float turno;
    public int alvo = -1;
    public float tempoDeAtaque;

    CloudV2 player1;
    CloudStatus cloudStatus;
    BarretV2 player2;
    BarretStatus barretStatus;
    public InimigosAnimacao animacaoInimigos;
    int AniRandom;

    public bool atacando;

    public GameObject[] outrosMobs;
    public Mobs[] outrosMobsScript;
    // Spawn
    EncontroV2 spawnando;

    // Fraqueza
    public float fIce, fBolt;

    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        outrosMobs = GameObject.FindGameObjectsWithTag("Inimigos");
        outrosMobsScript = FindObjectsOfType<Mobs>();
        posicaoAtual = transform.position;
        Spawn();
        player1 = FindObjectOfType<CloudV2>();
        cloudStatus = FindObjectOfType<CloudStatus>();
        player2 = FindObjectOfType<BarretV2>();
        barretStatus = FindObjectOfType<BarretStatus>();
    }
    private void Update()
    {
        if (turno < 100)
        {
            turno += Time.deltaTime * 9f;
        }
        if (turno >= 100)
        {
            alvo = Random.Range(0, 2);
            Debug.Log(alvo);
            MobAtaca();
        }
        if (tempoDeAtaque > 0)
        {
            tempoDeAtaque -= Time.deltaTime;
        }
        if (tempoDeAtaque <= 0)
        {
            transform.position = posicaoAtual;
            atacando = false;
        }
    }
    public void Spawn()
    {
        if (MobMP)
        {
            StatusMP();
        }
        if (MobGH)
        {
            StatusGuardHound();
        }
        if (MobMD)
        {
            StatusMonoDrive();
        }
        if (MobGr)
        {
            StatusGrunt();
        }
        if (MobRay)
        {
            StatusRay();
        }
        if (MobSweep)
        {
            StatusSweeper();
        }
        if (MobBoss)
        {
            BossEscorpiao();
        }
    }
    public void TudoFalso()
    {
        MobGH = false;
        MobGr = false;
        MobMD = false;
        MobMP = false;
        MobRay = false;
        MobSweep = false;
    }
    public void StatusMP()
    {
        level = 2;
        hpMax = 30;
        mpMax = 0;
        attack = 6;
        def = 4;
        EXP = 160;
        fIce = 1f;
        fBolt = 1f;
        hp = hpMax;
        mp = mpMax;
    }
    public void StatusGuardHound()
    {
        level = 3;
        hpMax = 42;
        mpMax = 0;
        attack = 8;
        def = 4;
        EXP = 200;
        fIce = 1f;
        fBolt = 1f;
        hp = hpMax;
        mp = mpMax;
    }
    public void StatusMonoDrive()
    {
        level = 2;
        hpMax = 28;
        mpMax = 28;
        attack = 3;
        def = 6;
        EXP = 180;
        fIce = 1f;
        fBolt = 1f;
        hp = hpMax;
        mp = mpMax;
    }
    public void StatusGrunt()
    {
        level = 7;
        hpMax = 40;
        mpMax = 0;
        attack = 12;
        def = 10;
        EXP = 220;
        fIce = 1f;
        fBolt = 1f;
        hp = hpMax;
        mp = mpMax;
    }
    public void StatusRay()
    {
        level = 4;
        hpMax = 18;
        mpMax = 0;
        attack = 10;
        def = 2;
        EXP = 120;
        fIce = 1f;
        fBolt = 2f;
        hp = hpMax;
        mp = mpMax;
    }
    public void StatusSweeper()
    {
        level = 8;
        hpMax = 140;
        mpMax = 0;
        attack = 18;
        def = 20;
        EXP = 170;
        fIce = 1f;
        fBolt = 2f;
        hp = hpMax;
        mp = mpMax;
    }
    public void BossEscorpiao()
    {
        level = 12;
        hpMax = 800;
        mpMax = 0;
        attack = 30;
        def = 40;
        EXP = 1000;
        fIce = 1f;
        fBolt = 2f;
        hp = hpMax;
        mp = mpMax;
    }
    public void MobVida(float vida)
    {
        hp -= (vida + def);
        if (gameObject.name.Contains("Boss") && hp <= 0)
        {
            SceneManager.LoadScene("FimDeJogo");
        }
        if (hp <= 0)
        {
            MobMorre();
            gm.VerificacaoDeVitoria();
            Destroy(gameObject);
        }
    }
    public void MobMorre()
    {
        if (MobMP == true)
        {
            cloudStatus.cEXP += EXP;
            barretStatus.bEXP += EXP;
        }
        if (MobGH == true)
        {
            cloudStatus.cEXP += EXP;
            barretStatus.bEXP += EXP;
        }
        if (MobGr == true)
        {
            cloudStatus.cEXP += EXP;
            barretStatus.bEXP += EXP;
        }
        if (MobMD == true)
        {
            cloudStatus.cEXP += EXP;
            barretStatus.bEXP += EXP;
        }
        if (MobRay == true)
        {
            cloudStatus.cEXP += EXP;
            barretStatus.bEXP += EXP;
        }
        if (MobSweep == true)
        {
            cloudStatus.cEXP += EXP;
            barretStatus.bEXP += EXP;
        }
        if (MobBoss == true)
        {
            cloudStatus.cEXP += EXP;
            barretStatus.bEXP += EXP;
        }
    }
    public void MobAtaca()
    {
        atacando = true;
        Debug.Log(AniRandom);
        if (alvo == 0)
        {
            if (gameObject.name.Contains("Boss"))
            {
                dano = attack + (((attack + level / 32) * (attack * level / 32))) / 3;
                AniRandom = Random.Range(1, 3);
                if (AniRandom == 1)
                {
                    animacaoInimigos.Animacao1();
                    AniRandom = 0;
                }
                if (AniRandom == 2)
                {
                    animacaoInimigos.Animacao2();
                    AniRandom = 0;
                }
                player1.TomarDanoFisico(dano);
                turno = 0;
                alvo = -1;
                transform.position = new Vector3(0f, 3.9f, 0f);
                tempoDeAtaque = 1f;
            }
            else
            {
                dano = attack + ((attack + level / 32) * (attack * level / 32));
                animacaoInimigos.Animacao1();
                player1.TomarDanoFisico(dano);
                turno = 0;
                alvo = -1;
                transform.position = new Vector3(0f, 3f, 0f);
                tempoDeAtaque = 1f;
            }
        }
        if (alvo == 1)
        {
            if (gameObject.name.Contains("Boss"))
            {
                dano = (attack + ((attack + level / 32) * (attack * level / 32))) / 3;
                AniRandom = Random.Range(1, 3);
                if (AniRandom == 1)
                {
                    animacaoInimigos.Animacao1();
                    AniRandom = 0;
                }
                if (AniRandom == 2)
                {
                    animacaoInimigos.Animacao2();
                    AniRandom = 0;
                }
                player2.TomarDanoFisico(dano);
                turno = 0;
                alvo = -1;
                transform.position = new Vector3(0f, 3.9f, 0f);
                tempoDeAtaque = 1f;
            }
            else
            {
                dano = attack + ((attack + level / 32) * (attack * level / 32));
                animacaoInimigos.Animacao1();
                player2.TomarDanoFisico(dano);
                turno = 0;
                alvo = -1;
                transform.position = new Vector3(0f, 3f, 0f);
                tempoDeAtaque = 1f;
            }
        }
    }
    public void MobAtacaMagia()
    {
        danoMagico = 6 * (attack + level);
        if (alvo == 0)
        {
            if (gameObject.name.Contains("Boss"))
            {
                AniRandom = Random.Range(1, 3);
                if (AniRandom == 1)
                {
                    animacaoInimigos.Animacao1();
                    AniRandom = 0;
                }
                if (AniRandom == 2)
                {
                    animacaoInimigos.Animacao2();
                    AniRandom = 0;
                }
                player1.TomarDanoFisico(dano);
                turno = 0;
                alvo = -1;
                transform.position = new Vector3(0f, 3.9f, 0f);
                tempoDeAtaque = 1f;
            }
            else
            {
                animacaoInimigos.Animacao1();
                player1.TomarDanoFisico(dano);
                turno = 0;
                alvo = -1;
                transform.position = new Vector3(0f, 3f, 0f);
                tempoDeAtaque = 1f;
            }
        }
        if (alvo == 1)
        {
            if (gameObject.name.Contains("Boss"))
            {
                AniRandom = Random.Range(1, 3);
                if (AniRandom == 1)
                {
                    animacaoInimigos.Animacao1();
                    AniRandom = 0;
                }
                if (AniRandom == 2)
                {
                    animacaoInimigos.Animacao2();
                    AniRandom = 0;
                }
                player2.TomarDanoFisico(dano);
                turno = 0;
                alvo = -1;
                transform.position = new Vector3(0f, 3.9f, 0f);
                tempoDeAtaque = 1f;
            }
            else
            {
                animacaoInimigos.Animacao1();
                player2.TomarDanoFisico(dano);
                turno = 0;
                alvo = -1;
                transform.position = new Vector3(0f, 3f, 0f);
                tempoDeAtaque = 1f;
            }
        }
    }
}
