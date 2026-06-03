using System.Collections.Generic;
using UnityEngine;


public class CardListManager : MonoBehaviour
{
    public GameObject prfbCard;

    public List<GameObject> list = new List<GameObject>();

    public GameManager gameManager;
    public CardFManager cardFManager;
    public CardBManager cardBManager;

    public List<Entity> entitiyList;

    public bool m_IsEnableSPL = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public List<Entity> butaList;
    public List<Entity> adList;

    void Start()
    {
        CardSet();
        CardRefresh();
    }


    // カード設定
    private void CardSet()
    {
        foreach (var value in entitiyList)
        {
            if (value.Type)
            {
                adList.Add(value);
            }
            else
            {
                butaList.Add(value);
            }
        }
    }

    // カードリフレッシュ
    public void CardRefresh()
    {
        cardBManager.SpriteRefresh(GetEntity());
    }

    /// <summary>
    /// ポイント更新
    /// </summary>
    /// <param name="point"></param>
    public void PointUpDate(int point)
    {
        // ポイント更新
        gameManager.PointUpdate(point);
        Debug.Log("ポイント更新：" + point);
    }

    /// <summary>
    /// SP更新
    /// </summary>
    /// <param name="point"></param>
    public void SLPUpdate(int point)
    {
        // SP更新
        gameManager.SPLUpdate(point);
        Debug.Log("SP更新：" + point);
    }

    /// <summary>
    /// SPリセット
    /// </summary>
    public void SLPReset()
    {
        gameManager.SPLReset();
    }

    public Entity GetEntity()
    {
        if (Random.Range(0, 7) >= 2)
        {
            return butaList[Random.Range(0, butaList.Count)];
        }
        else
        {
            return adList[Random.Range(0, adList.Count)];
        }
    }

    public void SePlay(SoundManager.SESuperLike se)
    {
        gameManager.SePlay(se);
    }
    public void SePlay(SoundManager.SELike se)
    {
        gameManager.SePlay(se);
    }
    public void SePlay(SoundManager.SENope se)
    {
        gameManager.SePlay(se);
    }
}
