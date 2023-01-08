using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncontroV2 : MonoBehaviour
{
    // GAMEMANAGER
    GameManager gm;
    // Sector 1 map1 (Primeira Luta (Trem))             FEITO.
    public bool E2MPSec1Map1; 
    // Sector 1 map2 (Plataforma)                       
    public bool E2MPSec1Map2, E1GHSec1Map2, E1MP1GHSec1Map2;
    // Sector 1 map3 (Fora do Reator)                   FEITO.
    public bool E2MP1MDSec1Map3, E2MDSec1Map3, E2MPSec1Map3;

    // Reactor 1 map1 (Entrada)
    bool E2GruntMap1, E3GruntMap1, E2Ray1GruntMap1, E3RayMap1;
    // Reactor 1 map4 (Cano Inferior)
    bool E1SweeperMap4, E1Sweeper2GruntMap4;
    // Reactor 1 map5 (Boss Fight)
    bool BossFight;

    public Vector3[] spawnPosition;
    public GameObject MobPrefab1, MobPrefab2, MobPrefab3, MobPrefab4, MobPrefab5;

    // Spawns por mapa
    public bool Sec1Map1, Sec1Map2, Sec1Map3;
    public bool Rec1Map1, Rec1Map2, Rec1Map3, Rec1Map4, Rec1Map5;

    // rolagem de valor para qual mob será spawnado
    int Aleatoriedade;

    public CloudV2 player;
    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }
    private void Update()
    {
        player = FindObjectOfType<CloudV2>();
    }
    public void SpawnPorMapa()
    {
        if (Sec1Map1 == true)
        {
            E2MPSec1Map1 = true;
            SpawnarInimigosSec1();
        }
        if (Sec1Map2 == true)
        {
            Aleatoriedade = Random.Range(1, 4);
            if (Aleatoriedade == 1) E2MPSec1Map1 = true;
            if (Aleatoriedade == 2) E1GHSec1Map2 = true;
            if (Aleatoriedade == 3) E1MP1GHSec1Map2 = true;
            SpawnarInimigosSec1();
        }
        if (Sec1Map3 == true)
        {
            Aleatoriedade = Random.Range(1, 4);
            if (Aleatoriedade == 1) E2MP1MDSec1Map3 = true;
            if (Aleatoriedade == 2) E2MDSec1Map3 = true;
            if (Aleatoriedade == 3) E2MPSec1Map3 = true;
            SpawnarInimigosSec1();
        }
        if (Rec1Map1 == true)
        {
            Aleatoriedade = Random.Range(1, 5);
            if (Aleatoriedade == 1) E2GruntMap1 = true;
            if (Aleatoriedade == 2) E3GruntMap1 = true;
            if (Aleatoriedade == 3) E2Ray1GruntMap1 = true;
            if (Aleatoriedade == 4) E3RayMap1 = true;
            SpawnarInimigosRec1();
        }
        if (Rec1Map4 == true)
        {
            Aleatoriedade = Random.Range(1, 3);
            if (Aleatoriedade == 1) E1SweeperMap4 = true;
            if (Aleatoriedade == 2) E1Sweeper2GruntMap4 = true;
            SpawnarInimigosRec1();
        }
        if (Rec1Map5 == true)
        {
            BossFight = true;
            Boss();
        }
    }
    IEnumerator SpawnCena1()
    {
        yield return new WaitForSeconds(0.01f);
        Instantiate(MobPrefab1, spawnPosition[0], MobPrefab1.transform.rotation);
        MobPrefab1.GetComponent<Mobs>().TudoFalso();
        MobPrefab1.GetComponent<Mobs>().MobMP = true;
        Instantiate(MobPrefab2, spawnPosition[1], MobPrefab2.transform.rotation);
        MobPrefab2.GetComponent<Mobs>().TudoFalso();
        MobPrefab2.GetComponent<Mobs>().MobMP = true;
        player.spawnou = true;
    }
    IEnumerator SpawnCena2encontro2()
    {
        yield return new WaitForSeconds(0.01f);
        Instantiate(MobPrefab1, spawnPosition[6], MobPrefab1.transform.rotation);
        MobPrefab1.GetComponent<Mobs>().TudoFalso();
        MobPrefab1.GetComponent<Mobs>().MobGH = true;
    }
    IEnumerator SpawnCena2encontro3()
    {
        yield return new WaitForSeconds(0.01f);
        Instantiate(MobPrefab1, spawnPosition[0], MobPrefab1.transform.rotation);
        MobPrefab1.GetComponent<Mobs>().TudoFalso();
        MobPrefab1.GetComponent<Mobs>().MobMP = true;
        Instantiate(MobPrefab2, spawnPosition[1], MobPrefab2.transform.rotation);
        MobPrefab2.GetComponent<Mobs>().TudoFalso();
        MobPrefab2.GetComponent<Mobs>().MobGH = true;
    }
    IEnumerator SpawnCena3encontro1()
    {
        yield return new WaitForSeconds(0.01f);
        Instantiate(MobPrefab1, spawnPosition[0], MobPrefab1.transform.rotation);
        MobPrefab1.GetComponent<Mobs>().TudoFalso();
        MobPrefab1.GetComponent<Mobs>().MobMP = true;
        Instantiate(MobPrefab2, spawnPosition[1], MobPrefab2.transform.rotation);
        MobPrefab2.GetComponent<Mobs>().TudoFalso();
        MobPrefab2.GetComponent<Mobs>().MobMP = true;
        Instantiate(MobPrefab3, spawnPosition[2], MobPrefab3.transform.rotation);
        MobPrefab3.GetComponent<Mobs>().TudoFalso();
        MobPrefab3.GetComponent<Mobs>().MobMD = true;
    }
    IEnumerator SpawnCena3encontro2()
    {
        yield return new WaitForSeconds(0.01f);
        Instantiate(MobPrefab1, spawnPosition[0], MobPrefab1.transform.rotation);
        MobPrefab1.GetComponent<Mobs>().TudoFalso();
        MobPrefab1.GetComponent<Mobs>().MobMD = true;
        Instantiate(MobPrefab2, spawnPosition[1], MobPrefab2.transform.rotation);
        MobPrefab2.GetComponent<Mobs>().TudoFalso();
        MobPrefab2.GetComponent<Mobs>().MobMD = true;
    }
    IEnumerator SpawnCena3encontro3()
    {
        yield return new WaitForSeconds(0.01f);
        Instantiate(MobPrefab1, spawnPosition[0], MobPrefab1.transform.rotation);
        MobPrefab1.GetComponent<Mobs>().TudoFalso();
        MobPrefab1.GetComponent<Mobs>().MobMP = true;
        Instantiate(MobPrefab2, spawnPosition[1], MobPrefab2.transform.rotation);
        MobPrefab2.GetComponent<Mobs>().TudoFalso();
        MobPrefab2.GetComponent<Mobs>().MobMP = true;
    }
    public void SpawnarInimigosSec1()
    {
        // Sec 1 map 1
        if (E2MPSec1Map1)
        {
            StartCoroutine(SpawnCena1());
        }
        // Sec 1 map 2
        if (E1GHSec1Map2)
        {
            StartCoroutine(SpawnCena2encontro2());
        }
        if (E1MP1GHSec1Map2)
        {
            StartCoroutine(SpawnCena2encontro3());
        }
        // Sec 1 map 3
        if (E2MP1MDSec1Map3)
        {
            StartCoroutine(SpawnCena3encontro1());
        }
        if (E2MDSec1Map3)
        {
            StartCoroutine(SpawnCena3encontro2());
        }
        if (E2MPSec1Map3)
        {
            StartCoroutine(SpawnCena3encontro3());
        }
    }
    IEnumerator SpawnCena4encontro1()
    {
        yield return new WaitForSeconds(0.01f);
        Instantiate(MobPrefab1, spawnPosition[0], MobPrefab1.transform.rotation);
        MobPrefab1.GetComponent<Mobs>().TudoFalso();
        MobPrefab1.GetComponent<Mobs>().MobGr = true;
        Instantiate(MobPrefab2, spawnPosition[1], MobPrefab2.transform.rotation);
        MobPrefab2.GetComponent<Mobs>().TudoFalso();
        MobPrefab2.GetComponent<Mobs>().MobGr = true;
    }
    IEnumerator SpawnCena4encontro2()
    {
        yield return new WaitForSeconds(0.01f);
        Instantiate(MobPrefab1, spawnPosition[0], MobPrefab1.transform.rotation);
        MobPrefab1.GetComponent<Mobs>().TudoFalso();
        MobPrefab1.GetComponent<Mobs>().MobGr = true;
        Instantiate(MobPrefab2, spawnPosition[1], MobPrefab2.transform.rotation);
        MobPrefab2.GetComponent<Mobs>().TudoFalso();
        MobPrefab2.GetComponent<Mobs>().MobGr = true;
        Instantiate(MobPrefab3, spawnPosition[2], MobPrefab3.transform.rotation);
        MobPrefab3.GetComponent<Mobs>().TudoFalso();
        MobPrefab3.GetComponent<Mobs>().MobGr = true;
    }
    IEnumerator SpawnCena4encontro3()
    {
        yield return new WaitForSeconds(0.01f);
        Instantiate(MobPrefab1, spawnPosition[0], MobPrefab1.transform.rotation);
        MobPrefab1.GetComponent<Mobs>().TudoFalso();
        MobPrefab1.GetComponent<Mobs>().MobRay = true;
        Instantiate(MobPrefab2, spawnPosition[1], MobPrefab1.transform.rotation);
        MobPrefab2.GetComponent<Mobs>().TudoFalso();
        MobPrefab2.GetComponent<Mobs>().MobRay = true;
        Instantiate(MobPrefab3, spawnPosition[2], MobPrefab3.transform.rotation);
        MobPrefab3.GetComponent<Mobs>().TudoFalso();
        MobPrefab3.GetComponent<Mobs>().MobGr = true;
    }
    IEnumerator SpawnCena4encontro4()
    {
        yield return new WaitForSeconds(0.01f);
        Instantiate(MobPrefab1, spawnPosition[0], MobPrefab1.transform.rotation);
        MobPrefab1.GetComponent<Mobs>().TudoFalso();
        MobPrefab1.GetComponent<Mobs>().MobRay = true;
        Instantiate(MobPrefab2, spawnPosition[1], MobPrefab2.transform.rotation);
        MobPrefab2.GetComponent<Mobs>().TudoFalso();
        MobPrefab2.GetComponent<Mobs>().MobRay = true;
        Instantiate(MobPrefab3, spawnPosition[2], MobPrefab3.transform.rotation);
        MobPrefab3.GetComponent<Mobs>().TudoFalso();
        MobPrefab3.GetComponent<Mobs>().MobRay = true;
    }
    IEnumerator SpawnCena5encontro1()
    {
        yield return new WaitForSeconds(0.01f);
        Instantiate(MobPrefab1, spawnPosition[0], MobPrefab1.transform.rotation);
        MobPrefab1.GetComponent<Mobs>().TudoFalso();
        MobPrefab1.GetComponent<Mobs>().MobSweep = true;
    }
    IEnumerator SpawnCena5encontro2()
    {
        yield return new WaitForSeconds(0.01f);
        Instantiate(MobPrefab1, spawnPosition[0], MobPrefab1.transform.rotation);
        MobPrefab1.GetComponent<Mobs>().TudoFalso();
        MobPrefab1.GetComponent<Mobs>().MobSweep = true;
        Instantiate(MobPrefab2, spawnPosition[1], MobPrefab2.transform.rotation);
        MobPrefab2.GetComponent<Mobs>().TudoFalso();
        MobPrefab2.GetComponent<Mobs>().MobGr = true;
        Instantiate(MobPrefab3, spawnPosition[2], MobPrefab3.transform.rotation);
        MobPrefab3.GetComponent<Mobs>().TudoFalso();
        MobPrefab3.GetComponent<Mobs>().MobGr = true;
    }
    public void SpawnarInimigosRec1()
    {
        // Rec 1 map1
        if (E2GruntMap1)
        {
            StartCoroutine(SpawnCena4encontro1());
        }
        if (E3GruntMap1)
        {
            StartCoroutine(SpawnCena4encontro2());
        }
        if (E2Ray1GruntMap1)
        {
            StartCoroutine(SpawnCena4encontro3());
        }
        if (E3RayMap1)
        {
            StartCoroutine(SpawnCena4encontro4());
        }
        // Rec 1 map4
        if (E1SweeperMap4)
        {
            StartCoroutine(SpawnCena5encontro1());
        }
        if (E1Sweeper2GruntMap4)
        {
            StartCoroutine(SpawnCena5encontro2());
        }
    }
    IEnumerator SpawnBoss()
    {
        yield return new WaitForSeconds(0.01f);
        Instantiate(MobPrefab1, spawnPosition[6], MobPrefab1.transform.rotation);
        MobPrefab1.GetComponent<Mobs>().TudoFalso();
        MobPrefab1.GetComponent<Mobs>().MobBoss = true;
    }
    public void Boss()
    {
        // Boss Fight
        if (BossFight)
        {
            StartCoroutine(SpawnBoss());
        }
    }
}
