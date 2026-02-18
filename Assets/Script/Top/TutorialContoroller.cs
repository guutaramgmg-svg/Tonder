using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialContoroller : MonoBehaviour
{
    public GameObject Tutorial;
    public GameObject tutorialAni;
    public List<Sprite> tutorial;
    public int tutorialIndex = 1;

    public void Start()
    {
        Tutorial.SetActive(false);

    }

    public void TutorialBtn()
    {
        if (Tutorial.activeSelf)
        {
            Tutorial.SetActive(false);
        }
        else
        {
            tutorialAni.GetComponent<Image>().sprite = tutorial[0];
            tutorialIndex = 1;
            Tutorial.SetActive(true);
        }



    }

    public void XBtn()
    {
        Tutorial.SetActive(false);
    }

    public void NextBtn()
    {
        if (tutorialIndex == 0)
        {
            tutorialIndex++;
            tutorialAni.GetComponent<Image>().sprite = tutorial[0];
        }
        else if (tutorialIndex == 1){
            tutorialIndex++;
            tutorialAni.GetComponent<Image>().sprite = tutorial[1];
        }
        else {
            tutorialAni.GetComponent<Image>().sprite = tutorial[2];
            tutorialIndex = 0;
        }
    }
}