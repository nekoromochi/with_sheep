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

    // �R���|�[�l���g�擾�p
    private AudioSource audioSource;

    #region�@�V���O���g���L�q
    public static GameManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            // static�C���X�^���X�Ɏ��g�̃Q�[���I�u�W�F�N�g����
            Instance = this;

            // ���̃Q�[���I�u�W�F�N�g��j�󂵂Ȃ�
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            // ���ɑ��݂��Ă���Ȃ瑼���폜(1�̂ݑ���)
            Destroy(gameObject);
        }
    }
    #endregion
    private void Start()
    {
        //�R���|�[�l���g�擾
        audioSource = GetComponent<AudioSource>();

        //�f�o�b�O�p����
        //�{����TitleScene����n�܂邪�A�f�o�b�O�̂���GameScene����n�܂�p�^�[����p��
        if (SceneManager.GetActiveScene().name == "TitleScene")
        {
            //�X�e�[�g�ݒ�
            state = States.Title;

            //BGM�؂�ւ�&�Đ�
            audioSource.clip = titleBGM;
            audioSource.Play();
        }
        else if (SceneManager.GetActiveScene().name == "InGameScene")
        {
            //�X�e�[�g�ݒ�
            state = States.GamePlaying;

            //BGM�؂�ւ�&�Đ�
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
                // P�{�^���������ꂽ�Ƃ��Ƀ|�[�Y
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
            //���̑��̏�����default
            default:
                break;
        }
        // Esc�L�[�ɂăQ�[���I��
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameQuit();
        }
    }

    // �Q�[���X�e�[�g
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

    // �Q�[���I�[�o�[����
    public void GameOver()
    {
        state = States.GameOver;

        // �Q�[���I�[�o�[SE
        audioSource.PlayOneShot(gameOverSE);

        //���X�^�[�g������
        Invoke(nameof(Restart), restartTime);
    }

    // �Q�[���N���A����
    public void GameClear()
    {
        state = States.GameClear;

        // �Q�[���N���ASE
        audioSource.PlayOneShot(gameClearSE);
        //���X�^�[�g������
        Invoke(nameof(ChangeTitleScene), clearTime);
    }


    // ���X�^�[�g����
    private void Restart()
    {
        state = States.GamePlaying;

        SceneManager.LoadScene("GameScene");
    }

    public void ChangeHowToPlayScene()
    {
        //�X�e�[�g��ύX
        state = States.HowToPlay;

        //HowToPlayScene�֑J��
        SceneManager.LoadScene("HowToPlayScene");
    }
    public void ChangeGameScene()
    {
        //�X�e�[�g��ύX
        state = States.GamePlaying;

        //BGM�؂�ւ�&�Đ�
        audioSource.clip = gamePlayingBGM;
        audioSource.Play();

        //GameScene�֑J��
        SceneManager.LoadScene("GameScene");
    }

    public void ChangeTitleScene()
    {
        //�X�e�[�g��ύX
        state = States.Title;

        //�ĊJ
        Time.timeScale = 1f;

        //BGM�؂�ւ�&�Đ�
        audioSource.clip = titleBGM;
        audioSource.Play();

        //TitleScene�֑J��
        SceneManager.LoadScene("TitleScene");
    }
    public void GamePause()
    {
        //�X�e�[�g�ύX
        state = States.GamePause;

        //�|�[�Y
        Time.timeScale = 0f;
    }
    //Time.timeScale�ɂ���
    //Update�͓��� FixedUpdate�͎~�܂�
    public void GameResume()
    {
        //�X�e�[�g�ύX
        state = States.GamePlaying;

        //�ĊJ
        Time.timeScale = 1f;
    }

    public void GameQuit()
    {
        Application.Quit();
    }
}
