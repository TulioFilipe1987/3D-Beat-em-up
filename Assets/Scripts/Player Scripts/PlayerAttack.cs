using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ComboState{ //0,1,2,3,4,5,
    NONE,
    PUNCH_1,
    PUNCH_2,
    PUNCH_3,
    KICK_1,
    KICK_2
}
public class PlayerAttack : MonoBehaviour
{

    private CaractherAnimation player_Anim;

    private bool activeTimerToReset;

    private float default_Combo_Timer = 0.4f;//
    private float current_Combo_Timer;//

    private ComboState current_Combo_State;//chamar o enum

    void Awake(){
        player_Anim = GetComponentInChildren<CaractherAnimation>();
        
    }

    void Start(){
        current_Combo_Timer = default_Combo_Timer; // recebe 0.4
        current_Combo_State = ComboState.NONE; // NONE

    
     }

  
    void Update(){
        ComboAttacks();
        ResetComboState();

        }


    void ComboAttacks(){

        if(Input.GetKeyDown(KeyCode.Z)){ // punch 1

            if(current_Combo_State == ComboState.PUNCH_3 ||
               current_Combo_State == ComboState.KICK_1 ||
               current_Combo_State == ComboState.KICK_2)
               return;

            current_Combo_State++;
            activeTimerToReset = true;
            current_Combo_Timer = default_Combo_Timer;
            //player_Anim.Punch_1();


             

            if(current_Combo_State == ComboState.PUNCH_1){ // punch 1

                player_Anim.Punch_1();
            }

            if (current_Combo_State == ComboState.PUNCH_2)// punch 2
            {
                player_Anim.Punch_2();
            }

            if (current_Combo_State == ComboState.PUNCH_3)// punch 3
            {
                player_Anim.Punch_3();
            }

        }// if punch

        if (Input.GetKeyDown(KeyCode.X))// kick 1
        {
            // if the current combo is punch 3 or kick 2
            // return meaning  exit because we have no combos to perfom
            if (current_Combo_State == ComboState.KICK_2 ||
                current_Combo_State == ComboState.PUNCH_3)
                return;

            // if the current combo state is NONE or Punch1 or punch2
            // then we can set current combo state to kick1 to chain the combo
            if(current_Combo_State == ComboState.NONE ||
               current_Combo_State == ComboState.PUNCH_1 ||
               current_Combo_State == ComboState.PUNCH_2){

                current_Combo_State = ComboState.KICK_1;

            }else if (current_Combo_State == ComboState.KICK_1){
                // move to kick2
                current_Combo_State++;// Vai para o combo KICK_2

            }

            activeTimerToReset = true;
            current_Combo_Timer = default_Combo_Timer;

            if(current_Combo_State == ComboState.KICK_1){
                player_Anim.Kick_1();
            }

            if(current_Combo_State == ComboState.KICK_2){
                player_Anim.Kick_2();

            }

        }// if kick

    
    }// COMBO ATTACKS

    void ResetComboState(){ // o que é isso?

        if (activeTimerToReset){

            current_Combo_Timer -= Time.deltaTime;

            if(current_Combo_Timer <= 0f)
            {// o que é isso?

                current_Combo_State = ComboState.NONE;

                activeTimerToReset = false;
                current_Combo_Timer = default_Combo_Timer;// depois ele recebe valor 0.4


            }
        
        
        }


    }// reset combo state



}// class
