using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    Rigidbody2D rb;
    Vector2 dir;
    Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        dir.x = Input.GetAxisRaw("Horizontal");
        dir.y = Input.GetAxisRaw("Vertical");
        rb.MovePosition(rb.position + dir * speed * Time.fixedDeltaTime);
        
        SetParam();
    }

    void SetParam(){
        if(dir.x == 0 && dir.y == 0) //idle
        {
            anim.SetInteger("dir", 0);
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if(dir.x > 0) //right side
        {
            anim.SetInteger("dir", 2);
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if(dir.x < 0) //left side
        {
            anim.SetInteger("dir", 2);
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if(dir.y > 0) //up side
        {
            anim.SetInteger("dir", 1);
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if(dir.y < 0) //down side
        {
            anim.SetInteger("dir", 3);
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }
}
