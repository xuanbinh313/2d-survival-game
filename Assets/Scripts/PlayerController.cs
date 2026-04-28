using UnityEngine;
using UnityEngine.InputSystem; // Thêm thư viện này

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer spriteRenderer;
    private Vector2 movementInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Hàm này sẽ được gọi từ component Player Input
    public void OnMove(InputValue value)
    {
        movementInput = value.Get<Vector2>();
    }

    void Update()
    {
        // Gán giá trị Speed cho Animator dựa trên đầu vào
        // sqrMagnitude giúp kiểm tra xem có đang nhấn phím di chuyển không
        anim.SetFloat("Speed", movementInput.sqrMagnitude);

        // Lật hình ảnh (Flip)
        if (movementInput.x > 0) spriteRenderer.flipX = false;
        else if (movementInput.x < 0) spriteRenderer.flipX = true;
    }

    void FixedUpdate()
    {
        // Thực hiện di chuyển vật lý
        rb.MovePosition(rb.position + movementInput * moveSpeed * Time.fixedDeltaTime);
    }
}