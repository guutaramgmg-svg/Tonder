using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SPLHartManager : MonoBehaviour
{
    public List<Sprite> Hart;


    public void HartUpdate(float point)
    {


        if (1000 == point)
        {
            this.gameObject.GetComponent<Image>().sprite = Hart[0];
        }else if(1000 > point && point >= 500)
        {
            this.gameObject.GetComponent<Image>().sprite = Hart[1];
        }else if(500 > point && point > 0)
        {
            this.gameObject.GetComponent<Image>().sprite = Hart[2];
        }
        else
        {
            this.gameObject.GetComponent<Image>().sprite = Hart[3];
        }

    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.gameObject.GetComponent<Image>().sprite = Hart[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
