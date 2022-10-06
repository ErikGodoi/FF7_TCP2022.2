using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimentação : MonoBehaviour
{
    // sistema de encontro aleatório
    public LayerMask prerigoLayer;
    bool podeEntrarEmBatalha;
    public float carregandoBatalha;

    // Movimentação
    public Transform cam;
    Vector3 mov;
    [Range(0, 100)][SerializeField] float vel;
    [Range(0, 100)][SerializeField] float smooth, smoothVel;
    [Range(0, 10)][SerializeField] float radiusEncontro;
    CharacterController controle;
    void Start()
    {
        controle = gameObject.GetComponent<CharacterController>();
    }
    private void FixedUpdate()
    {
        Movimento();
        if (mov.x != 0f || mov.y != 0f || mov.z != 0f)
        {
            VerificacaoDeBatalha();
        }
    }
    void Movimento()
    {
        mov.x = Input.GetAxisRaw("Horizontal");
        mov.z = Input.GetAxisRaw("Vertical");
        mov = new Vector3(mov.x, 0f, mov.z).normalized;

        if (mov.magnitude >= 0.1f)
        {
            float angulo = Mathf.Atan2(mov.x, mov.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angSmooth = Mathf.SmoothDampAngle(transform.eulerAngles.y, angulo, ref smoothVel, smooth);
            transform.rotation = Quaternion.Euler(0f, angSmooth, 0f);

            Vector3 movDir = Quaternion.Euler(0f, angulo, 0f) * Vector3.forward;
            controle.Move(movDir.normalized * vel * Time.fixedDeltaTime);
        }
    }
    void VerificacaoDeBatalha()
    {
        if (carregandoBatalha >= 10)
        {
            carregandoBatalha = 10;
            podeEntrarEmBatalha = true;
        }
        else if (Physics.OverlapSphere(gameObject.transform.position, radiusEncontro, prerigoLayer) != null)
        {
            carregandoBatalha += Time.fixedDeltaTime;
        }
        if (podeEntrarEmBatalha == true)
        {
            Debug.Log("Entrou em batalha");
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (gameObject == null)
            return;
        Gizmos.DrawWireSphere(gameObject.transform.position, radiusEncontro);
    }
}
