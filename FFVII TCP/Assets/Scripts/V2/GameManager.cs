using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instancia = null;
    
    public GameObject[] mobsVivos;
    public bool vitoria = false;

    // carregar cena aberta
    float timer;
    // Players
    CloudV2 player1;
    BarretV2 player2;

    EncontroV2 spawn;
    public Movimentação move;

    // verificar cena
    public bool cenaAtual;
    public bool spawnou;

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
        move = FindObjectOfType<Movimentação>();
        spawn = FindObjectOfType<EncontroV2>();
        player1 = FindObjectOfType<CloudV2>();
        player2 = FindObjectOfType<BarretV2>();
    }
    public void Update()
    {
        cenaAtual = SceneManager.GetSceneByName("Batalha").isLoaded;
        if (cenaAtual == true)
        {
            if (spawnou == false)
            {
                ComecarLuta();
                spawnou = true;
            }
        }
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }
    /*public void SalvaPosicao()
    {
        PlayerPrefs.SetFloat("PositionX", move.transform.position.x);
        PlayerPrefs.SetFloat("PositionY", move.transform.position.y);
        PlayerPrefs.SetFloat("PositionZ", move.transform.position.z);
        PlayerPrefs.SetFloat("RotationX", move.transform.eulerAngles.x);
        PlayerPrefs.SetFloat("RotationY", move.transform.eulerAngles.y);
        PlayerPrefs.SetFloat("RotationZ", move.transform.eulerAngles.z);
    }
    public void CarregaPosicao()
    {
        PlayerPrefs.GetFloat("PositionX");
        PlayerPrefs.GetFloat("PositionY");
        PlayerPrefs.GetFloat("PositionZ");
        PlayerPrefs.GetFloat("RotationX");
        PlayerPrefs.GetFloat("RotationY");
        PlayerPrefs.GetFloat("RotationZ");
    }*/
    public void VerificacaoDeVitoria()
    {
        mobsVivos = GameObject.FindGameObjectsWithTag("Inimigos");
        if (mobsVivos.Length == 0)
        {
            vitoria = true;
        }
        if (vitoria == true)
        {
            SceneManager.LoadScene("MundoAberto");
            move = FindObjectOfType<Movimentação>();
            spawnou = false;
            timer = 0.5f;
            vitoria = false;
        }
    }
    public void ComecarLuta()
    {
        spawn.Rec1Map1 = true;
        spawn.SpawnPorMapa();
    }
}
