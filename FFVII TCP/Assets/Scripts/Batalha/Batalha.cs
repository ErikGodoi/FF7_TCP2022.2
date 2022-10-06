using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Batalha : MonoBehaviour
{
    public CloudStatus personagem1;

    // Ativar Painel para liberar ações
    public GameObject painelDeAcao;
    // Botoes do Painel de ação
    public Button attackButton;
    public Button magicButton;
    public Button itemButton;

    void Start()
    {
        personagem1 = FindObjectOfType<CloudStatus>();
    }
    private void Update()
    {
        AcaoDoJogador();
    }
    public void AcaoDoJogador()
    {
        if (personagem1.cloudPodeAgir == true)
        {
            painelDeAcao.SetActive(true);
        }
    }
    public void BotaoDeAttack()
    {
        
    }
    public void BotaoDeMagic()
    {

    }
    public void BotaoDeItem()
    {

    }
}
