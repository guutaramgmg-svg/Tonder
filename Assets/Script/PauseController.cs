using UnityEngine;
using UnityEngine.UI;

public class PauseController : MonoBehaviour
{
    public GameObject pause;
    public Slider bgmSlider;
    public Slider seSlider;

    
    void Start()
    {
        SoundManager.GetInstance().PlayBGM(0);

        bgmSlider.value = 0.5f;
        seSlider.value = 0.5f;

        OnChangedBGMSlider();
        OnChangedSESlider();
    }

    public void OnChangedBGMSlider()
    {
        SoundManager.GetInstance().BGMVolume = bgmSlider.value;
    }
    public void OnChangedSESlider()
    {
        SoundManager.GetInstance().SEVolume = seSlider.value;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPauseBtn()
    {
        pause.SetActive(true);

    }

    public void OnPauseReturnBtn()
    {
        pause.SetActive(false);

    }
}
