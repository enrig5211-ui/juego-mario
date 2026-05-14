using UnityEngine;

public class EnemigoKoopa : MonoBehaviour
{
    [Header("Movimiento")]
    public float velocidadCaminar = 2f;
    public float velocidadCaparazon = 7f;
    public float fuerzaReboteJugador = 7f;

    [Header("Sprites")]
    public Sprite spriteCaminar1;
    public Sprite spriteCaminar2;
    public Sprite spriteCaparazon;

    [Header("Animación")]
    public float velocidadAnimacion = 0.25f;

    private Rigidbody2D rb;
    private SpriteRenderer sr;

    private int direccion = -1;
    private float timer;
    private bool usarSprite1 = true;

    private bool enCaparazon = false;
    private bool caparazonMoviendose = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        OrientarSprite();
    }

    void Update()
    {
        if (!enCaparazon)
        {
            rb.linearVelocity = new Vector2(direccion * velocidadCaminar, rb.linearVelocity.y);
            AnimarCaminar();
            OrientarSprite();
        }
        else if (caparazonMoviendose)
        {
            rb.linearVelocity = new Vector2(direccion * velocidadCaparazon, rb.linearVelocity.y);
        }
        else
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
        }
    }

    void AnimarCaminar()
    {
        timer += Time.deltaTime;

        if (timer >= velocidadAnimacion)
        {
            timer = 0f;
            usarSprite1 = !usarSprite1;
            sr.sprite = usarSprite1 ? spriteCaminar1 : spriteCaminar2;
        }
    }

    void OrientarSprite()
    {
        // Si tu sprite mira originalmente a la izquierda:
        if (direccion > 0)
            sr.flipX = true;
        else
            sr.flipX = false;

        // Si queda al revés, cambia true/false:
        // sr.flipX = direccion < 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D rbJugador = collision.gameObject.GetComponent<Rigidbody2D>();

            bool pisadoDesdeArriba =
                rbJugador != null &&
                rbJugador.linearVelocity.y < 0 &&
                collision.transform.position.y > transform.position.y + 0.2f;

            if (pisadoDesdeArriba)
            {
                rbJugador.linearVelocity = new Vector2(
                    rbJugador.linearVelocity.x,
                    fuerzaReboteJugador
                );

                if (!enCaparazon)
                {
                    ConvertirEnCaparazon();
                }
                else
                {
                    Destroy(gameObject);
                }
            }
            else
            {
                if (enCaparazon && !caparazonMoviendose)
                {
                    EmpujarCaparazon(collision.transform.position);
                }
                else
                {
                    Debug.Log("Jugador recibió daño");
                }
            }
        }
        else
        {
            direccion *= -1;

            if (!enCaparazon)
                OrientarSprite();
        }
    }

    void ConvertirEnCaparazon()
    {
        enCaparazon = true;
        caparazonMoviendose = false;

        rb.linearVelocity = Vector2.zero;
        sr.sprite = spriteCaparazon;
    }

    void EmpujarCaparazon(Vector3 posicionJugador)
    {
        caparazonMoviendose = true;

        if (posicionJugador.x < transform.position.x)
            direccion = 1;
        else
            direccion = -1;
    }
}