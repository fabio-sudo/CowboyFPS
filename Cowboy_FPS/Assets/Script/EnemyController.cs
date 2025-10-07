using System;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Movimentação")]
    public float speed = 5f;
    public Transform[] pontosCaminhar;
    public int pontoAtual;
    [SerializeField] private float tempoEntreOsPontos;
    [SerializeField] private float tempoAtual;

    [Header("Verificações")]
    public bool inimigoEstaVivo;
    public bool inimigoPodeAndar;

    [Header("Disparo")]
    public GameObject projetilInimigo;
    public Transform localDoDisparo;
    public float distanciaAtaque;
    public float tempoEntreAtaque;
    public bool inimigoAtacou;

    [Header("Sistema de Vida")]
    [SerializeField] private float vidaMaxima = 10f;
    [SerializeField] private float vidaAtual;

    [Header ("Animações")]
    [SerializeField] private Animator animator;

    // Update is called once per frame
    void Update()
    {
        MovimentarInimigo();
        VerificarDistancia();

    }

    private void Start()
    {
        inimigoEstaVivo = true;
        inimigoPodeAndar = true;
        transform.position = pontosCaminhar[0].position;
        vidaAtual = vidaMaxima;

        animator = GetComponent<Animator>();
    }


    private void EsperarAntesDeCaminhar()
    {
    
        tempoAtual -= Time.deltaTime;


        if (tempoAtual <= 0) {

            inimigoPodeAndar = true;
            pontoAtual++;
            tempoAtual = 2f;
        }
    }

    private void MovimentarInimigo()
    {
        if (inimigoEstaVivo)
        {

            if (inimigoPodeAndar)
            {

                transform.position =
                    Vector2.MoveTowards(
                        transform.position,
                        pontosCaminhar[pontoAtual].position,
                        speed * Time.deltaTime);

                if (transform.position.y != pontosCaminhar[pontoAtual].position.y)
                {
                    animator.SetTrigger("tWalk");
                }

                if (transform.position.y == pontosCaminhar[pontoAtual].position.y)
                {
                    EsperarAntesDeCaminhar();
                    animator.SetTrigger("tIdle");
                }

                if (pontoAtual == pontosCaminhar.Length)
                {
                    pontoAtual = 0;
                }

            }



        }

    }

    private void VerificarDistancia()
    {
        if(Vector3.Distance(transform.position, 
            PlayerController.instance.transform.position) < distanciaAtaque)
        {
            AtaqueJogadorEnemy();
        }
        else
        {
            inimigoPodeAndar = true;
        }
    }

    private void AtaqueJogadorEnemy()
    {
        if (inimigoAtacou == false)
        {
            inimigoPodeAndar = false;
            animator.SetTrigger("tAtack");
            Instantiate(projetilInimigo, localDoDisparo.position, localDoDisparo.rotation);
            inimigoAtacou = true;


            //Invocar o metodo para chamar o metodo de tempo em tempo
            Invoke(nameof(ResetarAtaqueDoInimigo), tempoEntreAtaque);   
        }
    }

    private void ResetarAtaqueDoInimigo()
    {
        inimigoAtacou = false;
    }


    public void PerdeVidaInimigo(int dano)
    {
        if (inimigoEstaVivo)
        {
            vidaAtual -= dano;
            animator.SetTrigger("tDamage");

            if (vidaAtual < 0)
            {
                inimigoEstaVivo = false;
                inimigoPodeAndar = false;
                animator.SetTrigger("tLose");
            }
        }
    }

    public void DerrotarInimigo()
    {
        Destroy(gameObject);
    }

}
