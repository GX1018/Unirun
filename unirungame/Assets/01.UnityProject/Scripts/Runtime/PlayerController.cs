using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const float PLAYER_STEP_ON_Y_ANGLE_MIN = 0.7f;  //! <45도
    
    public AudioClip deathSound = default;
    public float jumpForce = default;

    private int jumpCount = default;
    private bool isGrounded = false;
    private bool isDead = false;

    #region  Player's Component
    private Rigidbody2D playerRigid =default;
    private Animator playerAni = default;
    private AudioSource playerAudio = default;
    #endregion  //Player's Component
    
    void Start()
    {
        playerRigid = gameObject.GetComponentMust<Rigidbody2D>();
        playerAni = gameObject.GetComponentMust<Animator>();
        playerAudio = gameObject.GetComponentMust<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if(isDead){return;}

        //{ 플레이어 점프 중인 로직 
        if(Input.GetMouseButtonDown(0)&& jumpCount<2){
            jumpCount++;
            playerRigid.velocity =Vector2.zero;
            playerRigid.AddForce(new Vector2(0, jumpForce));
            playerAudio.Play();
        }
        
        else if (Input.GetMouseButtonUp(0)&&playerRigid.velocity.y>0){
            playerRigid.velocity = playerRigid.velocity*0.5f;
        }

        playerAni.SetBool("Grounded", isGrounded);
        //} 플레이어 점프 중인 로직


        // 점프 중이 아닐 때 그라운드에서 사용할 로직


    }

    //! Player Die

    private void Die()
    {
        playerAni.SetTrigger("Die");
        playerAudio.clip = deathSound;
        playerAudio.Play();

        playerRigid.velocity = Vector2.zero;
        isDead = true;
    }

    //! 트리거 충돌 감지 처리를 위한 함수
    private void OntriggerEnter2D(Collider2D collision)
    {
        if(collision.tag.Equals("Deadzone")&& isDead ==false){
            Die();
        }
    }

    //! 바닥에 닿았는지 체크하는 함수
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(PLAYER_STEP_ON_Y_ANGLE_MIN < collision.contacts[0].normal.y){
            isGrounded = true;
            jumpCount =0;
        }
    }

    //! 바닥에서 벗어났는지 체크하는 함수
    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded =false;
    }
}
