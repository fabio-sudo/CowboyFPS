using UnityEngine;

public class OlharParaJogador : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(
            PlayerController.instance.transform.position,
            -Vector3.forward );
    }
}
