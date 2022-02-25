using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sorting : MonoBehaviour
{
    public bool sorting;
    [SerializeField] GameObject[] groups;
    [SerializeField] GameObject[] monsters;
    [SerializeField] int minSorting;
    int counting;
    int randomValue;
    void Start()
    {
        
    }

    void Update()
    {
        if (sorting && groups.Length > 0) SortingObject();
        if (counting >= randomValue)
        {
            sorting = false;
            counting = 0;
        }
    }
    public void SortingObject()
    {
        //valor da quantida de monstros
        for (int i = 0; i < groups.Length; i++)
        {
            //n do monstro
            int index = Random.Range(0, groups.Length + 1);

            if (i == index && !groups[i].activeSelf)
            {
                groups[i].SetActive(true);
                counting++;
            }
        }
    }

    public void SortingOneObject()
    {
        for (int i = 0; i < monsters.Length; i++)
        {
            int index = Random.Range(0, monsters.Length + 1);
            if (i == index) monsters[i].SetActive(true);
            else monsters[i].SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            foreach (var item in groups) item.SetActive(false);
            randomValue = Random.Range(minSorting, groups.Length + 1);
            sorting = true;
        }
    }

    private void OnEnable()
    {
        if(monsters.Length >0) SortingOneObject();
    }
}


