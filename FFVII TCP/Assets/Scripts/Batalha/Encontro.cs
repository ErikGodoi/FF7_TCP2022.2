using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Encontro : MonoBehaviour
{
    public Vector3[] umInimigo, doisInimigo, tresInimigo, quatroInimigo, cincoInimigo;
    public Vector3 partyPosição1,partyPosição2;
    public GameObject mobPrefab;
    public GameObject cloudPrefab;
    public GameObject barretPrefab;

    [Range (0,5)][SerializeField]int quantidadeDeInimigos, quantidadeDePlayers;
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
        if (quantidadeDePlayers == 1)
        {
            for (int i = 0; i <= 0; i++)
            {
                Instantiate(cloudPrefab, partyPosição1, cloudPrefab.gameObject.transform.rotation);
            }
        }
        if (quantidadeDePlayers == 2)
        {
            Instantiate(cloudPrefab, partyPosição1, cloudPrefab.gameObject.transform.rotation);
            Instantiate(barretPrefab, partyPosição2, barretPrefab.gameObject.transform.rotation);
        }
    }
}
