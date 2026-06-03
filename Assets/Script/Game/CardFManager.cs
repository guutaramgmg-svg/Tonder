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

    // �X���C�v�͈�
    private float ChangeDrag = 1;

    //Like Nope ����
    private bool LikeCk;
    private bool NopeCk;
    private bool SuperLikeCk;

    //�h���b�O����
    private bool isDragging = false;

    public GameObject CardB;
    public CardListManager cardListManager;

    // ポイント獲得
    private const int m_ButaLikePoint = 1;
    private const int m_ButaSuperLikePoint = 7;
    private const int m_ButaNopePoint = -5;
    private const int m_KoukokuLikePoint = -5;
    private const int m_KoukokuSuperLikePoint = 7;
    private const int m_KoukokuNopePoint = 1;

    // SLP獲得
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
    /// マウス押下時
    /// </summary>
    void OnMouseDown()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        offset = transform.position - mousePosition;
        
        wkoffset = mousePosition;

        isDragging = true;
    }

    /// <summary>
    /// マウス押下中
    /// </summary>
    void OnMouseDrag()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // �h���b�O���̏ꍇ
        if (isDragging)
        {
            transform.position = mousePosition + offset;
            Vector3 direction = target - transform.position;
            // �p�x�����߂�B
            float angle = Mathf.Atan2(direction.x, direction.y);
            //�I�u�W�F�N�g��Quaternion.AngleAxis���g���ĉ�]������B
            transform.rotation = Quaternion.AngleAxis(angle * Mathf.Rad2Deg, Vector3.back);
        }
        
        var Horizontal = mousePosition.x - wkoffset.x;
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
                    LikeCk = false;
                    NopeCk = false;
                    SuperLikeCk = true;
                }
                else
                {
                    Like.SetActive(false);
                    Nope.SetActive(false);
                    SuperLike.SetActive(false);
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
    /// マウスを離したら
    /// </summary>
    void OnMouseUp()
    {
        isDragging = false;
        Nope.SetActive(false);
        Like.SetActive(false);
        SuperLike.SetActive(false);

        if (LikeCk == true || NopeCk == true || SuperLikeCk == true)
        {
            //LikeNope判定
            LikeNopeJudge();
        }
        Reset();
    }

    /// <summary>
    /// ���Z�b�g
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
    /// �J�[�h���\���ɂ��A����ɃJ�[�h�����[�h�����s����B
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
    /// ���̃J�[�h����J�[�h�����[�h����B
    /// </summary>
    public void Cardreload()
    {
        m_Entity = CardB.GetComponent<CardBManager>().m_Entity;
        this.gameObject.GetComponent<SpriteRenderer>().sprite = m_Entity.Phot;
        this.gameObject.SetActive(true);
        
        //���̃J�[�h�����t���b�V������B
        cardListManager.CardRefresh();
    }

    /// <summary>
    /// LikeNope�𔻒肵�|�C���g��ǉ�����
    /// </summary>
    public void LikeNopeJudge()
    {
        // 右スワイプ
        if (LikeCk)
        {
            cardListManager.SePlay(m_Entity.SeLike);
            if (m_Entity.Type == false)
            {
                //�u�^Like�̏ꍇ
                cardListManager.SLPUpdate(m_ButaLikeSLP);
                cardListManager.PointUpDate(m_ButaLikePoint);
            }
            else
            {
                //�L��Like�̏ꍇ
                cardListManager.SLPUpdate(m_KoukokuLikeSLP);
                cardListManager.PointUpDate(m_KoukokuLikePoint);
            }
        }

        // 左スワイプ
        if (NopeCk)
        {
            cardListManager.SePlay(m_Entity.SeNope);
            if (m_Entity.Type == false)
            {
                //�u�^Nope�̏ꍇ
                cardListManager.SLPUpdate(m_ButaNopeSLP);
                cardListManager.PointUpDate(m_ButaNopePoint);
            }
            else
            {
                //�L��Nope�̏ꍇ
                cardListManager.SLPUpdate(m_KoukokuNopeSLP);
                cardListManager.PointUpDate(m_KoukokuNopePoint);
            }
        }

        // 上スワイプ
        if (SuperLikeCk)
        {
            cardListManager.SePlay(m_Entity.SeSuperLike);
            if (m_Entity.Type == false)
            {
                //�u�^Like�̏ꍇ
                cardListManager.PointUpDate(m_ButaSuperLikePoint);
            }
            else
            {
                //�L��Like�̏ꍇ
                cardListManager.PointUpDate(m_KoukokuSuperLikePoint);
            }
            cardListManager.SLPReset();
        }
        CardDel();
    }
}