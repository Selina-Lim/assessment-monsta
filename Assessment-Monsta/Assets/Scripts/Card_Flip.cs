using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class Card_Flip : MonoBehaviour, IPointerDownHandler
{
    public Image image;
    public Sprite front, back;

    [SerializeField] private bool isFaceUp, enabledCoroutine;
    public static bool pickedOneCard;

    public GameObject detailObj;
    public GameObject imgObj;

    public Transform child; //do not rotate child obj 

    public TextMeshProUGUI txt;
    public List<string> detailList = new List<string>();


    public Image cardImg;
    public List<Sprite> imgCardList = new List<Sprite>();

    public void PickRandomDetailsFromList()
    {
        detailObj.SetActive(true);
        imgObj.SetActive(true);

        int rand = Random.Range(0, 4);
        Debug.Log("rand is " + rand);

        //text
        string detailSelected = detailList[rand];
        txt.text = detailSelected;

        //card img
        Sprite imgSelected = imgCardList[rand];
        cardImg.sprite = gameObject.GetComponent<Image>().sprite;
        cardImg.sprite = imgSelected;
    }
    


    void Start()
    {
        image = GetComponent<Image>();
        image.sprite = back;

        isFaceUp = false;
        pickedOneCard = false;
        enabledCoroutine = true;

        detailObj.SetActive(false);
        imgObj.SetActive(false);

    }


    void Update()
    {
        if (pickedOneCard)
        {
            image.raycastTarget = false;
        }
    }

    //Functions
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log(this.gameObject.name + " Was Clicked.");
        if(enabledCoroutine && !pickedOneCard)
        {
            StartCoroutine(RotateCard());
        }
    }


    //IEnumerator
    public IEnumerator RotateCard()
    {
        enabledCoroutine = false;

        if (isFaceUp == false)
        {
            for(float i = 180f; i >= 0f; i -= 10f)
            {
                transform.rotation = Quaternion.Euler(0f, i, 0f);
                pickedOneCard = true;

                if (i == 90f) //flip 90 degree, change to front sprite
                {
                    image.sprite = front;
                    PickRandomDetailsFromList();

                }
                yield return new WaitForSeconds(0.02f);

            }
        }
        else
        {
            for (float i = 0f; i <= 180f; i+=10f)
            {
                transform.rotation = Quaternion.Euler(0f, i, 0f);

                if (i == 90f) //flip 90 degree, change to back sprite
                {
                    image.sprite = back;
                }
                yield return new WaitForSeconds(0.02f);

            }
        }

    }
}
