using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


/// <summary>
/// 3人称メニュー管理プロパティ
/// </summary>
public class MenuProperties : MonoBehaviour
{
    //表示するメニュー
    [SerializeField]
    private GameObject Show_Menu_Obj;    
    //親オブジェクト
    private GameObject Parent_Obj;
    //メニュータイプ
    [SerializeField]
    private Type thistype;
    public enum Type{
        akt = 0,
        speek = 1,
    }
    /// <summary>
    /// 自分のメニュータイプを返す
    /// </summary>
    /// <returns>メニュータイプ</returns>
    public Type Get_Type(){
        return thistype;
    }
    // Start is called before the first frame update
    void Start()
    {
        //親オブジェクトを格納する
        Parent_Obj = this.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }
    /// <summary>
    /// 選択チェック
    /// </summary>
    /// <returns>選択されたとき:true</returns>
    public bool Select_Check(){
        //親オブジェクトが無かった場合処理を留める
        if(Parent_Obj == null)return false;
        var t_pos = this.GetComponent<RectTransform>().localPosition;
        var select_size = Parent_Obj.GetComponent<RectTransform>().sizeDelta;
        //親の中心から幅3分の１の範囲にいれば選択されたことにする
        if(Vector2.Distance(new Vector2(t_pos.x,t_pos.y),Vector2.zero) <= select_size.x /3){
            if(GameObject.FindWithTag("FPS_canvas") == null)prot_only();

            return true;
        }
        else return false;
    }
        
    private void prot_only(){
        GameManager.Get_Player().Cam_Change();
        GameObject.FindWithTag("FPS_canvas").GetComponent<Real_Time_Cont>().Set_Q(Conversation.Dict_Q["2"]);
    }
}
