using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    [Header("Posição do Jogador")]
    public static PlayerController instance;


    [Header("Player")]
    [SerializeField]
    private float speed = 5f;

    [Header ("Marcadores Vida")]
    public int vidaAtual;
    public int vidaMaxima = 10;
    public TextMeshProUGUI vidaTexto;
    public Image vidaImagem;//Using UI  CTRL+.
    public Sprite spriteMorte;




    [SerializeField]
    private Rigidbody2D rb;

    private Vector2 comandosTeclado;

    [Header("Movimento Camera")]
    private Vector2 movimentoMouse;

    [SerializeField]
    private float sensibilidade = 100f;
    
    [Header ("Animação Player")]
    [SerializeField] private Animator animatorPainelArma;


    private void Start()
    {
        vidaAtual = vidaMaxima;
        vidaTexto.text = vidaAtual.ToString();
    }

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

    public void DanoPlayer(int dano)
    {
        if (GameManager.instance.jogadorEstaVivo)
        {
            vidaAtual -= dano;
            vidaAtual = Mathf.Clamp(vidaAtual, 0, vidaMaxima);   
            vidaTexto.text = vidaAtual.ToString();

        }
        if(vidaAtual <= 0)
        {
            GameManager.instance.GameOver();
            Morrer();
        }
    }

    private void Morrer()
    {
        if (vidaImagem != null && spriteMorte != null)
        {
            vidaImagem.sprite = spriteMorte;
            Color corAtual = vidaImagem.color;
            corAtual.a = 1f;
            vidaImagem.color = corAtual;
        }
    }

}
