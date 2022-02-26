using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterLevel : MonoBehaviour
{
 
    public int monsterLevel;
    public int timer;
    [SerializeField] GameObject[] monsters;
    public SanityManager sanityManager;
    public float sanityValue;
    public bool levelChanged;
    bool IsIdle;
    void Awake()
    {
        StartCoroutine(InsanityCheck());
        
    }

    // Update is called once per frame
    private void Start()
    {
        sanityManager = FindObjectOfType<SanityManager>();
        
    }
    
    IEnumerator InsanityCheck()
    {
        while (true)
        {
            yield return new WaitForSeconds(timer);
            sanityValue = sanityManager.sanity;

            if(sanityValue < 100 && sanityValue >= 66)
            {
                monsterLevel = 0;
            } 
            if(sanityValue < 66 && sanityValue >= 33)
            {
                monsterLevel = 1;
            } 
            if(sanityValue < 33 && sanityValue >= 00)
            {
                monsterLevel = 2;
            }

            if (sanityValue > 98)
            {
                levelChanged = true;
                levelChanged = false;
            }
            if (sanityValue > 66 && sanityValue < 68)
            {
                levelChanged = true;
                levelChanged = false;
            }
            if (sanityValue > 33 && sanityValue < 35)
            {
                levelChanged = true;
                levelChanged = false;
            }

            SelectMonsterLevel();

        }
    }

    void SelectMonsterLevel()
    {

        for (int i = 0; i < monsters.Length; i++)
        {
            if (i == monsterLevel && levelChanged)
            {
                monsters[i].GetComponent<Animator>().Play("MonsterIn");
            }
            if (i != monsterLevel && levelChanged)
            {
                monsters[i].GetComponent<Animator>().Play("MonsterOut");
            }
        }
        
        
    }

    
}
