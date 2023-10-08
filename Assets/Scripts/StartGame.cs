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
        //コンポーネント取得
        button = GetComponent<Button>();
        audioSource = GetComponent<AudioSource>();
        //OnClick時に実行するメソッドを登録
        button.onClick.AddListener(()
             => SceneManager.LoadScene("LoadScene"));
        //audioSource.PlayOneShot(audioSource.clip);
        //=> GameManager.Instance.ChangeGameScene());
    }
}
