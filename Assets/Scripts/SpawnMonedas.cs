using UnityEngine;

public class SpawnMonedas : MonoBehaviour
{
    public GameObject monedaPrefab;
    public Transform[] puntosSpawn;

    void Start()
    {
        Spawn();
    }

    void Spawn()
    {
        foreach (Transform punto in puntosSpawn)
        {
            Instantiate(monedaPrefab, punto.position, Quaternion.identity);
        }
    }
}