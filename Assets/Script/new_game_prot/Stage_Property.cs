using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_Property : MonoBehaviour
{
    [SerializeField]
    private GameObject meta_obj;
    [SerializeField]
    private GameObject first_obj;
    [SerializeField]
    private GameObject second_obj;
    [SerializeField]
    private GameObject third_obj;
    
    private MeshRenderer _mesh_render;
    private MeshFilter _mesh_filter;
    private void OnValidate(){
        if(meta_obj == null)return;
        _mesh_render = transform.Find("Visual_Obj").GetComponent<MeshRenderer>();
        _mesh_filter = transform.Find("Visual_Obj").GetComponent<MeshFilter>();
        _mesh_render.materials = meta_obj.GetComponent<MeshRenderer>().materials;
        _mesh_filter.mesh = meta_obj.GetComponent<MeshFilter>().mesh; 
    
    }
    // Start is called before the first frame update
    void Start()
    {
        _mesh_render = transform.Find("Visual_Obj").GetComponent<MeshRenderer>();
        _mesh_filter = transform.Find("Visual_Obj").GetComponent<MeshFilter>();
        if(meta_obj == null) return;
        _mesh_render.materials = meta_obj.GetComponent<MeshRenderer>().materials;
        _mesh_filter.mesh = meta_obj.GetComponent<MeshFilter>().mesh; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider c){

    }
}
