using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Movimentação")]
    public float speed = 5f;
    public Transform[] pontosCaminhar;
    public int pontoAtual;

    [Header("Verificações")]
    public bool inimigoEstaVivo;
    public bool inimigoPodeAndar;


    [SerializeField] private float tempoEntreOsPontos;
    [SerializeField] private float tempoAtual;


    // Update is called once per frame
    void Update()
    {
        MovimentarInimigo();
    }

    private void Start()
    {
        inimigoEstaVivo = true;
        inimigoPodeAndar = true;
        transform.position = pontosCaminhar[0].position;
    }


    private void EsperarAntesDeCaminhar()
    {
        inimigoPodeAndar = false;
        tempoAtual -= Time.deltaTime;
        if (tempoAtual <= 0) {

            inimigoPodeAndar = true;
            pontoAtual++;
            tempoAtual = tempoEntreOsPontos;
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

                if (transform.position.y == pontosCaminhar[pontoAtual].position.y)
                {
                    pontoAtual++;
                }
                if(pontoAtual == pontosCaminhar.Length)
                {
                    pontoAtual = 0;
                }

            }

        }

    }



}
