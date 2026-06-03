using UnityEngine;

public class PointManager : MonoBehaviour
{
    [SerializeField] PointController pointPrefab;
    /// <summary>
    /// controller
    /// ポイント獲得時にポイント表示を生成
    /// </summary>
    /// <param name="position">表示位置</param>
    /// <param name="point">獲得ポイント</param>
    public void ShowPoint(Vector3 position, int point)
    {
        PointController pointObj = Instantiate(pointPrefab, position, Quaternion.identity, transform);
        pointObj.point = point;
    }
}
