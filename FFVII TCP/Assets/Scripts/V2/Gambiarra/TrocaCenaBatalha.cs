using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrocaCenaBatalha : MonoBehaviour
{
    [SerializeField] GameObject[] cenasDeBatalha;

    Movimentação move;
    private void Start()
    {
        move = FindObjectOfType<Movimentação>();
    }
    void Update()
    {
        cenasDeBatalha[0].SetActive(false);
        cenasDeBatalha[1].SetActive(false);
        cenasDeBatalha[2].SetActive(false);
        cenasDeBatalha[3].SetActive(false);
        cenasDeBatalha[4].SetActive(false);

        if (move.batalhaIntro == true)
        {
            cenasDeBatalha[0].SetActive(true);
        }
        if (move.cena2Batalha == true)
        {
            cenasDeBatalha[1].SetActive(true);
        }
        if (move.cena3Batalha == true)
        {
            cenasDeBatalha[2].SetActive(true);
        }
        if (move.cena4Batalha == true)
        {
            cenasDeBatalha[3].SetActive(true);
        }
        if (move.cena5Batalha == true)
        {
            cenasDeBatalha[4].SetActive(true);
        }
    }
}
