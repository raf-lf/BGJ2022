using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public int sanityValue;
    public int monsterLevel;
    public int timer;
    [SerializeField] GameObject[] monsters;
    void Awake()
    {
        StartCoroutine(InsanityCheck());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator InsanityCheck()
    {
        while (true)
        {
            yield return new WaitForSeconds(timer);
            //Debug.Log("OI");

            if(sanityValue == 0)
            {
                monsterLevel = 0;
            }
            if(sanityValue == 1)
            {
                monsterLevel = 1;
            }
            if(sanityValue == 2)
            {
                monsterLevel = 2;
            }

            for (int i = 0; i < monsters.Length; i++)
            {              
                if (i == monsterLevel)
                {
                    monsters[i].gameObject.SetActive(true);
                }
                if (i != monsterLevel)
                {
                    monsters[i].gameObject.SetActive(false);
                }           
            }
        }
    }
}
