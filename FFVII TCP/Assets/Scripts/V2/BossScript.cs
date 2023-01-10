using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    GameManager gm;

    float level;
    public float hp, hpMax;
    float mp, mpMax;
    float attack;
    float def;
    int EXP;

    public bool MobBoss;

    float dano;
    float danoMagico;

    Vector3 posicaoAtual;
    public float turno;
    public int alvo = -1;
    public float tempoDeAtaque;

    CloudV2 player1;
    CloudStatus cloudStatus;
    BarretV2 player2;
    BarretStatus barretStatus;

    public bool atacando;

    public GameObject[] outrosMobs;
    public Mobs[] outrosMobsScript;

    public float fIce, fBolt;
}
