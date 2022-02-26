using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectAnimState : MonoBehaviour
{
    Animator animator;
    public string animState;
    int timer;

    private void OnEnable()
    {
        StartCoroutine(Delay());
    }

    void Start()
    {
        animator = GetComponent<Animator>();        
    }

    IEnumerator Delay()
    {
        timer = Random.Range(0, 4);
        yield return new WaitForSeconds(timer);
        animator.Play(animState);
    }
}
