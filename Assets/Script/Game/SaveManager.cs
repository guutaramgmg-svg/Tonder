using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;
    public int Point;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        Point = 0;
    }

}
