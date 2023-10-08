using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private AudioClip titleBGM;
    [SerializeField] private AudioClip gamePlayingBGM;
    [SerializeField] private AudioClip gameOverSE;
    [SerializeField] private AudioClip gameClearSE;
    [SerializeField] private float restartTime;
    [SerializeField] private float clearTime;

    // コンポーネント取得用
    private AudioSource audioSource;

    #region　シングルトン記述
    public static GameManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            // staticインスタンスに自身のゲームオブジェクトを代入
            Instance = this;

            // このゲームオブジェクトを破壊しない
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            // 既に存在しているなら他を削除(1つのみ存在)
            Destroy(gameObject);
        }
    }
    #endregion
    private void Start()
    {
        //コンポーネント取得
        audioSource = GetComponent<AudioSource>();

        //デバッグ用処理
        //本来はTitleSceneから始まるが、デバッグのためGameSceneから始まるパターンを用意
        if (SceneManager.GetActiveScene().name == "TitleScene")
        {
            //ステート設定
            state = States.Title;

            //BGM切り替え&再生
            audioSource.clip = titleBGM;
            audioSource.Play();
        }
        else if (SceneManager.GetActiveScene().name == "InGameScene")
        {
            //ステート設定
            state = States.GamePlaying;

            //BGM切り替え&再生
            audioSource.clip = gamePlayingBGM;
            audioSource.Play();

        }
    }

    private void Update()
    {
        switch (state)
        {
            case States.Title:
                break;
            case States.HowToPlay:
                break;
            case States.GamePlaying:
                // Pボタンが押されたときにポーズ
                if (Input.GetKeyUp(KeyCode.P)
                    ||
                   Input.GetKeyUp(KeyCode.Escape))
                {
                    GamePause();
                }
                break;
            case States.GamePause:
                break;
            case States.GameOver:
                break;
            case States.GameClear:
                break;
            //その他の処理はdefault
            default:
                break;
        }
        // Escキーにてゲーム終了
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameQuit();
        }
    }

    // ゲームステート
    public enum States
    {
        Title,
        HowToPlay,
        GamePlaying,
        GamePause,
        GameOver,
        GameClear,
    }
    public States state = States.Title;

    // ゲームオーバー処理
    public void GameOver()
    {
        state = States.GameOver;

        // ゲームオーバーSE
        audioSource.PlayOneShot(gameOverSE);

        //リスタートさせる
        Invoke(nameof(Restart), restartTime);
    }

    // ゲームクリア処理
    public void GameClear()
    {
        state = States.GameClear;

        // ゲームクリアSE
        audioSource.PlayOneShot(gameClearSE);
        //リスタートさせる
        Invoke(nameof(ChangeTitleScene), clearTime);
    }


    // リスタート処理
    private void Restart()
    {
        state = States.GamePlaying;

        SceneManager.LoadScene("GameScene");
    }

    public void ChangeHowToPlayScene()
    {
        //ステートを変更
        state = States.HowToPlay;

        //HowToPlaySceneへ遷移
        SceneManager.LoadScene("HowToPlayScene");
    }
    public void ChangeGameScene()
    {
        //ステートを変更
        state = States.GamePlaying;

        //BGM切り替え&再生
        audioSource.clip = gamePlayingBGM;
        audioSource.Play();

        //GameSceneへ遷移
        SceneManager.LoadScene("GameScene");
    }

    public void ChangeTitleScene()
    {
        //ステートを変更
        state = States.Title;

        //再開
        Time.timeScale = 1f;

        //BGM切り替え&再生
        audioSource.clip = titleBGM;
        audioSource.Play();

        //TitleSceneへ遷移
        SceneManager.LoadScene("TitleScene");
    }
    public void GamePause()
    {
        //ステート変更
        state = States.GamePause;

        //ポーズ
        Time.timeScale = 0f;
    }
    //Time.timeScaleについて
    //Updateは動く FixedUpdateは止まる
    public void GameResume()
    {
        //ステート変更
        state = States.GamePlaying;

        //再開
        Time.timeScale = 1f;
    }

    public void GameQuit()
    {
        Application.Quit();
    }
}
