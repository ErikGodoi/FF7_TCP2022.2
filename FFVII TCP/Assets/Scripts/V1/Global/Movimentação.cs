using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movimentação : MonoBehaviour
{
    // posição no mundo
    public float posX, posY, posZ;
    public float rotX, rotY, rotZ;
    public Vector3 posicao;
    public Vector3 rotacao;
    // GAMEMANAGER
    GameManager gm;

    // sistema de encontro aleatório
    public LayerMask prerigoLayer;
    public bool batalhaLayer;
    public bool podeEntrarEmBatalha;
    public float carregandoBatalha;

    // Movimentação
    public Transform cam;
    Vector3 mov;
    [Range(0, 100)][SerializeField] float vel;
    [Range(0, 100)][SerializeField] float smooth, smoothVel;
    [Range(0, 10)][SerializeField] float radiusEncontro;
    CharacterController controle;

    // Cenas
    public bool emCombate;
    public GameObject mundo;
    public Scene CenaAtual;
    string nomeDaCena;

    // Script de Encontro Aleatório
    EncontroV2 SpawnEnemies;

    // teste
    bool cenaDeBatalhaAtiva;
    void Start()
    {
        posicao = new Vector3(posX, posY, posZ);
        rotacao = new Vector3(rotX, rotY, rotZ);
        gm = FindObjectOfType<GameManager>();
        emCombate = false;
        mundo = GameObject.Find("Mundo");
        controle = gameObject.GetComponent<CharacterController>();
        CenaAtual = SceneManager.GetActiveScene();
        nomeDaCena = CenaAtual.name;
        SpawnEnemies = FindObjectOfType<EncontroV2>();

        // teste
        cenaDeBatalhaAtiva = SceneManager.GetSceneByName("Batalha").isLoaded;
    }
    private void FixedUpdate()
    {
        if (emCombate == false)
        {
            Move2();
            EntrarEmBatalha();
        }
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Debug.Log(hit.gameObject.name);
        if (hit.gameObject.name != ("PrerigoSec1Mapa1"))
        {
            batalhaLayer = false;
        }
        else batalhaLayer = true;

    }
    void Move2()
    {
        float speed = 6f;
        float gravity = 20f;
        Vector3 moveDirection = Vector3.zero;
        if (controle.isGrounded)
        {
            moveDirection = new Vector3(0f, 0f, Input.GetAxis("Vertical"));
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
        if (podeEntrarEmBatalha == true)
        {
            Debug.Log("Entrou em batalha");
            //gm.SalvaPosicao();
            emCombate = true;
            carregandoBatalha = 0;
            SceneManager.LoadScene("Batalha");
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (gameObject == null)
            return;
        Gizmos.DrawWireSphere(gameObject.transform.position, radiusEncontro);
    }
}
