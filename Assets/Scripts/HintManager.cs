using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HintManager : MonoBehaviour
{
    public static HintManager scriptHint;
    public TextMeshProUGUI hintText;

    [TextArea(2,4)]
    public string endHint;

    private void Awake()
    {
        scriptHint = this;
        
    }

    public void Write(string hint)
    {
        GetComponent<Animator>().SetTrigger("write");
        hintText.text = hint;
    }

    public void ShowEndHint()
    {
        Write(endHint);
    }

}
