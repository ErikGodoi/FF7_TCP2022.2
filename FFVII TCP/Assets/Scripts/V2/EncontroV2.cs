using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncontroV2 : MonoBehaviour
{
    // Sector 1 map1 (Primeira Luta (Trem))             FEITO.
    public bool E2MPSec1Map1; 
    // Sector 1 map2 (Plataforma)                       FEITO.
    public bool E2MPSec1Map2, E1GHSec1Map2, E1MP1GHSec1Map2;
    // Sector 1 map3 (Fora do Reator)                   FEITO.
    public bool E2MP1MDSec1Map3, E2MDSec1Map3, E2MPSec1Map3;

    // Reactor 1 map1 (Entrada)
    bool E2GruntMap4, E3GruntMap4, E2Ray1GruntMap4, E3RayMap4;
    // Reactor 1 map4 (Cano Inferior)
    bool E1SweeperMap5, E1Sweeper2GruntMap5;
    // Reactor 1 map5 (Boss Fight)
    bool BossFight;

    public Vector3[] spawnPosition;
    public GameObject MobPrefab1, MobPrefab2, MobPrefab3, MobPrefab4, MobPrefab5;
    public GameObject Bossprefab;

    // Spawns por mapa
    public bool Sec1Map1, Sec1Map2, Sec1Map3;
    public bool Rec1Map1, Rec1Map2, Rec1Map3, Rec1Map4, Rec1Map5;

    // rolagem de valor para qual mob ser? spawnado
    public int Aleatoriedade;

    public CloudV2 player;
    private void Update()
    {
        player = FindObjectOfType<CloudV2>();
    }
    public void VariaveisDeSpawnFalsas()
    {
        E2MPSec1Map1 = false;
        E2MPSec1Map2 = false;
        E1GHSec1Map2 = false;
        E1MP1GHSec1Map2 = false;
        E2MP1MDSec1Map3 = false;
        E2MDSec1Map3 = false;
        E2MPSec1Map3 = false;
        E2GruntMap4 = false;
        E3GruntMap4 = false;
        E2Ray1GruntMap4 = false;
        E3RayMap4 = false;
        E1SweeperMap5 = false;
        E1Sweeper2GruntMap5 = false;
        BossFight = false;
        /*Sec1Map1 = false;
        Sec1Map2 = false;
        Sec1Map3 = false;
        Rec1Map1 = false;
        Rec1Map2 = false;
        Rec1Map3 = false;
        Rec1Map4 = false;
        Rec1Map5 = false;*/
    }
    public void SpawnPorMapa()
    {
        if (Sec1Map1 == true)
        {
            E2MPSec1Map1 = true;
            SpawnarInimigosSec1();
            VariaveisDeSpawnFalsas();
        }
        if (Sec1Map2 == true)
        {
            Aleatoriedade = Random.Range(1, 4);
            if (Aleatoriedade == 1) E2MPSec1Map1 = true;
            if (Aleatoriedade == 2) E1GHSec1Map2 = true;
            if (Aleatoriedade == 3) E1MP1GHSec1Map2 = true;
            SpawnarInimigosSec1();
            VariaveisDeSpawnFalsas();
        }
        if (Sec1Map3 == true)
        {
            Aleatoriedade = Random.Range(1, 4);
            if (Aleatoriedade == 1) E2MP1MDSec1Map3 = true;
            if (Aleatoriedade == 2) E2MDSec1Map3 = true;
            if (Aleatoriedade == 3) E2MPSec1Map3 = true;
            SpawnarInimigosSec1();
            VariaveisDeSpawnFalsas();
        }
        if (Rec1Map1 == true)
        {
            Aleatoriedade = Random.Range(1, 5);
            if (Aleatoriedade == 1) E2GruntMap4 = true;
            if (Aleatoriedade == 2) E3GruntMap4 = true;
            if (Aleatoriedade == 3) E2Ray1GruntMap4 = true;
            if (Aleatoriedade == 4) E3RayMap4 = true;
            SpawnarInimigosRec1();
            VariaveisDeSpawnFalsas();
        }
        if (Rec1Map4 == true)
        {
            Aleatoriedade = Random.Range(1, 3);
            if (Aleatoriedade == 1) E1SweeperMap5 = true;
            if (Aleatoriedade == 2) E1Sweeper2GruntMap5 = true;
            SpawnarInimigosRec1();
            VariaveisDeSpawnFalsas();
        }
        if (Rec1Map5 == true)
        {
            BossFight = true;
            Boss();
            VariaveisDeSpawnFalsas();
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
        if (E2GruntMap4)
        {
            StartCoroutine(SpawnCena4encontro1());
        }
        if (E3GruntMap4)
        {
            StartCoroutine(SpawnCena4encontro2());
        }
        if (E2Ray1GruntMap4)
        {
            StartCoroutine(SpawnCena4encontro3());
        }
        if (E3RayMap4)
        {
            StartCoroutine(SpawnCena4encontro4());
        }
        // Rec 1 map4
        if (E1SweeperMap5)
        {
            StartCoroutine(SpawnCena5encontro1());
        }
        if (E1Sweeper2GruntMap5)
        {
            StartCoroutine(SpawnCena5encontro2());
        }
    }
    IEnumerator SpawnBoss()
    {
        yield return new WaitForSeconds(0.01f);
        Instantiate(Bossprefab, spawnPosition[5], Bossprefab.transform.rotation);
        Bossprefab.GetComponent<Mobs>().MobBoss = true;
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
