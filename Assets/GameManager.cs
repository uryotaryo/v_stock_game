using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    
    private static GameManager _my_Maneger;
    public static GameManager Get_GameManager(){
        return _my_Maneger;
    }
    private void Await(){
        _my_Maneger = this.GetComponent<GameManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Player_Input.Input_Update();
        
    }
}
public static class Player_Input{
    private static float _mouse_Click_Intabal = 500;
    private static float _mouse_Click_Intabal_Meta;
    public static bool Mouse_Reft_Down = false;
    
    public static bool Mouse_Reft_Up = false;
    
    public static bool Mouse_Reft_Click = false;
    public static void Input_Update(){
        full_false();
        if(Mouse.current.leftButton.isPressed){
            Mouse_Reft_Down = true;
            _mouse_Click_Intabal_Meta -= Time.deltaTime*1000;
        }
        if(Mouse.current.leftButton.wasPressedThisFrame){
            if(_mouse_Click_Intabal_Meta > 0)Mouse_Reft_Click = true;
            _mouse_Click_Intabal_Meta = _mouse_Click_Intabal;
            Mouse_Reft_Up = true;
        }
        /*
        if(_mous_Intabal_meta >= 0){
            _mous_Intabal_meta -= Time.deltaTime;
        }else{
            _mous_Intabal_meta = _mous_Intabal;

        }*/
    }
    private static void full_false(){
        Mouse_Reft_Down = false;
        Mouse_Reft_Up = false;
        Mouse_Reft_Click = false;
    }
}
