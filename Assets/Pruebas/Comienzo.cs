using UnityEngine;
using System.Collections;

public class Comienzo : MonoBehaviour
{

    public Microfono microfono;

    public GameObject encender;
    public GameObject reload;

    public GameObject[] fuegos;

    public bool entrar = true;

    public GameObject soplido;

    public void Pulsar(int numero)
    {
        if (entrar)
        {
            microfono.num = numero;

            for (int i = 0; i < 4; i++)
            {
                fuegos[i].SetActive(true);
            }

            entrar = false;
        }

        encender.SetActive(false);
        reload.SetActive(true);
        soplido.SetActive(true);
    }
}
