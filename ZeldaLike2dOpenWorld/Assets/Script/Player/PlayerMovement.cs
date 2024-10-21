using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    private Vector3 horizontalVelocity = Vector3.zero;
    private Vector3 verticalVelocity = Vector3.zero;
    public SpriteRenderer spriteRenderer;
    public Sprite kDown;
    public Sprite kUp;
    public Sprite kRight;
    public Sprite kLeft;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float verticalMovement = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        MovePlayerHorizontal(horizontalMovement);
        MovePlayerVertical(verticalMovement);
    }

    void MovePlayerHorizontal(float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref horizontalVelocity, .05f);
        
    }

    void MovePlayerVertical(float _verticalMovement)
    {
        Vector3 targetVelocity = new Vector2(rb.velocity.x, _verticalMovement);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref verticalVelocity, .05f);
        
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Z)){
            spriteRenderer.sprite=kUp;
        }
        if(Input.GetKeyDown(KeyCode.D)){
            spriteRenderer.sprite=kRight;
        }
        if(Input.GetKeyDown(KeyCode.Q)){
            spriteRenderer.sprite=kLeft;
        }
        if(Input.GetKeyDown(KeyCode.S)){
            spriteRenderer.sprite=kDown;
        }
        if(Input.GetKeyDown(KeyCode.UpArrow)){
            spriteRenderer.sprite=kUp;
        }
        if(Input.GetKeyDown(KeyCode.RightArrow)){
            spriteRenderer.sprite=kRight;
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow)){
            spriteRenderer.sprite=kLeft;
        }
        if(Input.GetKeyDown(KeyCode.DownArrow)){
            spriteRenderer.sprite=kDown;
        }
    }
}
