using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class menuprincipal : MonoBehaviour
{
    public  string nomeDoLevelDejogo;
    public  GameObject painelMenuInicial;
    public  GameObject painelConfigura��es;

    public void jogar()
    {
        SceneManager.LoadScene("jogo");
    }
    
    public void Abrirconfigura��es()
    {
        painelMenuInicial.SetActive(false);
        painelConfigura��es.SetActive(true);
    }

    public void Fecharconfigura��es()
    {
        painelConfigura��es.SetActive(false);
        painelMenuInicial.SetActive(true);
    }

    public void Sairjogo()
    {
        Debug.Log("sair do jogo");
        Application.Quit();
    }


}

