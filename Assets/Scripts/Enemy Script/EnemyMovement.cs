using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour{

    private CaractherAnimation enemyAnim; // Go call the other script

    private Rigidbody myBody;
    public float speed = 5f;

    private Transform playerTarget;// recebe a tag

    public float attack_Distance = 1f;
    private float chase_Player_After_Attack = 1f;// perseguir o jogador apos o attack

    private float current_Attack_time;
    private float default_Attack_Time = 2f;


    private bool followPlayer, attackPlayer;
     
    void Awake(){
        enemyAnim = GetComponentInChildren<CaractherAnimation>();
        myBody = GetComponent<Rigidbody>();

        playerTarget = GameObject.FindWithTag(Tags.PLAYER_TAG).transform; // joga no transform
    }
    void Start(){
        followPlayer = true;
        current_Attack_time = default_Attack_Time;
    }

    void Update()
    {
        
        Attack();
    }

    void FixedUpdate()
    {
        FollowTarget();
    }

    void FollowTarget(){

        if (!followPlayer)
            return;

        if(Vector3.Distance(transform.position, playerTarget.position) > attack_Distance){


            transform.LookAt(playerTarget);
            myBody.velocity = transform.forward * speed;

            if(myBody.velocity.sqrMagnitude != 0){ // o que é : sqrMagnitud ?
                enemyAnim.Walk(true);
            }

        }else if (Vector3.Distance(transform.position, playerTarget.position) <= attack_Distance){

            myBody.velocity = Vector3.zero;
            enemyAnim.Walk(false);

            followPlayer = false;
            attackPlayer = true;
        }

    }//  follow target

    void Attack() {

        // if we should Not attack the player
        // exit the function
        if (!attackPlayer)
            return;

        current_Attack_time += Time.deltaTime;

        if(current_Attack_time > default_Attack_Time){
            enemyAnim.EnemyAttacck(Random.Range(0, 3));//0,1/2


            current_Attack_time = 0f;
        }

        if(Vector3.Distance(transform.position, playerTarget.position) >
            attack_Distance + chase_Player_After_Attack)
        {
            attackPlayer = false;
            followPlayer = true;

        }


    }// attack
    

}// claas
