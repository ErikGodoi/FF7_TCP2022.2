using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movimentação : MonoBehaviour
{
    // GAMEMANAGER
    GameManager gm;

    // sistema de encontro aleatório
    public LayerMask prerigoLayer;
    public bool batalhaLayer;
    public bool cena2Batalha;
    public bool cena3Batalha;
    public bool cena4Batalha;
    public bool podeEntrarEmBatalha;
    public float carregandoBatalha;

    // Movimentação
    public Transform cam;
    [Range(0, 100)][SerializeField] float vel;
    //  [Range(0, 100)][SerializeField] float smooth, smoothVel;
    //  [Range(0, 10)][SerializeField] float radiusEncontro;
    CharacterController controle;

    // Cenas
    public bool emCombate;

    // Batalha Inicial
    bool batalhaIntro = false;
    EncontroV2 batalha;
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        emCombate = false;
        controle = gameObject.GetComponent<CharacterController>();
        batalha = FindObjectOfType<EncontroV2>();
    }
    private void FixedUpdate()
    {
        if (emCombate == false)
        {
            Move2();
            EntrarEmBatalha();
        }
        if (emCombate == true)
        {
            transform.position = new Vector3(transform.position.x, PlayerPrefs.GetFloat("Posicao.Y"), transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            transform.position = new Vector3(40, -4, 12);
        }
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        cena2Batalha = false;
        cena3Batalha = false;
        cena4Batalha = false;
        Debug.Log(hit.gameObject.name);
        if (hit.gameObject.name == ("PrerigoSec1Mapa1"))
        {
            //batalhaLayer = true;
        }
        if (hit.gameObject.name == ("Cena2Batalha"))
        {
            //cena2Batalha = true;
        }
        if (hit.gameObject.name == ("CorredorReator"))
        {
            //cena3Batalha = true;
        }
        if (hit.gameObject.name == ("EntradaReator"))
        {
            //cena4Batalha = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == ("TPCena2"))
        {
            SceneManager.LoadScene("Cena2");
        }
        if (other.gameObject.name == ("TPCena3"))
        {
            SceneManager.LoadScene("Cena3");
        }
        if (other.gameObject.name == ("TPCena4"))
        {
            SceneManager.LoadScene("Cena4");
        }
        if (other.gameObject.name == ("TPCena5"))
        {
            SceneManager.LoadScene("Cena5");
        }
        if (other.gameObject.name == ("BatalhaInicial") && batalhaIntro == false)
        {
            batalhaIntro = true;
            emCombate = true;
            PlayerPrefs.SetInt("UltimaCena", SceneManager.GetActiveScene().buildIndex);
            PlayerPrefs.SetFloat("Posicao.Y", transform.position.y);
            SceneManager.LoadScene("Batalha");
            batalha.Sec1Map1 = true;
            batalha.SpawnPorMapa();
            batalha.Sec1Map1 = false;
        }
    }
    void Move2()
    {
        float speed = 6f;
        float gravity = 20f;
        Vector3 moveDirection = Vector3.zero;
        if (controle.isGrounded)
        {
            moveDirection = new Vector3(0f, 0f, Input.GetAxis("Vertical") * vel);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controle.Move(moveDirection * Time.deltaTime);

        // rotação
        transform.Rotate(0f, Input.GetAxis("Horizontal") * 5f, 0f);
    }
    void EntrarEmBatalha()
    {
        // Cena 2
        if (cena2Batalha == true)
        {
            carregandoBatalha += 0.025f;
        }
        // Cena 3
        if (cena3Batalha == true)
        {
            carregandoBatalha += 0.025f;
        }
        // Cena 4
        if (cena4Batalha == true)
        {
            carregandoBatalha += 0.025f;
        }
        if (batalhaLayer == true)
        {
            //carregandoBatalha += 0.025f;
            carregandoBatalha += 0.1f;
        }
        if (carregandoBatalha >= 10)
        {
            carregandoBatalha = 10;
            podeEntrarEmBatalha = true;
        }
        if (carregandoBatalha < 10)
        {
            podeEntrarEmBatalha = false;
        }
        if (podeEntrarEmBatalha == true && cena2Batalha == true)
        {
            emCombate = true;
            carregandoBatalha = 0;
            PlayerPrefs.SetInt("UltimaCena", SceneManager.GetActiveScene().buildIndex);
            PlayerPrefs.SetFloat("Posicao.Y", transform.position.y);
            SceneManager.LoadScene("Batalha");
            batalha.Sec1Map2 = true;
            batalha.SpawnPorMapa();
            batalha.Sec1Map2 = false;
        }
        if (podeEntrarEmBatalha == true && cena3Batalha == true)
        {
            Debug.Log("Entrou em batalha na cena 3");
            emCombate = true;
            carregandoBatalha = 0;
            PlayerPrefs.SetInt("UltimaCena", SceneManager.GetActiveScene().buildIndex);
            PlayerPrefs.SetFloat("Posicao.Y", transform.position.y);
            SceneManager.LoadScene("Batalha");
            batalha.Sec1Map3 = true;
            batalha.SpawnPorMapa();
            batalha.Sec1Map3 = false;
        }
        if (podeEntrarEmBatalha == true && cena4Batalha == true)
        {
            emCombate = true;
            carregandoBatalha = 0;
            PlayerPrefs.SetInt("UltimaCena", SceneManager.GetActiveScene().buildIndex);
            PlayerPrefs.SetFloat("Posicao.Y", transform.position.y);
            SceneManager.LoadScene("Batalha");
            batalha.Rec1Map1 = true;
            batalha.SpawnPorMapa();
            batalha.Rec1Map1 = false;
        }
    }
    /*private void OnDrawGizmosSelected()
    {
        if (gameObject == null)
            return;
        Gizmos.DrawWireSphere(gameObject.transform.position, radiusEncontro);
    }*/
}
