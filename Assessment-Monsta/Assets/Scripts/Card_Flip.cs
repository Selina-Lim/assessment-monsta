using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Card_Flip : MonoBehaviour, IPointerDownHandler
{
    public Image image;
    public Sprite front, back;

    [SerializeField] private bool isFaceUp, enabledCoroutine;

    void Start()
    {
        image = GetComponent<Image>();
        isFaceUp = false;
        enabledCoroutine = true;

    }


    void Update()
    {
        
    }

    //Functions
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log(this.gameObject.name + " Was Clicked.");
        if(enabledCoroutine)
        {
            StartCoroutine(RotateCard());
        }
    }


    //IEnumerator
    public IEnumerator RotateCard()
    {

        if (isFaceUp == false)
        {
            for(float i = 0f; i <= 180f; i+=10f)
            {
                transform.rotation = Quaternion.Euler(0f, i, 0f);

                if(i == 90f) //flip 90 degree, change to front sprite
                {
                    image.sprite = front;
                }
                yield return new WaitForSeconds(0.02f);

            }

        }
        else
        {
            for (float i = 180f; i >= 0f; i-=10f)
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
