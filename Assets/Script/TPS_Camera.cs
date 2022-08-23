using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TPS_Camera : MonoBehaviour
{
    [SerializeField]
    private Player _pm;
    [SerializeField]
    private float wheel_speed;
    private Camera _t_c;
    // Start is called before the first frame update
    void Start()
    {
        _t_c = this.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_pm == null)return;
        if(!EventSystem.current.IsPointerOverGameObject()){
            Ray ray = _t_c.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit_info = new RaycastHit();
            float max_distance = 100f;
            bool is_hit = Physics.Raycast(ray, out hit_info, max_distance); 
            //何かしらのオブジェクトに触れたら処理を行う
            if (is_hit) {
                if(Input.GetMouseButtonDown(0)){
                    _pm.Set_Target(hit_info.point);
                }
            }
        }
        
        //マウスホイールがスクロールされたときにカメラを前後に動かす
        Vector2 mouse_pos = Input.mouseScrollDelta;
        var pos = this.transform.position;
        pos += this.transform.forward * mouse_pos.y * wheel_speed;
        if(pos.y <= 5 || pos.y >= 10)return;
        this.transform.position = pos;
    }
}
