using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    public float velocidad = 5f;
    public float fuerzaSalto = 7f;

    public Sprite spriteIdle;
    public Sprite spriteSalto;
    public Sprite[] spritesCaminar;
    public float velocidadAnimacion = 0.15f;

    public Transform detectorSuelo;
    public float radioDeteccion = 0.15f;
    public LayerMask capaSuelo;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private bool enSuelo;

    private int frameActual = 0;
    private float timerAnimacion;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        enSuelo = Physics2D.OverlapCircle(detectorSuelo.position, radioDeteccion, capaSuelo);

        float mover = Input.GetAxisRaw("Horizontal");

        rb.linearVelocity = new Vector2(mover * velocidad, rb.linearVelocity.y);

        if (mover > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (mover < 0)
            transform.localScale = new Vector3(-1, 1, 1);

        if (Input.GetKeyDown(KeyCode.Space) && enSuelo)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, fuerzaSalto);
        }

        if (!enSuelo)
        {
            sr.sprite = spriteSalto;
        }
        else if (Mathf.Abs(mover) > 0.1f)
        {
            AnimarCaminar();
        }
        else
        {
            sr.sprite = spriteIdle;
        }
    }

    void AnimarCaminar()
    {
        if (spritesCaminar.Length == 0) return;

        timerAnimacion += Time.deltaTime;

        if (timerAnimacion >= velocidadAnimacion)
        {
            timerAnimacion = 0f;
            frameActual++;

            if (frameActual >= spritesCaminar.Length)
                frameActual = 0;

            sr.sprite = spritesCaminar[frameActual];
        }
    }
}