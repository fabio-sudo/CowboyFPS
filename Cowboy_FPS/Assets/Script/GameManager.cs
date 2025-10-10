using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Verificações")]
    public bool jogadorEstaVivo;


    
    void Awake()
    {
        instance = this;
    }

    public void GameOver()
    {
        jogadorEstaVivo = false;
        Debug.Log("Game Over");
    }


}
