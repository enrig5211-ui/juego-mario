using UnityEngine;

public class Moneda : MonoBehaviour
{
    public float velocidadFlotacion = 2f;
    public float alturaFlotacion = 0.25f;
    public float velocidadGiro = 100f;

    private Vector3 posicionInicial;

    void Start()
    {
        posicionInicial = transform.position;
    }

    void Update()
    {
        float nuevaY = posicionInicial.y + Mathf.Sin(Time.time * velocidadFlotacion) * alturaFlotacion;
        transform.position = new Vector3(posicionInicial.x, nuevaY, posicionInicial.z);

        transform.Rotate(0, 0, velocidadGiro * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ContadorMonedas.instancia.SumarMoneda();
            Destroy(gameObject);
        }
    }
}