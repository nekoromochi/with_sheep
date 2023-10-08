using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    Button button;
    AudioSource audioSource;
    private void Start()
    {
        //�R���|�[�l���g�擾
        button = GetComponent<Button>();
        audioSource = GetComponent<AudioSource>();
        //OnClick���Ɏ��s���郁�\�b�h��o�^
        button.onClick.AddListener(()
             => SceneManager.LoadScene("LoadScene"));
        //audioSource.PlayOneShot(audioSource.clip);
        //=> GameManager.Instance.ChangeGameScene());
    }
}
