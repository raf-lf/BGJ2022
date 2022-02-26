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
    public bool noCollider;

    private void Start()
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
        for (int i = 0; i < groups.Length; i++)
        {            
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
        foreach (var item in monsters) item.SetActive(false);

        for (int i = 0; i < monsters.Length; i++)
        {
            int index = Random.Range(0, monsters.Length + 1);
            if (i == index)
            {
                monsters[i].SetActive(true);
                Debug.Log("oi");
            }
            if(index != i)
            {

            }
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && !noCollider)
        {
            foreach (var item in groups) item.SetActive(false);
            randomValue = Random.Range(minSorting, groups.Length + 1);
            sorting = true;
        }
    }

    private void OnEnable()
    {
        
        if (noCollider) SortingOneObject();
        
    }
}


