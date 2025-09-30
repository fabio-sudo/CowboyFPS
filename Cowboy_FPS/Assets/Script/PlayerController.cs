using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("Posição do Jogador")]
    public static PlayerController instance;


    [Header("Player")]
    [SerializeField]
    private float speed = 5f;
    
    [SerializeField]
    private Rigidbody2D rb;

    private Vector2 comandosTeclado;

    [Header("Movimento Camera")]
    private Vector2 movimentoMouse;

    [SerializeField]
    private float sensibilidade = 100f;
    
    [Header ("Animação Player")]
    [SerializeField] private Animator animatorPainelArma;
    

    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        MovimentarJogador();
        GirarCamera();
    }

    private void MovimentarJogador()
    {
        comandosTeclado = new Vector2(
            Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));

        Vector3 movimentoHorizontal = transform.up * -comandosTeclado.x;
        Vector3 movimentoVertical = transform.right * comandosTeclado.y;

        rb.linearVelocity = (movimentoHorizontal + movimentoVertical) * speed;


        if (rb.linearVelocity.magnitude ==0)
        {
            animatorPainelArma.Play("JogadorParadoAnimation");
        }
        else
        {
            animatorPainelArma.Play("JogadorAndandoAnimation");
        }



    }

    private void GirarCamera()
    {
        movimentoMouse = new Vector2(
            Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y") *
            sensibilidade);

        transform.rotation = Quaternion.Euler(
            transform.rotation.eulerAngles.x,
            transform.rotation.eulerAngles.y,
            transform.rotation.eulerAngles.z - movimentoMouse.x);
    }

}
