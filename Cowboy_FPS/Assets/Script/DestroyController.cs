using UnityEngine;

public class DestroyController : MonoBehaviour
{

    [SerializeField] private float tempoDeVida = 3f;
    
    void Start()
    {
        Destroy(this.gameObject,tempoDeVida);
    }


}
