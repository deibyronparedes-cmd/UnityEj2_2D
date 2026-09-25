using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField] private float moveSpeed = 5f;

    [Header("Referencias")]
    [SerializeField] private SpriteRenderer spriteRenderer; // opcional, para flip

    private Rigidbody2D rb;
    private float horizontalInput;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        if (spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Lee el input horizontal (A/D o flechas izquierda/derecha)
        horizontalInput = Input.GetAxisRaw("Horizontal");

        // Voltea el sprite según la dirección
        if (spriteRenderer != null && horizontalInput != 0f)
        {
            spriteRenderer.flipX = horizontalInput < 0f;
        }
    }

    void FixedUpdate()
    {
        // Mueve al personaje en el eje X, conservando la velocidad vertical (gravedad, saltos, etc.)
        rb.linearVelocity = new Vector2(horizontalInput * moveSpeed, rb.linearVelocity.y);
    }
}
