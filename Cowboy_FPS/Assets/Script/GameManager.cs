using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Verifica��es")]
    [SerializeField] private bool jogadorEstaVivo;

    
    void Awake()
    {
        instance = this;
    }


}
