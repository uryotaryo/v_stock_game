using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Result_UI : MonoBehaviour
{
    public void End_Game(){
#if UNITY_EDITOR
        //エディタ終了
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        //スタンドアロン終了
        UnityEngine.Application.Quit();
    }
    public void To_Title(){
        SceneManager.LoadScene("Title");
    }
}
