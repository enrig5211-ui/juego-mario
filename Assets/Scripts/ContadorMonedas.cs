using UnityEngine;
using TMPro;

public class ContadorMonedas : MonoBehaviour
{
    public static ContadorMonedas instancia;

    public int monedas = 0;
    public TextMeshProUGUI textoMonedas;

    void Awake()
    {
        instancia = this;
    }

    public void SumarMoneda()
    {
        monedas++;
        textoMonedas.text = "Monedas: " + monedas;
    }
}