using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllor : MonoBehaviour
{
    public static PlayerControllor instance {get; private set;}

    float speed = 4.0f;
    public Animator animator;
    Rigidbody2D rbody;
    public float moveX, moveY;
    
    public bool canMove = true;

    public Vector2 lookDirection = new Vector2(0,-1);

    private AudioSource footstepAudio;

    public string scenePW; //记录场景密钥，防止进入其他场景时出生位置出错

    public List<Quest> questList = new List<Quest>(); //玩家任务列表，储存玩家现有的任务信息


    void Awake(){
        if (instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        footstepAudio = transform.GetComponent<AudioSource>(); //添加AudioSource组件， 获取组件
    }



    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");

        Vector2 moveVec = new Vector2(moveX, moveY);
        if ((moveVec.x != 0 || moveVec.y != 0) && canMove == true){
            lookDirection = moveVec;    //更改角色朝向

            if(!footstepAudio.isPlaying){
                footstepAudio.Play();   //如果脚步声没在播放，播放脚步声
            }
        }
        else{
            footstepAudio.Stop();   //角色停止走路时，如果在播放脚步声，就停止播放
        }
        
        

        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Magnitude", moveVec.magnitude);
    }

    void FixedUpdate()
    {
        if(canMove){
            rbody.velocity = new Vector2(moveX * speed, moveY * speed);
        }
        else{
            rbody.velocity = Vector2.zero;
        }
    }
    
}
