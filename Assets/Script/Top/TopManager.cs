using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TopManager : MonoBehaviour
{

    public SoundManager soundManager;
    public GameObject topAni;
    public List<Sprite> start;
    public List<Sprite> startT;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        soundManager.PlayBGM(SoundManager.BGM.Top);
        StartCoroutine(TopAnime());
    }

    public void GamePlaySceneBtn()
    {
        SceneManager.LoadScene("GamePlay");
    }

    private IEnumerator TopAnime()
    {
        int timer = 0;
        while (true)
        {
            timer++;
            if(timer >= 73)
            {
                yield return new WaitForSeconds(0.2f);
                topAni.GetComponent<Image>().sprite = startT[0];
                yield return new WaitForSeconds(0.2f);
                topAni.GetComponent<Image>().sprite = startT[1];
                yield return new WaitForSeconds(0.2f);
                topAni.GetComponent<Image>().sprite = startT[2];
                yield return new WaitForSeconds(0.2f);
                topAni.GetComponent<Image>().sprite = startT[1];
                yield return new WaitForSeconds(0.2f);
                topAni.GetComponent<Image>().sprite = startT[0];
                yield return new WaitForSeconds(0.2f);
                topAni.GetComponent<Image>().sprite = startT[1];
                yield return new WaitForSeconds(0.2f);
                topAni.GetComponent<Image>().sprite = startT[2];
                yield return new WaitForSeconds(0.2f);
                topAni.GetComponent<Image>().sprite = startT[1];
                yield return new WaitForSeconds(0.2f);
                topAni.GetComponent<Image>().sprite = startT[0];
                yield return new WaitForSeconds(0.2f);
                topAni.GetComponent<Image>().sprite = startT[1];
                yield return new WaitForSeconds(0.2f);
                topAni.GetComponent<Image>().sprite = startT[2];
                yield return new WaitForSeconds(0.2f);
                topAni.GetComponent<Image>().sprite = startT[0];
                yield return new WaitForSeconds(0.2f);
                topAni.GetComponent<Image>().sprite = startT[1];

                yield return new WaitForSeconds(0.2f);
                topAni.GetComponent<Image>().sprite = startT[3];
                yield return new WaitForSeconds(0.8f);
                topAni.GetComponent<Image>().sprite = startT[4];
                yield return new WaitForSeconds(0.8f);
                topAni.GetComponent<Image>().sprite = startT[0];
                yield return new WaitForSeconds(0.2f);


                timer = 0;
                Debug.Log("特別なアニメーション");
            }
            topAni.GetComponent<Image>().sprite = start[0];
            yield return new WaitForSeconds(0.2f);
            topAni.GetComponent<Image>().sprite = start[1];
            yield return new WaitForSeconds(0.2f);
            topAni.GetComponent<Image>().sprite = start[2];
            yield return new WaitForSeconds(0.2f);
        }
    }

}
