using UnityEngine;

public class TiroController : MonoBehaviour
{
    [SerializeField] private float velocidadeDoProjetil = 5f;
    private int danoTiro = 5;

    private void movimentarProjetilInimigo()
    {
        transform.Translate(
            Vector3.forward * velocidadeDoProjetil * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        movimentarProjetilInimigo();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")){

            collision.gameObject.GetComponent<PlayerController>().DanoPlayer(danoTiro);
        }

        Destroy(gameObject);
    }

}
