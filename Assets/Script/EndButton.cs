using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //�����ꂽ��Q�[���I������֐�
    public void Endgame()
    {
        //�G�f�B�^�I��
        UnityEditor.EditorApplication.isPlaying = false;

        //�X�^���h�A�����I��
        UnityEngine.Application.Quit();
    }
}
