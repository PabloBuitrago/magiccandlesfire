using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class Boton : MonoBehaviour
{

    public Comienzo comienzo;

    public Microfono microfono;

    public GameObject panel;
    public GameObject panel2;

    public GameObject boton;
    public GameObject boton2;
    public GameObject boton3;
    public GameObject boton4;
    public GameObject boton5;
    public GameObject boton6;
    public GameObject boton7;

    public GameObject encender;
    public GameObject reload;

    public GameObject soplido;

    bool entrar = false;

    string URLmonstrar = "https://play.google.com/store/apps/developer?id=Mipandco";

    public void Recargar()
    {
        comienzo.entrar = true;

        for (int i = 0; i < 4; i++)
        {
            comienzo.fuegos[i].SetActive(false);
        }

        switch (microfono.num)
        {
            case 1:
                microfono.particula1.SetActive(true);
                microfono.particula2.SetActive(true);
                microfono.particula3.SetActive(true);
                break;
            case 2:
                microfono.particula.SetActive(true);
                microfono.particula2.SetActive(true);
                microfono.particula3.SetActive(true);
                break;
            case 3:
                microfono.particula.SetActive(true);
                microfono.particula1.SetActive(true);
                microfono.particula3.SetActive(true);
                break;
            case 4:
                microfono.particula.SetActive(true);
                microfono.particula1.SetActive(true);
                microfono.particula2.SetActive(true);
                break;
        }

        encender.SetActive(true);
        soplido.SetActive(false);
        reload.SetActive(false);
    }

    public void Monstrar(bool pulsar)
    {
        if (pulsar)
        {
            panel.SetActive(true);
        }
        else
        {
            panel.SetActive(false);
        }
    }

    public void Monstrar2(bool pulsar)
    {
        if (pulsar)
        {
            panel2.SetActive(true);
        }
        else
        {
            panel2.SetActive(false);
        }
    }

    public void Empezar()
    {
        boton.SetActive(false);
        boton2.SetActive(false);
        boton3.SetActive(false);
        boton4.SetActive(false);
        boton5.SetActive(false);
        boton6.SetActive(false);
        boton7.SetActive(false);

        GetComponent<Animator>().SetTrigger("entrar");

        entrar = true;
    }

    void Esperar()
    {
        encender.SetActive(true);
    }

    void Esperar2()
    {
        boton.SetActive(true);
        boton2.SetActive(true);
        boton3.SetActive(true);
        boton4.SetActive(true);
        boton5.SetActive(true);
        boton6.SetActive(true);
        boton7.SetActive(true);
    }

    void Esperar3()
    {
        encender.SetActive(false);
        soplido.SetActive(false);
        reload.SetActive(false);
    }

    public void Terminar()
    {
        encender.SetActive(false);

        GetComponent<Animator>().SetTrigger("salir");

        entrar = false;
    }

    public void Salir()
    {
        if (entrar)
        {
            Recargar();

            Terminar();
        }
        else
        {
            if (panel.activeSelf == false && panel2.activeSelf == false)
            {
#if UNITY_EDITOR
                EditorApplication.isPlaying = false;
#else
                                                Application.Quit();
#endif
            }
            else
            {
                panel.SetActive(false);
                panel2.SetActive(false);
            }
        }

    }

    void Update()
    {
        //Si presionan el boton ESC.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Salir();
        }
    }

    public void MagicCardsDeck()
    {
        Application.OpenURL(URLmonstrar);
    }
}
