using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Verificações")]
    [SerializeField] private bool jogadorEstaVivo;

    
    void Awake()
    {
        instance = this;
    }


}
