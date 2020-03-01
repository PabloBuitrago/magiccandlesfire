using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Idiomas : MonoBehaviour {

    public string version = "1.0.";

    public Text texto;
    public Text by;

    public Text empezar;
    public Text salir;
    public Text de;

    public Text magic;

    int entrar;

    void Start()
    {
        if (Application.systemLanguage.ToString() == "Spanish")
            entrar = 0;
        else
            entrar = 1;

        if (entrar == 0)
        {
            texto.text = "Dependiendo de la zona pulsada en el botón con símbolo de llama\nquedara encendida una vela u otra.\n\nUna vez se hayan encendido todas las velas,pide al espectador que sople\ny se apagaran todas las velas menos la que haya elegido.";
            by.text = "Versión " + version + " de la aplicación.\nPara cualquier consulta,\nmejora o información contactar con: mipanco@gmail.com.";
            empezar.text = "MAGIA";
            salir.text = "SALIR";
            de.text = "DE";
            magic.text = "Más Trucos:";
            entrar = 1;
        }
        else
        {
            texto.text = "Depending on the area pressed the button with flame\nsymbol will remain lit a candle or another.\n\nOnce you have lit all the candles, asks the viewer to blow\nand all the candles least you have chosen went out.";
            by.text = "App Version " + version + ".\nFor any suggestion or comment,\nplease don´t hesitate to contact us: mipandco@gmail.com.";
            empezar.text = "MAGIC";
            salir.text = "EXIT";
            de.text = "BY";
            magic.text = "More Tricks:";
            entrar = 0;
        }
    }
}
