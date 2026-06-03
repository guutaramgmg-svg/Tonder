using TMPro;
using UnityEngine;
using DG.Tweening;

public class PointController : MonoBehaviour
{
    [SerializeField] private float riseDistance = 1f;
    [SerializeField] private float duration = 1f;

    public int point = 0;

    private void Start()
    {
        TextMeshProUGUI text = GetComponentInChildren<TextMeshProUGUI>();

        if (text == null) return;

        // 色と表示内容を設定
        Color baseColor;

        if (point >= 0)
        {
            text.text = $"+{point}";
            baseColor = new Color32(46, 204, 113, 255); // エメラルドグリーン
        }
        else
        {
            text.text = point.ToString();
            baseColor = new Color32(231, 76, 60, 255); // コーラルレッド
        }

        text.color = baseColor;

        // 少し発光するような色変化
        Color highlight = Color.Lerp(baseColor, Color.white, 0.3f);

        // 最初は小さく
        text.transform.localScale = Vector3.zero;

        Sequence seq = DOTween.Sequence();

        // ポンッと表示
        seq.Append(
            text.transform.DOScale(1f, 0.25f)
                .SetEase(Ease.OutBack)
        );

        // 色を一瞬明るくする
        seq.Join(
            text.DOColor(highlight, 0.15f)
                .SetLoops(2, LoopType.Yoyo)
        );

        // 上昇
        seq.Join(
            transform.DOMoveY(
                transform.position.y + riseDistance,
                duration
            )
            .SetEase(Ease.OutCubic)
        );

        // フェードアウト
        seq.Join(text.DOFade(0f, duration));

        seq.OnComplete(() => Destroy(gameObject));
    }
}