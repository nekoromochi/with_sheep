using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackTitle : MonoBehaviour
{
    Button button;
    private void Start()
    {
        button = GetComponent<Button>();
        ////�ŏ��Ƀ{�^�����N���b�N����Ă����Ԃɂ��Ă���
        //button = GameObject.Find("Canvas/Image/ButtonSummary/Button1").GetComponent<Button>();
        ////�{�^�����I�����ꂽ��ԂɂȂ�
        //button.Select();
        {            
            //OnClick���Ɏ��s���郁�\�b�h��o�^
            button.onClick.AddListener(()
                => SceneManager.LoadScene("TitleScene"));
        }
    }
}
