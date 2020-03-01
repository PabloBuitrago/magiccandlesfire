using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Microfono : MonoBehaviour
{

    public GameObject particula;
    public GameObject particula1;
    public GameObject particula2;
    public GameObject particula3;

    public Comienzo comienzo;

    public int num = 1;

    private AudioSource aud;
    private float[] samples;
    private bool entrar;

    public bool soplido = false;

    public GameObject soplidoGame;

    public bool microfonoEnable = true;

    public float vol = 0;

    public Sprite microtrue;
    public Sprite microfalse;

    public Image microGame;

    void Start()
    {
        entrar = true;

        aud = GetComponent<AudioSource>();
        aud.clip = Microphone.Start(Microphone.devices[0], true, 10, 44100);

        while (!(Microphone.GetPosition(null) > 0))
        {
        }
        aud.Play();

        samples = new float[4096]; // 4096 = around 85 ms of samples

        Invoke("Start", 8);
    }

    void Update()
    {
        if(microfonoEnable)
            vol = GetRMS(0) + GetRMS(1);

        if ((vol > 0.35 || soplido) && entrar && !comienzo.entrar)
        {
            switch (num)
            {
                case 1:
                    particula1.SetActive(false);
                    particula2.SetActive(false);
                    particula3.SetActive(false);
                    break;
                case 2:
                    particula.SetActive(false);
                    particula2.SetActive(false);
                    particula3.SetActive(false);
                    break;
                case 3:
                    particula.SetActive(false);
                    particula1.SetActive(false);
                    particula3.SetActive(false);
                    break;
                case 4:
                    particula.SetActive(false);
                    particula1.SetActive(false);
                    particula2.SetActive(false);
                    break;
            }

            soplidoGame.SetActive(false);

            soplido = false;
        }
    }

    public void Soplar()
    {
        soplido = true;
    }

    public void CambioMicro()
    {
        microfonoEnable = !microfonoEnable;

        if (microfonoEnable)
            microGame.sprite = microtrue;
        else
            microGame.sprite = microfalse;
    }

    
    float GetRMS(int channel)
    {
    aud.GetOutputData(samples, channel); // fill array with samples
    float sum = 0;
    for (int i = 0; i< 4096; i++)
    {
            sum += samples[i] * samples[i]; // sum squared samples
    }
        return Mathf.Sqrt(sum/4096); // rms = square root of average 
    }
    
}
