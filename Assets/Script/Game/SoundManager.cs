using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // 音を鳴らす
    // ・AudioSource : スピーカー
    // ・AudioClip : CD/カセット

    // BGM
    [SerializeField] AudioSource audioSourceBGM = default;
    [SerializeField] AudioClip[] audioClips = default;

    //SE
    [SerializeField] AudioSource audioSourceSE = default;
    [SerializeField] AudioClip[] seClipssuperLikeSE = default;

    //SEBuhi
    [SerializeField] AudioClip[] seClipsLikeSE = default;
    [SerializeField] AudioClip[] seClipsNopeSE = default;

    public float BGMVolume
    {
        get { return audioSourceBGM.volume; }
        set { audioSourceBGM.volume = value; }
    }

    public float SEVolume
    {
        get { return audioSourceSE.volume; }
        set { audioSourceSE.volume = value; }
    }

    public enum BGM
    {
        Top,
        Game,
        End1,
        End2,
    }
    public enum SELike
    {
        Toki_01,
        Nu_02,
        Siopan_03,
        Siopan_04,
        Morty_05,
        Yanibuta_06,
    }

    public enum SENope
    {
        Toki_01,
        Nu_02,
        Siopan_03,
        Morty_04,
        Yanibuta_05,
    }

    public enum SESuperLike
    {
        //Entity
        Entity,
        Entity_01,
        Entity_02,
        Entity_03,
        Entity_04,
        Entity_05,
        Entity_06,
        Entity_07,
        Entity_08,
        Entity_09,
        Entity_10,
        Entity_11,
        Entity_12,

    }


    // シングルトンにしてやる
    //・ゲーム内にただ１つだけのもの

    static SoundManager Instance = null;

    public static SoundManager GetInstance()
    {
        if(Instance == null)
        {
            Instance = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        }
        return Instance;
    }

    private void Awake()
    {
        if (this != GetInstance())
        {
            Destroy(this.gameObject);
            return;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {

        //        PlayBGM(BGM.Main);
    }

    public void PlayBGM(BGM bgm)
    {
        audioSourceBGM.clip = audioClips[(int)bgm];
        audioSourceBGM.Play();
    }

    public void PlaySE(SESuperLike se)
    {
        audioSourceSE.PlayOneShot(seClipssuperLikeSE[(int)se]);
    }
    public void PlaySE(SELike se)
    {
        audioSourceSE.PlayOneShot(seClipsLikeSE[(int)se]);
    }
    public void PlaySE(SENope se)
    {
        audioSourceSE.PlayOneShot(seClipsNopeSE[(int)se]);
    }

    public void testBtn()
    {
        audioSourceSE.PlayOneShot(seClipssuperLikeSE[(int)SESuperLike.Entity]);
    }
}