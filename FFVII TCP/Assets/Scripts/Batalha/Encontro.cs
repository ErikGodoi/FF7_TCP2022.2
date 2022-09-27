using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Encontro : MonoBehaviour
{
    public Vector3[] umInimigo, doisInimigo, tresInimigo, quatroInimigo, cincoInimigo;
    public Vector3[] partyPosição;
    public GameObject mobPrefab;
    public GameObject partyPrefab;

    [Range (0,5)][SerializeField]int quantidadeDeInimigos;
    void Start()
    {
        if (quantidadeDeInimigos == 1)
        {
            Instantiate(mobPrefab, umInimigo[0], mobPrefab.gameObject.transform.rotation);
        }
        if (quantidadeDeInimigos == 2)
        {
            for (int i = 0; i <= 1; i++)
            {
                Instantiate(mobPrefab, doisInimigo[i], mobPrefab.gameObject.transform.rotation);
            }
        }
        if (quantidadeDeInimigos == 3)
        {
            for (int i = 0; i <= 2; i++)
            {
                Instantiate(mobPrefab, tresInimigo[i], mobPrefab.gameObject.transform.rotation);
            }
        }
        if (quantidadeDeInimigos == 4)
        {
            for (int i = 0; i <= 3; i++)
            {
                Instantiate(mobPrefab, quatroInimigo[i], mobPrefab.gameObject.transform.rotation);
            }
        }
        if (quantidadeDeInimigos == 5)
        {
            for (int i = 0; i <= 4; i++)
            {
                Instantiate(mobPrefab, cincoInimigo[i], mobPrefab.gameObject.transform.rotation);
            }
        }
        for (int i = 0; i <= 1; i++)
        {
            Instantiate(partyPrefab, partyPosição[i], partyPrefab.gameObject.transform.rotation);
        }
    }
    void Update()
    {
        
    }
}
