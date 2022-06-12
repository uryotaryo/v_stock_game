using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraMove : MonoBehaviour
{
    private Camera myCamera;
    [SerializeField]
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        myCamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!EventSystem.current.IsPointerOverGameObject()){
            GameObject hit_obj;
            Ray ray = myCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit_info = new RaycastHit();
            float max_distance = 100f;
            bool is_hit = Physics.Raycast(ray, out hit_info, max_distance); 
            
            if (is_hit) {
                if(Player_Input.Mouse_Reft_Click){   
                    if(hit_info.transform.tag == "Stage_Box"){
                        hit_info.transform.GetComponent<StagePropaty>().Hit();
                    }else{
                        hit_obj = hit_info.transform.gameObject;
                        Debug.Log(hit_obj);
                    } 
                }
            }
        }
        var mous = Input.mouseScrollDelta;
        var pos = this.transform.position;
        pos += this.transform.forward * mous.y * speed;
        if(pos.y <= 5)return;
        this.transform.position = pos;
    }
}
