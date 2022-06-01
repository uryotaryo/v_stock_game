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
        var mous = Input.mouseScrollDelta;
        mycamera.fieldOfView += mous.y * speed;
        
    }
}
