using UnityEngine;
using UnityEngine.UI;

public class CardFManager : MonoBehaviour
{
    public GameObject Like;
    public GameObject Nope;
    public GameObject SuperLike;

    public Entity m_Entity;

    private Vector3 offset;
    private Vector3 wkoffset;

    private Vector3 _initialPosition;
    private Quaternion _initialRotation;
    Vector3 target;

    // スワイプ範囲
    private float ChangeDrag = 1;

    //Like Nope 判定
    private bool LikeCk;
    private bool NopeCk;
    private bool SuperLikeCk;

    //ドラッグ判定
    private bool isDragging = false;

    public GameObject CardB;
    public CardListManager cardListManager;

    // ポイント
    private const int m_ButaLikePoint = 1;
    private const int m_ButaSuperLikePoint = 7;
    private const int m_ButaNopePoint = -5;
    private const int m_KoukokuLikePoint = -5;
    private const int m_KoukokuSuperLikePoint = 7;
    private const int m_KoukokuNopePoint = 1;

    // SLPポイント
    private const int m_ButaLikeSLP = 230;
    private const int m_ButaNopeSLP = 70;

    private const int m_KoukokuLikeSLP = 70;
    private const int m_KoukokuNopeSLP = 230;


    void Start()
    {
        m_Entity  = cardListManager.GetEntity();
        this.gameObject.GetComponent<SpriteRenderer>().sprite = m_Entity.Phot;

        LikeCk = false;
        NopeCk = false;
        SuperLikeCk = false;

        target = new Vector3(0.0f, 5.0f, 0.0f);
        _initialPosition = gameObject.transform.position;
        _initialRotation = gameObject.transform.rotation;

        Nope.SetActive(false);
        Like.SetActive(false);
        SuperLike.SetActive(false);


    }

    /// <summary>
    /// マウスダウン時
    /// </summary>
    void OnMouseDown()
    {
        Debug.Log("クリック");
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        offset = transform.position - mousePosition;
        
        wkoffset = mousePosition;

        isDragging = true;
    }

    /// <summary>
    /// マウスドラッグ時
    /// </summary>
    void OnMouseDrag()
    {
        Debug.Log("ドラッグ");
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // ドラッグ中の場合
        if (isDragging)
        {
            transform.position = mousePosition + offset;
            Vector3 direction = target - transform.position;
            // 角度を求める。
            float angle = Mathf.Atan2(direction.x, direction.y);
            //オブジェクトをQuaternion.AngleAxisを使って回転させる。
            transform.rotation = Quaternion.AngleAxis(angle * Mathf.Rad2Deg, Vector3.back);
        }

        // 好き嫌い判定距離
        // 横
        var Horizontal = mousePosition.x - wkoffset.x;
        // 縦
        var Vertical = mousePosition.y - wkoffset.y;



        if (Mathf.Abs(Vertical) >= ChangeDrag)
        {
            if (cardListManager.m_IsEnableSPL)
            {
                if (Vertical >= 0)
                {
                    Like.SetActive(false);
                    Nope.SetActive(false);
                    SuperLike.SetActive(true);

                    Debug.Log("下" + Mathf.Abs(Vertical));
                    LikeCk = false;
                    NopeCk = false;
                    SuperLikeCk = true;
                }
                else
                {
                    Like.SetActive(false);
                    Nope.SetActive(false);
                    SuperLike.SetActive(false);

                    Debug.Log("上" + Mathf.Abs(Vertical));
                    LikeCk = false;
                    NopeCk = false;
                    SuperLikeCk = false;
                }
            }
        }
        else if (Mathf.Abs(Horizontal) >= ChangeDrag)
        {
            if (Horizontal >= 0)
            {
                Like.SetActive(true);
                Nope.SetActive(false);
                SuperLike.SetActive(false);

                Debug.Log("右" + Mathf.Abs(Horizontal));
                LikeCk = true;
                NopeCk = false;
                SuperLikeCk = false;

            }
            else
            {
                Like.SetActive(false);
                Nope.SetActive(true);
                SuperLike.SetActive(false);

                LikeCk = false;
                NopeCk = true;
                SuperLikeCk = false;

                Debug.Log("左" + Mathf.Abs(Horizontal));
            }
        }
        else
        {
            LikeCk = false;
            NopeCk = false;
            SuperLikeCk = false;

            Nope.SetActive(false);
            Like.SetActive(false);
            SuperLike.SetActive(false);
        }
    }

    /// <summary>
    /// マウスアップ時
    /// </summary>
    void OnMouseUp()
    {
        Debug.Log("クリップアップ");
        isDragging = false;
        Nope.SetActive(false);
        Like.SetActive(false);
        SuperLike.SetActive(false);

        if (LikeCk == true || NopeCk == true || SuperLikeCk == true)
        {
            //likeNopeを判定する
            LikeNopeJudge();
        }
        Reset();
    }

    /// <summary>
    /// リセット
    /// </summary>
    public void Reset()
    {
        transform.position = _initialPosition;
        transform.rotation = _initialRotation;
        LikeCk = false;
        NopeCk = false;
        SuperLikeCk = false;
    }

    /// <summary>
    /// カードを非表示にし、直後にカードリロードを実行する。
    /// </summary>
    public void CardDel()
    {
        transform.position = _initialPosition;
        transform.rotation = _initialRotation;
        LikeCk = false;
        NopeCk = false;
        SuperLikeCk = false;

        this.gameObject.SetActive(false);

        Invoke(nameof(Cardreload), 0.1f);
    }

    /// <summary>
    /// 後ろのカードからカードをロードする。
    /// </summary>
    public void Cardreload()
    {
        m_Entity = CardB.GetComponent<CardBManager>().m_Entity;
        this.gameObject.GetComponent<SpriteRenderer>().sprite = m_Entity.Phot;
        this.gameObject.SetActive(true);
        
        //後ろのカードをリフレッシュする。
        cardListManager.CardRefresh();
    }

    /// <summary>
    /// LikeNopeを判定しポイントを追加する
    /// </summary>
    public void LikeNopeJudge()
    {
        if (LikeCk)
        {
            cardListManager.SePlay(m_Entity.SeLike);
            if (m_Entity.Type == false)
            {
                //ブタLikeの場合
                cardListManager.SLPUpdate(m_ButaLikeSLP);
                cardListManager.PointUpDate(m_ButaLikePoint);
            }
            else
            {
                //広告Likeの場合
                cardListManager.SLPUpdate(m_KoukokuLikeSLP);
                cardListManager.PointUpDate(m_KoukokuLikePoint);
            }
        }

        if (NopeCk)
        {
            cardListManager.SePlay(m_Entity.SeNope);
            if (m_Entity.Type == false)
            {
                //ブタNopeの場合
                cardListManager.SLPUpdate(m_ButaNopeSLP);
                cardListManager.PointUpDate(m_ButaNopePoint);
            }
            else
            {
                //広告Nopeの場合
                cardListManager.SLPUpdate(m_KoukokuNopeSLP);
                cardListManager.PointUpDate(m_KoukokuNopePoint);
            }
        }

        if (SuperLikeCk)
        {
            cardListManager.SePlay(m_Entity.SeSuperLike);
            if (m_Entity.Type == false)
            {
                //ブタLikeの場合
                cardListManager.PointUpDate(m_ButaSuperLikePoint);
            }
            else
            {
                //広告Likeの場合
                cardListManager.PointUpDate(m_KoukokuSuperLikePoint);
            }
            cardListManager.SLPReset();
        }
        CardDel();
    }
}