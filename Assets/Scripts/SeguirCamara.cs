using UnityEngine;

public class SeguirCamara : MonoBehaviour
{
    public Transform jugador;
    public float suavizado = 5f;

    void LateUpdate()
    {
        Vector3 posicionDeseada = new Vector3(
            jugador.position.x,
            jugador.position.y,
            transform.position.z
        );

        transform.position = Vector3.Lerp(
            transform.position,
            posicionDeseada,
            suavizado * Time.deltaTime
        );
    }
}