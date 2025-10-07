using UnityEngine;

public class TiroController : MonoBehaviour
{
    [SerializeField] private float velocidadeDoProjetil = 5f;

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
}
