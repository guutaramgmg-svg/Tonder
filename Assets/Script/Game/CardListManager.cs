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


    //“Ø‚ÆL‚ÌŽd•ª‚¯
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

    public void CardRefresh()
    {
        cardBManager.SpriteRefresh(GetEntity());
    }

    public void PointUpDate(int point)
    {
        gameManager.PointUpdate(point);
    }

    public void SLPUpdate(int point)
    {
        gameManager.SPLUpdate(point);
    }
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
