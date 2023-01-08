using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarregadorDeCena : MonoBehaviour
{
    //[SerializeField] private GameObject player;
    //[SerializeField] private Vector3[] playerPosicao;

    public bool entrouCena2, entrouCena3, entrouCena4, entrouCena5, entrouCena6;
    public bool resetouPosicao;
    public static CarregadorDeCena instancia = null;
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
    /*IEnumerator MudaPosicao()
    {
        yield return new WaitForSeconds(0.1f);
        player.transform.position = playerPosicao[0];
    }
    public void PlayerPosition()
    {
        if (entrouCena2 == true && resetouPosicao == false)
        {
            //StartCoroutine(MudaPosicao());
            //player.transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
            resetouPosicao = true;
            entrouCena2 = false;
        }
        if (entrouCena3 == true && resetouPosicao == false)
        {
            player.transform.position = playerPosicao[1];
            resetouPosicao = true;
            entrouCena3 = false;
        }
        if (entrouCena4 == true && resetouPosicao == false)
        {
            player.transform.position = playerPosicao[2];
            resetouPosicao = true;
            entrouCena4 = false;
        }
        if (entrouCena5 == true && resetouPosicao == false)
        {
            player.transform.position = playerPosicao[3];
            resetouPosicao = true;
            entrouCena5 = false;
        }
        if (entrouCena6 == true && resetouPosicao == false)
        {
            player.transform.position = playerPosicao[4];
            resetouPosicao = true;
            entrouCena6 = false;
        }
    }*/
}
