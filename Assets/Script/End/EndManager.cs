using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;

public class EndManager : MonoBehaviour
{
    public SaveManager saveManager;
    public Text PointTx;
    public int m_Point;
    public GameObject endAni;
    public GameObject returnBtn;

    public GameObject Tonder;
    public GameObject TonderWk;

    public GameObject Kirakira;
    public GameObject Lave;

    public GameObject Tarinai;
    public GameObject Buhi;


    public List<Sprite> clear;
    public List<Sprite> over;

    private const int check = 200;

    public SoundManager soundManager;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Tonder.SetActive(false);
        TonderWk.SetActive(false);

        Kirakira.SetActive(false);
        Lave.SetActive(false);
        endAni.SetActive(false);

        Tarinai.SetActive(false);
        Buhi.SetActive(false);

        returnBtn.SetActive(false);
        saveManager = GameObject.Find("SaveManager").GetComponent<SaveManager>();
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        m_Point = saveManager.Point;
        PointTx.text = "Point" + m_Point;
        
        PointJudge();
    }

    private void PointJudge()
    {
        if(m_Point >= check)
        {
            soundManager.PlayBGM(SoundManager.BGM.End1);
            StartCoroutine(EndAnime(clear));
        }
        else
        {
            soundManager.PlayBGM(SoundManager.BGM.End2);
            StartCoroutine(EndAnime(over));
        }
    }

    public void TopSceneBtn()
    {
        SceneManager.LoadScene("Top");
    }

    private IEnumerator EndAnime(List<Sprite> anim)
    {
        //ラブチェック
        Tonder.SetActive(true);
        TonderWk.SetActive(true);

        float work = (float)m_Point / (float)check;
        for (float i = 0; i <= work && i <= 1; i = (float)i + 0.001f)
        {
            Tonder.GetComponent<Image>().fillAmount = Tonder.GetComponent<Image>().fillAmount + 0.001f;
            yield return new WaitForSeconds(0.001f);
        }

        if (m_Point >= check)
        {
            yield return new WaitForSeconds(0.1f);
            Kirakira.SetActive(true);
            yield return new WaitForSeconds(0.1f);
            Lave.SetActive(true);
        }
        else
        {
            yield return new WaitForSeconds(0.1f);
            Tarinai.SetActive(true);
            yield return new WaitForSeconds(0.1f);
            Buhi.SetActive(true);

        }
        yield return new WaitForSeconds(2.5f);

        Tonder.SetActive(false);
        TonderWk.SetActive(false);

        Kirakira.SetActive(false);
        Lave.SetActive(false);

        Tarinai.SetActive(false);
        Buhi.SetActive(false);


        endAni.SetActive(true);

        foreach (var item in anim)
        {
            endAni.GetComponent<Image>().sprite = item;
            yield return new WaitForSeconds(1.5f);
        }
        yield return new WaitForSeconds(1.0f);
        returnBtn.SetActive(true);
    }
}
