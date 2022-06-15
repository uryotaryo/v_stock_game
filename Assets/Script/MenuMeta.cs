using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class MenuMeta : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private Vector3 _prevpos;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        // ドラッグ前の位置を記憶しておく
        _prevpos = transform.localPosition;
    }
    public void OnDrag(PointerEventData eventData)
    {
        if(!Player_Input.Mouse_Reft_Down)return;
        transform.position = new Vector3(eventData.position.x,eventData.position.y,0);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(this.GetComponent<MenuProperties>().Select_Check()){
            if(this.GetComponent<MenuProperties>().Get_Type() == MenuProperties.Type.akt){
                Debug.Log("アクションコミュニケーションが選択された");
            }
            if(this.GetComponent<MenuProperties>().Get_Type() == MenuProperties.Type.speek){
                Debug.Log("会話コミュニケーションが選択された");
                prot();

            }
        }
        // ドラッグ前の位置に戻す
        transform.localPosition = _prevpos;
    }
    private void prot(){
        if(GameObject.FindWithTag("Player").GetComponent<Player>().Get_Point() != prot_cont.NPC_pos)return;
        prot_NPC_cont.Move_Start();
    }
}
