using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterLevel : MonoBehaviour
{
 
    int monsterLevel;
    public int timer;
    SanityManager sanityManager;
    float sanityValue;
    public Animator animator;


    void Awake()
    {
        StartCoroutine(InsanityCheck());        
    }

    private void OnEnable()
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

            animator.SetInteger("level", monsterLevel);
        }
    }
}
