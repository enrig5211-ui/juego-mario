using UnityEngine;
using TMPro;

public class Temporizador : MonoBehaviour
{
    public float tiempoInicial = 60f;

    public TextMeshProUGUI textoTiempo;

    private float tiempoRestante;
    private bool terminado = false;

    void Start()
    {
        tiempoRestante = tiempoInicial;
    }

    void Update()
    {
        if (terminado)
            return;

        tiempoRestante -= Time.deltaTime;

        if (tiempoRestante <= 0)
        {
            tiempoRestante = 0;
            terminado = true;

            Debug.Log("Tiempo terminado");
        }

        MostrarTiempo();
    }

    void MostrarTiempo()
    {
        int minutos = Mathf.FloorToInt(tiempoRestante / 60);
        int segundos = Mathf.FloorToInt(tiempoRestante % 60);

        textoTiempo.text = string.Format("{0:00}:{1:00}", minutos, segundos);
    }
}