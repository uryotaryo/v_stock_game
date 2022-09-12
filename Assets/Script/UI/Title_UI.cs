using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Title_UI : MonoBehaviour
{
    public void Start_Button_Click()
    {
        SceneManager.LoadScene("New_Game_Prot");
    }    
    public void End_Button_Click()
    {        
#if UNITY_EDITOR
        //エディタ終了
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        //スタンドアロン終了
        UnityEngine.Application.Quit();
    }
}
