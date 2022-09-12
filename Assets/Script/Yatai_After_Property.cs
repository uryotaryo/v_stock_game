using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Yatai_After_Property : MonoBehaviour
{
    [SerializeField]
    private GameObject[] after_frames = new GameObject[3];
    [SerializeField]
    private facing_direction YATAI_Facing = facing_direction.NO_X;
    private GameObject _visual_obj;
    private enum facing_direction{
        NO_X = 0,
        X = 180,
        NO_Z = 90,
        Z = 210,
    }

    // Start is called before the first frame update
    void Start()
    {
        _visual_obj = this.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(_visual_obj.transform.childCount <= 0)return;
        this.transform.GetChild(0).GetChild(0).eulerAngles =  new Vector3(0,(float)YATAI_Facing,0);
    }
    public void Set_Result(int level){
        Child_All_Destroy();
        if(level >= 4||level <= 0){
            this.gameObject.SetActive(false);
            return;
        }
        var g = Instantiate(after_frames[level-1]);
        g.transform.SetParent(_visual_obj.transform);
        g.transform.localPosition = Vector3.zero;
        g.transform.eulerAngles = new Vector3(0,(float)YATAI_Facing,0);
        g.transform.localScale = new Vector3(0.5f,0.5f,0.5f);
        
    }
    private void Child_All_Destroy(){
        for (int i = _visual_obj.transform.childCount;i > 0;i--){
            Destroy(_visual_obj.transform.GetChild(0).gameObject,0f);
        }
    }
}
