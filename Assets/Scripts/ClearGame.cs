using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClearGame : MonoBehaviour
{
    Button button;
    private void Start()
    {
        //�R���|�[�l���g�擾
        button = GetComponent<Button>();
        //OnClick���Ɏ��s���郁�\�b�h��o�^
        button.onClick.AddListener(()
             => SceneManager.LoadScene("ClearScene"));
    }
}
