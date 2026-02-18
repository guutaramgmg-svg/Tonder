using UnityEngine;
using UnityEngine.UI;


public class SPLController : MonoBehaviour
{
    public Slider SPLSlider;

    private int Max = 1000;
    private int Min = 0;

    public CardListManager cardListManager;
    public SPLHartManager splHartManager;

    public GameObject splImg;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //SPLSlider.value = Max;
        SPLReset();
    }

    /// <summary>
    /// SPL更新
    /// </summary>
    /// <param name="point"></param>
    public void SPLSliderUpdate(int point)
    {
        SPLSlider.value = SPLSlider.value - point;
        SPLSliderCk();
    }

    /// <summary>
    /// SPL状態確認
    /// </summary>
    public void SPLSliderCk()
    {
        if(SPLSlider.value == Min)
        {
            cardListManager.m_IsEnableSPL=true;
            splImg.SetActive(true);
        }
        splHartManager.HartUpdate(SPLSlider.value);
    }

    /// <summary>
    /// SPL初期化
    /// </summary>
    public void SPLReset()
    {
        cardListManager.m_IsEnableSPL = false;
        splImg.SetActive(false);

        SPLSlider.value = Max;
        splHartManager.HartUpdate(SPLSlider.value);
    }
}