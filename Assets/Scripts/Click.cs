using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Choice : MonoBehaviour
{
    Button button;

    void Start()
    {
        //�ŏ��Ƀ{�^�����N���b�N����Ă����Ԃɂ��Ă���
        button = GameObject.Find("Canvas/Image/ButtonSummary/Button1").GetComponent<Button>();
        //�{�^�����I�����ꂽ��ԂɂȂ�
        button.Select();

    }
}