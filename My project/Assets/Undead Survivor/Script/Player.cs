using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Vector2 inputVec;
    public float speed;

    Rigidbody2D rigid;
    SpriteRenderer spriter;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame

     void FixedUpdate() // 물리 연산 프레임마다 호출되는 생명주기 함수
    {
        //1. 힘을줘서 밀기
        //rigid.AddForce(inputVec);

        //2. 속도제어
        //rigid.velocity = inputVec;

        //3. 위치 이동(순간이동 형식, 현재위치에 Vector를 더하는 방식)
        Vector2 nextVec = inputVec * speed * Time.fixedDeltaTime; // 물리 프레임 하나당 소모된 시간
        rigid.MovePosition(rigid.position + nextVec);

    }

    void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }

    void LateUpdate()
    {
        anim.SetFloat("Speed", inputVec.magnitude);

        if (inputVec.x != 0)
        {
            spriter.flipX = inputVec.x < 0;
        }
    }
}
