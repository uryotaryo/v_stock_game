using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
/// <summary>
/// 3人称用メニューUI管理
/// </summary>
public class MenuMeta : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    // ドラッグ前の位置
    private Vector3 _prevpos;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// ドラッグが始まった時
    /// </summary>
    /// <param name="eventData"></param>
    public void OnBeginDrag(PointerEventData eventData)
    {
        // ドラッグ前の位置を記憶しておく
        _prevpos = transform.localPosition;
    }
    /// <summary>
    /// ドラッグ中
    /// </summary>
    /// <param name="eventData"></param>
    public void OnDrag(PointerEventData eventData)
    {
        //左ボタンが押されていなければ処理をここで止める
        if(!Input.GetMouseButton(0))return;
        //UIの位置をマウスに追従させる
        transform.position = new Vector3(eventData.position.x,eventData.position.y,0);
    }
    /// <summary>
    /// ドラッグ後
    /// </summary>
    /// <param name="eventData"></param>
    public void OnEndDrag(PointerEventData eventData)
    {
        if(this.GetComponent<MenuProperties>().Select_Check()){
            if(this.GetComponent<MenuProperties>().Get_Type() == MenuProperties.Type.akt){
                Debug.Log("アクションコミュニケーションが選択された");
            }
            if(this.GetComponent<MenuProperties>().Get_Type() == MenuProperties.Type.speek){
                Debug.Log("会話コミュニケーションが選択された");
            }
        }
        // ドラッグ前の位置に戻す
        transform.localPosition = _prevpos;
    }
}
