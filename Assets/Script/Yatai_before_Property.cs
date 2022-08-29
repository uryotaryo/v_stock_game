using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yatai_before_Property : MonoBehaviour
{
    [SerializeField]
    private GameObject[] before_frames = new GameObject[4];
    [SerializeField,Range(0,3)]
    private int now_level;
    private Yatai_After_Property _after_class;
    private List<List<Task>> All_Task = new List<List<Task>>();
    // Start is called before the first frame update
    void Start()
    {
        _after_class = this.GetComponent<Yatai_After_Property>();
        _after_class.enabled = false;
        this.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
        if(before_frames[0] == null) return;
        Child_All_Destroy();
        var g = Instantiate(before_frames[0]);
        g.transform.SetParent(this.transform.GetChild(0)); 
        g.transform.localPosition = Vector3.zero;
        g.transform.localScale = new Vector3(0.5f,0.5f,0.5f);
    }
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P)){
            if(now_level >= 3)return;
            now_level++;
                
            Child_All_Destroy();
            var g = Instantiate(before_frames[now_level]);
            g.transform.SetParent(this.transform.GetChild(0));
            g.transform.localPosition = Vector3.zero;
            g.transform.localScale = new Vector3(0.5f,0.5f,0.5f);
        }
        if(Input.GetKeyDown(KeyCode.C)){
            _after_class.enabled = true;
            _after_class.Set_Result(now_level);
            this.GetComponent<Yatai_before_Property>().enabled = false;
        }
    }
    private void Child_All_Destroy(){
        for (int i = this.transform.GetChild(0).childCount;i > 0;i--){
            Destroy(this.transform.GetChild(0).GetChild(0).gameObject,0f);
        }
    }
}
