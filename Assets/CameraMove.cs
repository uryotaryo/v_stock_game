using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private Camera mycamera;
    [SerializeField]
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        mycamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject hit_obj;
        if(Player_Input.Mouse_Reft_Click){
            
            Ray ray = mycamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit_info = new RaycastHit();
            float max_distance = 100f;

            bool is_hit = Physics.Raycast (ray, out hit_info, max_distance); 
            if (is_hit) {
                if(hit_info.transform.tag == "Stage_Box"){
                    hit_info.transform.GetComponent<StagePropaty>().Hit();
                }else{
                    hit_obj = hit_info.transform.gameObject;
                    Debug.Log(hit_obj);
                }
            }   
        }

        var mous = Input.mouseScrollDelta;
        var pos = this.transform.position;
        pos += this.transform.forward * mous.y * speed;
        Debug.Log(pos);
        if(pos.y <= 5)return;
        this.transform.position = pos;
    }
}
