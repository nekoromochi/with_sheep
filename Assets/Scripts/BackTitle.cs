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
        ////最初にボタンをクリックされている状態にしておく
        //button = GameObject.Find("Canvas/Image/ButtonSummary/Button1").GetComponent<Button>();
        ////ボタンが選択された状態になる
        //button.Select();
        {            
            //OnClick時に実行するメソッドを登録
            button.onClick.AddListener(()
                => SceneManager.LoadScene("TitleScene"));
        }
    }
}
