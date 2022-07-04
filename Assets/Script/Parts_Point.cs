using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class Parts_Point : MonoBehaviour
{
    [SerializeField]
    private static GameObject _left_eye;
    [SerializeField]
    private static GameObject _right_eye;


    public static GameObject Get_Left_Eye()
    {
        if(_left_eye == null)return null;
        return _left_eye;
    }
    public static GameObject Get_Right_Eye(){
        if(_right_eye == null) return null;
        return _right_eye;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
#if UNITY_EDITOR
public class Parts_Point_Editor:Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
    }
}
#endif