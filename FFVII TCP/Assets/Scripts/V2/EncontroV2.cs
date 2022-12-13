using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncontroV2 : MonoBehaviour
{
    // GAMEMANAGER
    GameManager gm;
    // Sector 1 map1 (Primeira Luta (Trem))
    public bool E2MPSec1Map1; 
    // Sector 1 map2 (Plataforma)
    bool E2MPSec1Map2, E1GHSec1Map2, E1MP1GHSec1Map2;
    // Sector 1 map3 (Fora do Reator)
    bool E2MP1MDSec1Map3, E2MDSec1Map3, E2MPSec1Map3;

    // Reactor 1 map1 (Entrada depois de derrotar o escorpião)
    bool E2GruntMap1, E3GruntMap1, E2Ray1GruntMap1, E3RayMap1;
    // Reactor 1 map2 (Escada Principal)
    bool E2MD1RayMap2, E2RayMap2, E2GruntMap2, E2Ray1GruntMap2, E3Raymap2, E3Gruntmap2;
    // Reactor 1 map3 (Cano Superior)
    bool E2Grunt2MDMap3, E2Grunt3MDMap3, E3GruntMap3;
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
    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }
    public void SpawnPorMapa()
    {
        if (Sec1Map1 == true)
        {
            E2MPSec1Map1 = true;
            SpawnarInimigosSec1();
            gm.VerificacaoDeVitoria();
        }
        if (Sec1Map2 == true)
        {
            Aleatoriedade = Random.Range(1, 4);
            if (Aleatoriedade == 1) E2MPSec1Map2 = true;
            if (Aleatoriedade == 2) E1GHSec1Map2 = true;
            if (Aleatoriedade == 3) E1MP1GHSec1Map2 = true;
            SpawnarInimigosSec1();
            gm.VerificacaoDeVitoria();
        }
        if (Sec1Map3 == true)
        {
            Aleatoriedade = Random.Range(1, 4);
            if (Aleatoriedade == 1) E2MP1MDSec1Map3 = true;
            if (Aleatoriedade == 2) E2MDSec1Map3 = true;
            if (Aleatoriedade == 3) E2MPSec1Map3 = true;
            SpawnarInimigosSec1();
            gm.VerificacaoDeVitoria();
        }
        if (Rec1Map1 == true)
        {
            Aleatoriedade = Random.Range(1, 5);
            if (Aleatoriedade == 1) E2GruntMap1 = true;
            if (Aleatoriedade == 2) E3GruntMap1 = true;
            if (Aleatoriedade == 3) E2Ray1GruntMap1 = true;
            if (Aleatoriedade == 4) E3RayMap1 = true;
            SpawnarInimigosRec1();
            gm.VerificacaoDeVitoria();
        }
        if (Rec1Map2 == true)
        {
            Aleatoriedade = Random.Range(1, 7);
            if (Aleatoriedade == 1) E2MD1RayMap2 = true;
            if (Aleatoriedade == 2) E2RayMap2 = true;
            if (Aleatoriedade == 3) E2GruntMap2 = true;
            if (Aleatoriedade == 4) E2Ray1GruntMap2 = true;
            if (Aleatoriedade == 5) E3Raymap2 = true;
            if (Aleatoriedade == 6) E3Gruntmap2 = true;
            SpawnarInimigosRec1();
            gm.VerificacaoDeVitoria();
        }
        if (Rec1Map3 == true)
        {
            Aleatoriedade = Random.Range(1, 4);
            if (Aleatoriedade == 1) E2Grunt2MDMap3 = true;
            if (Aleatoriedade == 2) E2Grunt3MDMap3 = true;
            if (Aleatoriedade == 3) E3GruntMap3 = true;
            SpawnarInimigosRec1();
            gm.VerificacaoDeVitoria();
        }
        if (Rec1Map4 == true)
        {
            Aleatoriedade = Random.Range(1, 3);
            if (Aleatoriedade == 1) E1SweeperMap4 = true;
            if (Aleatoriedade == 2) E1Sweeper2GruntMap4 = true;
            SpawnarInimigosRec1();
            gm.VerificacaoDeVitoria();
        }
        if (Rec1Map5 == true)
        {
            BossFight = true;
            Boss();
            gm.VerificacaoDeVitoria();
        }
    }
    public void SpawnarInimigosSec1()
    {
        //Instantiate(MobPrefab, spawnPosition[contDePosicao], MobPrefab.transform.rotation);
        // Sec1 map1
        if (E2MPSec1Map1)
        {
            Instantiate(MobPrefab1, spawnPosition[0], MobPrefab2.transform.rotation);
            MobPrefab1.GetComponent<Mobs>().TudoFalso();
            MobPrefab1.GetComponent<Mobs>().MobMP = true;
            Instantiate(MobPrefab2, spawnPosition[1], MobPrefab2.transform.rotation);
            MobPrefab2.GetComponent<Mobs>().TudoFalso();
            MobPrefab2.GetComponent<Mobs>().MobMP = true;
        }
        // Sec 1 map2
        if (E2MPSec1Map2)
        {
            Instantiate(MobPrefab1, spawnPosition[0], MobPrefab1.transform.rotation);
            MobPrefab1.GetComponent<Mobs>().TudoFalso();
            MobPrefab1.GetComponent<Mobs>().MobMP = true;
            Instantiate(MobPrefab2, spawnPosition[1], MobPrefab2.transform.rotation);
            MobPrefab2.GetComponent<Mobs>().TudoFalso();
            MobPrefab2.GetComponent<Mobs>().MobMP = true;
        }
        if (E1GHSec1Map2)
        {
            Instantiate(MobPrefab1, spawnPosition[6], MobPrefab1.transform.rotation);
            MobPrefab1.GetComponent<Mobs>().TudoFalso();
            MobPrefab1.GetComponent<Mobs>().MobGH = true;
        }
        if (E1MP1GHSec1Map2)
        {
            Instantiate(MobPrefab1, spawnPosition[0], MobPrefab1.transform.rotation);
            MobPrefab1.GetComponent<Mobs>().TudoFalso();
            MobPrefab1.GetComponent<Mobs>().MobMP = true;
            Instantiate(MobPrefab2, spawnPosition[1], MobPrefab2.transform.rotation);
            MobPrefab2.GetComponent<Mobs>().TudoFalso();
            MobPrefab2.GetComponent<Mobs>().MobGH = true;
        }
        // Sec 1 map3
        if (E2MP1MDSec1Map3)
        {
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
        if (E2MDSec1Map3)
        {
            Instantiate(MobPrefab1, spawnPosition[0], MobPrefab1.transform.rotation);
            MobPrefab1.GetComponent<Mobs>().TudoFalso();
            MobPrefab1.GetComponent<Mobs>().MobMD = true;
            Instantiate(MobPrefab2, spawnPosition[1], MobPrefab2.transform.rotation);
            MobPrefab2.GetComponent<Mobs>().TudoFalso();
            MobPrefab2.GetComponent<Mobs>().MobMD = true;
        }
        if (E2MPSec1Map3)
        {
            Instantiate(MobPrefab1, spawnPosition[0], MobPrefab1.transform.rotation);
            MobPrefab1.GetComponent<Mobs>().TudoFalso();
            MobPrefab1.GetComponent<Mobs>().MobMP = true;
            Instantiate(MobPrefab2, spawnPosition[1], MobPrefab2.transform.rotation);
            MobPrefab2.GetComponent<Mobs>().TudoFalso();
            MobPrefab2.GetComponent<Mobs>().MobMP = true;
        }
    }
    public void SpawnarInimigosRec1()
    {
        // Rec 1 map1
        if (E2GruntMap1)
        {
            Instantiate(MobPrefab1, spawnPosition[0], MobPrefab1.transform.rotation);
            MobPrefab1.GetComponent<Mobs>().TudoFalso();
            MobPrefab1.GetComponent<Mobs>().MobGr = true;
            Instantiate(MobPrefab2, spawnPosition[1], MobPrefab2.transform.rotation);
            MobPrefab2.GetComponent<Mobs>().TudoFalso();
            MobPrefab2.GetComponent<Mobs>().MobGr = true;
        }
        if (E3GruntMap1)
        {
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
        if (E2Ray1GruntMap1)
        {
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
        if (E3RayMap1)
        {
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
        // Rec 1 map2
        if (E2MD1RayMap2)
        {
            Instantiate(MobPrefab1, spawnPosition[0], MobPrefab1.transform.rotation);
            MobPrefab1.GetComponent<Mobs>().TudoFalso();
            MobPrefab1.GetComponent<Mobs>().MobMD = true;
            Instantiate(MobPrefab2, spawnPosition[1], MobPrefab2.transform.rotation);
            MobPrefab2.GetComponent<Mobs>().TudoFalso();
            MobPrefab2.GetComponent<Mobs>().MobMD = true;
            Instantiate(MobPrefab2, spawnPosition[2], MobPrefab2.transform.rotation);
            MobPrefab3.GetComponent<Mobs>().TudoFalso();
            MobPrefab3.GetComponent<Mobs>().MobRay = true;
        }
        if (E2RayMap2)
        {
            Instantiate(MobPrefab1, spawnPosition[0], MobPrefab1.transform.rotation);
            MobPrefab1.GetComponent<Mobs>().TudoFalso();
            MobPrefab1.GetComponent<Mobs>().MobRay = true;
            Instantiate(MobPrefab2, spawnPosition[1], MobPrefab2.transform.rotation);
            MobPrefab2.GetComponent<Mobs>().TudoFalso();
            MobPrefab2.GetComponent<Mobs>().MobRay = true;
        }
        if (E2GruntMap2)
        {
            Instantiate(MobPrefab1, spawnPosition[0], MobPrefab1.transform.rotation);
            MobPrefab1.GetComponent<Mobs>().TudoFalso();
            MobPrefab1.GetComponent<Mobs>().MobGr = true;
            Instantiate(MobPrefab2, spawnPosition[1], MobPrefab2.transform.rotation);
            MobPrefab2.GetComponent<Mobs>().TudoFalso();
            MobPrefab2.GetComponent<Mobs>().MobGr = true;
        }
        if (E2Ray1GruntMap2)
        {
            Instantiate(MobPrefab1, spawnPosition[0], MobPrefab1.transform.rotation);
            MobPrefab1.GetComponent<Mobs>().TudoFalso();
            MobPrefab1.GetComponent<Mobs>().MobRay = true;
            Instantiate(MobPrefab2, spawnPosition[1], MobPrefab2.transform.rotation);
            MobPrefab2.GetComponent<Mobs>().TudoFalso();
            MobPrefab2.GetComponent<Mobs>().MobRay = true;
            Instantiate(MobPrefab2, spawnPosition[2], MobPrefab2.transform.rotation);
            MobPrefab3.GetComponent<Mobs>().TudoFalso();
            MobPrefab3.GetComponent<Mobs>().MobGr = true;
        }
        if (E3Raymap2)
        {
            Instantiate(MobPrefab1, spawnPosition[0], MobPrefab1.transform.rotation);
            MobPrefab1.GetComponent<Mobs>().TudoFalso();
            MobPrefab1.GetComponent<Mobs>().MobRay = true;
            Instantiate(MobPrefab2, spawnPosition[1], MobPrefab2.transform.rotation);
            MobPrefab2.GetComponent<Mobs>().TudoFalso();
            MobPrefab2.GetComponent<Mobs>().MobRay = true;
            Instantiate(MobPrefab2, spawnPosition[2], MobPrefab2.transform.rotation);
            MobPrefab3.GetComponent<Mobs>().TudoFalso();
            MobPrefab3.GetComponent<Mobs>().MobRay = true;
        }
        if (E3Gruntmap2)
        {
            Instantiate(MobPrefab1, spawnPosition[0], MobPrefab1.transform.rotation);
            MobPrefab1.GetComponent<Mobs>().TudoFalso();
            MobPrefab1.GetComponent<Mobs>().MobGr = true;
            Instantiate(MobPrefab2, spawnPosition[1], MobPrefab2.transform.rotation);
            MobPrefab2.GetComponent<Mobs>().TudoFalso();
            MobPrefab2.GetComponent<Mobs>().MobGr = true;
            Instantiate(MobPrefab2, spawnPosition[2], MobPrefab2.transform.rotation);
            MobPrefab3.GetComponent<Mobs>().TudoFalso();
            MobPrefab3.GetComponent<Mobs>().MobGr = true;
        }
        // Rec 1 map3
        if (E2Grunt2MDMap3)
        {
            Instantiate(MobPrefab1, spawnPosition[0], MobPrefab1.transform.rotation);
            MobPrefab1.GetComponent<Mobs>().TudoFalso();
            MobPrefab1.GetComponent<Mobs>().MobGr = true;
            Instantiate(MobPrefab2, spawnPosition[1], MobPrefab2.transform.rotation);
            MobPrefab2.GetComponent<Mobs>().TudoFalso();
            MobPrefab2.GetComponent<Mobs>().MobGr = true;
            Instantiate(MobPrefab3, spawnPosition[3], MobPrefab3.transform.rotation);
            MobPrefab3.GetComponent<Mobs>().TudoFalso();
            MobPrefab3.GetComponent<Mobs>().MobMD = true;
            Instantiate(MobPrefab4, spawnPosition[4], MobPrefab4.transform.rotation);
            MobPrefab4.GetComponent<Mobs>().TudoFalso();
            MobPrefab4.GetComponent<Mobs>().MobMD = true;
        }
        if (E2Grunt3MDMap3)
        {
            Instantiate(MobPrefab1, spawnPosition[0], MobPrefab1.transform.rotation);
            MobPrefab1.GetComponent<Mobs>().TudoFalso();
            MobPrefab1.GetComponent<Mobs>().MobGr = true;
            Instantiate(MobPrefab2, spawnPosition[1], MobPrefab2.transform.rotation);
            MobPrefab2.GetComponent<Mobs>().TudoFalso();
            MobPrefab2.GetComponent<Mobs>().MobGr = true;
            Instantiate(MobPrefab3, spawnPosition[3], MobPrefab3.transform.rotation);
            MobPrefab3.GetComponent<Mobs>().TudoFalso();
            MobPrefab3.GetComponent<Mobs>().MobMD = true;
            Instantiate(MobPrefab4, spawnPosition[4], MobPrefab4.transform.rotation);
            MobPrefab4.GetComponent<Mobs>().TudoFalso();
            MobPrefab4.GetComponent<Mobs>().MobMD = true;
            Instantiate(MobPrefab5, spawnPosition[5], MobPrefab5.transform.rotation);
            MobPrefab5.GetComponent<Mobs>().TudoFalso();
            MobPrefab5.GetComponent<Mobs>().MobMD = true;
        }
        if (E3GruntMap3)
        {
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
        // Rec 1 map4
        if (E1SweeperMap4)
        {
            Instantiate(MobPrefab1, spawnPosition[0], MobPrefab1.transform.rotation);
            MobPrefab1.GetComponent<Mobs>().TudoFalso();
            MobPrefab1.GetComponent<Mobs>().MobSweep = true;
        }
        if (E1Sweeper2GruntMap4)
        {
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
    }
    public void Boss()
    {
        // Boss Fight
        if (BossFight)
        {
            Instantiate(MobPrefab1, spawnPosition[6], MobPrefab1.transform.rotation);
            MobPrefab1.GetComponent<Mobs>().TudoFalso();
            MobPrefab1.GetComponent<Mobs>().MobBoss = true;
        }
    }
}
