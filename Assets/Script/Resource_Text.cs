using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resource_Text : MonoBehaviour
{
    //���ނ̏�������
    public int resource_percent;

    //���ނ̖��O
    public string resouce_name;

    //�\������Text�̃I�u�W�F�N�g�������ɓ����
    public Text resouce_text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //���ނ̖��O�F�����������ŕ\������
        resouce_text.text = string.Format("{0}:{1}%",resouce_name,resource_percent);
    }
}
