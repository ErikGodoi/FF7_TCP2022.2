using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mobs : MonoBehaviour
{
    // GAME MANAGER
    GameManager gm;

    float level;
    public float hp, hpMax;
    float mp, mpMax;
    float attack;
    float def;
    float EXP;

    // Qual Mob vai ser Spawnado
    public bool MobMP, MobGH, MobMD, MobGr, MobRay, MobSweep;
    public bool MobBoss;

    // Boss
    bool puto = false;

    // Dano Causado
    float dano;
    float danoMagico;

    // Turno
    Vector3 posicaoAtual;
    public float turno;
    public int alvo = -1;
    public float tempoDeAtaque;

    CloudV2 player1;
    BarretV2 player2;

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
        hp = hpMax;
        mp = mpMax;
        player1 = FindObjectOfType<CloudV2>();
        player2 = FindObjectOfType<BarretV2>();
        
    }
    private void Update()
    {
        if (turno < 100)
        {
            turno += Time.deltaTime * 4.5f;
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
        MobBoss = false;
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
        EXP = 16;
        fIce = 1f;
        fBolt = 1f;
    }
    public void StatusGuardHound()
    {
        level = 3;
        hpMax = 42;
        mpMax = 0;
        attack = 8;
        def = 4;
        EXP = 20;
        fIce = 1f;
        fBolt = 1f;
    }
    public void StatusMonoDrive()
    {
        level = 2;
        hpMax = 28;
        mpMax = 28;
        attack = 3;
        def = 6;
        EXP = 18;
        fIce = 1f;
        fBolt = 1f;
    }
    public void StatusGrunt()
    {
        level = 7;
        hpMax = 40;
        mpMax = 0;
        attack = 12;
        def = 10;
        EXP = 22;
        fIce = 1f;
        fBolt = 1f;
    }
    public void StatusRay()
    {
        level = 4;
        hpMax = 18;
        mpMax = 0;
        attack = 10;
        def = 2;
        EXP = 12;
        fIce = 1f;
        fBolt = 2f;
    }
    public void StatusSweeper()
    {
        level = 8;
        hpMax = 140;
        mpMax = 0;
        attack = 18;
        def = 20;
        EXP = 17;
        fIce = 1f;
        fBolt = 2f;
    }
    public void BossEscorpiao()
    {
        level = 12;
        hpMax = 800;
        mpMax = 0;
        attack = 30;
        def = 40;
        EXP = 100;
        fIce = 1f;
        fBolt = 2f;
        if (puto)
        {
            def = 255;
        }
    }
    public void MobVida(float vida)
    {
        hp -= (vida + def);
        if (hp <= 0)
        {
            gm.VerificacaoDeVitoria();
            Destroy(gameObject);
        }
    }
    public void MobAtaca()
    {
        atacando = true;
        dano = attack + ((attack + level / 32) * (attack * level / 32));
        if (alvo == 0)
        {
            player1.TomarDanoFisico(dano);
            turno = 0;
            alvo = -1;
            transform.position = new Vector3(0f, 1f, 0f);
            tempoDeAtaque = 0.6f;
        }
        if (alvo == 1)
        {
            player2.TomarDanoFisico(dano);
            turno = 0;
            alvo = -1;
            transform.position = new Vector3(0f, 1f, 0f);
            tempoDeAtaque = 0.6f;
        }
    }
    public void MobAtacaMagia()
    {
        danoMagico = 6 * (attack + level);
        if (alvo == 0)
        {
            player1.TomarDanoMagico(danoMagico);
            turno = 0;
            alvo = -1;
            transform.position = new Vector3(0f, 1f, 0f);
            tempoDeAtaque = 0.6f;
        }
        if (alvo == 1)
        {
            player2.TomarDanoMagico(danoMagico);
            turno = 0;
            alvo = -1;
            transform.position = new Vector3(0f, 1f, 0f);
            tempoDeAtaque = 0.6f;
        }
    }
}
