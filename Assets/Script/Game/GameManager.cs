using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    // debug用
    public Text debug_TimerTx;
    public Text debug_PointTx;
    public Text debug_StartTx;


    // パラメタ
    public Text TimerTx;
    

    int m_Timer;
    int m_Point;
    int m_Start;

    public SPLController splController;
    private SaveManager saveManager;
    private SoundManager soundManager;
    private bool End = false;

    private int Timer = 30;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        saveManager = GameObject.Find("SaveManager").GetComponent<SaveManager>();
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        soundManager.PlayBGM(SoundManager.BGM.Game);

        constructor();
        StartCoroutine(TimerCoroutine());
    }

    /// <summary>
    /// コンストラクタ
    /// </summary>
    private void constructor()
    {
        End = false;
        PointUpdate(0);
        TimerUpdate(Timer);
    }


    IEnumerator TimerCoroutine()
    {
        m_Start++;
        debug_StartTx.text = "Start:" + m_Start;
        yield return new WaitForSeconds(1.0f);
        m_Start++;
        debug_StartTx.text = "Start:" + m_Start;
        yield return new WaitForSeconds(1.0f);
        m_Start++;
        debug_StartTx.text = "Start:" + m_Start;
        yield return new WaitForSeconds(1.0f);

        while (true)
        {
            TimerUpdate(-1);
            yield return new WaitForSeconds(1.0f);
            if (End)
            {
                break;
            }
        }
        EndScene();
    }

    /// <summary>
    /// 時間の更新
    /// </summary>
    /// <param name="time"></param>
    public void TimerUpdate(int time)
    {
        m_Timer = m_Timer + time;
        debug_TimerTx.text = "Timer:" + m_Timer;
        TimerTx.text = "Timer:" + m_Timer;
        if (0 == m_Timer)
        {
            End = true;
        };
    }

    /// <summary>
    /// ポイントの更新
    /// </summary>
    /// <param name="point"></param>
    public void PointUpdate(int point)
    {
        m_Point = m_Point + point;
        debug_PointTx.text = "Point:" + m_Point;
    }

    /// <summary>
    /// SPL更新
    /// </summary>
    /// <param name="point"></param>
    public void SPLUpdate(int point)
    {
        splController.SPLSliderUpdate(point);
    }

    /// <summary>
    /// SPLリセット
    /// </summary>
    public void SPLReset()
    {
        splController.SPLReset();
    }

    /// <summary>
    /// ゲーム終了
    /// </summary>
    void EndScene()
    {
        saveManager.Point = m_Point;
        SceneManager.LoadScene("End");
    }
    public void ResetScene()
    {
        SceneManager.LoadScene("Top");
    }

    public void SePlay(SoundManager.SESuperLike se)
    {
        soundManager.PlaySE(se);            
    }

    public void SePlay(SoundManager.SELike se)
    {
        soundManager.PlaySE(se);
    }
    public void SePlay(SoundManager.SENope se)
    {
        soundManager.PlaySE(se);
    }
}