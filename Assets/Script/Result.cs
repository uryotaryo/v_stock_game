using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Result : MonoBehaviour
{
    private int move_num = 0;
    private Vector3[] S_Point = {
        new Vector3(0,0.8f,-7f),
        new Vector3(0,0.8f,1f),
        new Vector3(0,4f,1.5f)
    };
    private Vector3[] E_Point = {
        new Vector3(0,0.8f,1f),
        new Vector3(0,0.8f,-7),
        new Vector3(0,1f,-3)
    };
    [SerializeField]
    private GameObject Move_Camera;
    [SerializeField]
    private GameObject Result_Camera;
    [SerializeField]
    private GameObject Meta_ResultNPC;
    private float S_To_E_D = 0;
    private bool Move_Stop = false;

    private void OnEnable(){
        for(int i = 0; i < 12;i++){
            var v = Instantiate(Meta_ResultNPC,Vector3.zero,new Quaternion(0,0,0,0));
            v.GetComponent<Result_NPC>().Pop_NPC_OBj(i);
        }
        GameManager.Get_GameManager().Game_Scenes = GameManager.Scenes.Result;
    }

    // Update is called once per frame
    void Update()
    {
        Camera_Move();
        if(!Move_Stop)return;
        Move_Camera.SetActive(false);
        Result_Camera.SetActive(true);
        
    }
    private void Camera_Move(){
        if(move_num >= E_Point.Length){
            Move_Stop = true;
            GameManager.Get_GameManager().Game_Scenes = GameManager.Scenes.Stop;
            return;
        }
        S_To_E_D += 0.0022f;
        Move_Camera.transform.position =  Vector3.Lerp(S_Point[move_num],E_Point[move_num],S_To_E_D);
        if(Move_Camera.transform.position == E_Point[move_num]){
            move_num ++;
            S_To_E_D = 0;
        }
        switch(move_num){
            case 0:
                Move_Camera.transform.eulerAngles = new Vector3(0,-90,0);
                return;
            case 1:
                Move_Camera.transform.eulerAngles = new Vector3(0,90,0);
                return;
            case 2:
                Move_Camera.transform.eulerAngles = new Vector3(-20,0,0);
                return;
        }
    }
}
