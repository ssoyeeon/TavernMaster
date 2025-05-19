using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMove : MonoBehaviour
{
    private float moveSpeed = 5f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Movement();
    }

    public void Movement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(horizontal, vertical);

        rb.velocity = movement * moveSpeed;

        //고정으로 바꾸기
        if (Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if(Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    //땅인거 먼저 체크하고 할거야 아니면 요기 함수 안에서 체크할고야?
    public void Homi()
    {
        
    }

    public void Water()
    {

    }

}
