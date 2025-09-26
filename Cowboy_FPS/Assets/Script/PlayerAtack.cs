using System;
using UnityEngine;

public class PlayerAtack : MonoBehaviour
{
    [SerializeField]
    private Camera cameraJogo;

    [Header ("Munição")]
    [SerializeField] private int municaoMaxima = 30;
    [SerializeField] private int municaoAtual;

    [Header("Impacto")]
    [SerializeField] private GameObject impacto;

    [Header("Animação")]
    [SerializeField] private Animator animatorArma;

    void Start()
    {
        //Travar cursor do mouse
        Cursor.lockState = CursorLockMode.Locked;

        //mouse invisivel
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Atirar();
    }

    void Atirar()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (municaoAtual > 0)
            {

                Ray raio = cameraJogo.ViewportPointToRay(
                    new Vector3(0.5f, 0.5f, 0f));

                RaycastHit localAtingido;

                Debug.DrawRay(
                    raio.origin, raio.direction * 100f, Color.red, 2f);


                if (Physics.Raycast(raio, out localAtingido))
                {
                    //Debug.Log("Estou olhando para:" +
                    //    localAtingido.transform.name);

                    Instantiate(impacto,localAtingido.point, localAtingido.transform.rotation);

                }
                else
                {
                    Debug.Log("Não estou olhando nada");

                }
                animatorArma.SetTrigger("trArma");
                municaoAtual -= 1;
            }
            else
            {
                Debug.Log($"Munição igual há: {municaoAtual}");
            }



        }
    }


}
