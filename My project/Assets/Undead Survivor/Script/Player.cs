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

    private void LateUpdate() // 프레임 종료 전 실행되는 생명주기 함수
    {
        if (inputVec.x != 0) // x축 관련 키를 눌렀을 때
        {
            // - 방향인게 참인경우 true, 거짓이면 false -> 방향에 따라 캐릭터가 바라보는 방향 변경
            spriter.flipX = inputVec.x < 0; 
        }


        anim.SetFloat("Speed", inputVec.magnitude); // inputVec의 크기를 받아와서 Speed로 지정함
    }
}
