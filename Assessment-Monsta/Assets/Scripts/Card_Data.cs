using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card_Data : MonoBehaviour
{
    public static List<Card_Class> detailList = new List<Card_Class>();

    public List<T> GetRandomElement<T>(List<T> inputList, int count)
    {
        List<T> outputList = new List<T>();
        for (float i = 0; i < count; i++)
        {
            int rand = Random.Range(0, inputList.Count);
            outputList.Add(inputList[rand]);
        }

        return outputList;
    }

    private void Update()
    {
        //var rand = GetRandomElement(detailList, 3);

    }

}
