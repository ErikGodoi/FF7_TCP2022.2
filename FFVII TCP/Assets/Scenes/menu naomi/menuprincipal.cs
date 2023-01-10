using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class menuprincipal : MonoBehaviour
{
    public  string nomeDoLevelDejogo;
    public  GameObject painelMenuInicial;
    public  GameObject painelConfigurações;

    public void jogar()
    {
        SceneManager.LoadScene("jogo");
    }
    
    public void Abrirconfigurações()
    {
        painelMenuInicial.SetActive(false);
        painelConfigurações.SetActive(true);
    }

    public void Fecharconfigurações()
    {
        painelConfigurações.SetActive(false);
        painelMenuInicial.SetActive(true);
    }

    public void Sairjogo()
    {
        Debug.Log("sair do jogo");
        Application.Quit();
    }


}

