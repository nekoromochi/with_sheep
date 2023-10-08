using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Choice : MonoBehaviour
{
    Button button;

    void Start()
    {
        //最初にボタンをクリックされている状態にしておく
        button = GameObject.Find("Canvas/Image/ButtonSummary/Button1").GetComponent<Button>();
        //ボタンが選択された状態になる
        button.Select();

    }
}