using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartHowToPlay : MonoBehaviour
{
    Button button;
    private void Start()
    {
        //コンポーネント取得
        button = GetComponent<Button>();
        //OnClick時に実行するメソッドを登録
        button.onClick.AddListener(()
            => GameManager.Instance.ChangeHowToPlayScene());
    }
}
