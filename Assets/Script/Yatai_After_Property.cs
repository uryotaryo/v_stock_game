using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yatai_After_Property : MonoBehaviour
{
    [SerializeField]
    private GameObject[] after_frames = new GameObject[3];
    [SerializeField]
    private facing_direction YATAI_Facing = facing_direction.NO_X;
    private enum facing_direction{
        NO_X = 0,
        X = 180,
        NO_Z = 90,
        Z = 210,
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.GetChild(0).GetChild(0) == null) return;
        this.transform.GetChild(0).GetChild(0).eulerAngles =  new Vector3(0,(float)YATAI_Facing,0);
    }
    public void Set_Result(int level){
        Child_All_Destroy();
        if(level >= 4||level <= 0){
            this.enabled = false;
            return;
        }
        var g = Instantiate(after_frames[level]);
        g.transform.SetParent(this.transform.GetChild(0));
        g.transform.localPosition = Vector3.zero;
        g.transform.eulerAngles = new Vector3(0,(float)YATAI_Facing,0);
        g.transform.localScale = new Vector3(0.5f,0.5f,0.5f);
        
    }
    private void Child_All_Destroy(){
        for (int i = this.transform.GetChild(0).childCount;i > 0;i--){
            Destroy(this.transform.GetChild(0).GetChild(0).gameObject,0f);
        }
    }
}
