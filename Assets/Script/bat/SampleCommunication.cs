using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SampleCommunication : MonoBehaviour
{
    //Text�����B���������啶��
    //NPC������e�L�X�g
    public Text NPCText;

    //Player�̑I�����̃e�L�X�g
    public Text Choices1;
    public Text Choices2;
    public Text Choices3;
    public Text Choices4;

    //Text�̃I�u�W�F�N�g�B��������������
    //NPC��Text�̃I�u�W�F�N�g
    public GameObject NPCtext;

    //Player�̑I�����̃I�u�W�F�N�g
    public GameObject choices1;
    public GameObject choices2;
    public GameObject choices3;
    public GameObject choices4;



    // Start is called before the first frame update
    void Start()
    {
        NPCtext.SetActive(false);
        choices1.SetActive(false);
        choices2.SetActive(false);
        choices3.SetActive(false);
        choices4.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //�T���v���ōŏ��ɌĂяo��
    public void Communication()
    {
        //NPC�̃R�����g���������Ĕ���
        NPCtext.SetActive(true);
        NPCText.text = "�ǂ������́H";

        //NPC�̔�����A�Ԋu���󂯂đI��������������
        Invoke("Choose0", 1.0f);
    }

    //�I��������
    void Choose0 ()
    {
        //�I�������������A���e����������
        choices1.SetActive(true);
        Choices1.text = "�v��";

        choices2.SetActive(true);
        Choices2.text = "���Ԙb";

        choices3.SetActive(true);
        Choices3.text = "���ɂȂ�";
    }

}
