using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public void IniciarJuego()
    {
        SceneManager.LoadScene("Nivel1");
    }

    public void SalirJuego()
    {
        Debug.Log("Salir del juego");
        Application.Quit();
    }
}