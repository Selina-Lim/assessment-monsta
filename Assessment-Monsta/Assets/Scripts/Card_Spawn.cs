using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card_Spawn : MonoBehaviour
{
    public GameObject prefabObj;
    public Transform parentObj;

    void Start()
    {
        StartCoroutine(ShuffleCard());

    }


    void Update()
    {
        
    }

    //Functions
    public void InstantiateCard()
    {
        for(int i = 0; i < 3; i++) //instantiate 3 cards
        {
            GameObject cardPrefab = Instantiate(prefabObj, parentObj) as GameObject;
        }

    }

    //IEnumerator
    public IEnumerator ShuffleCard() //Play animation
    {
        yield return new WaitForSeconds(0.01f);
        InstantiateCard();

    }

}
