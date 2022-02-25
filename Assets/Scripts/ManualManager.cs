using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualManager : MonoBehaviour
{
    public Animator manualAnim;
    public Animator iconAnim;

    public void GoPage(bool advance)
    {
        if (advance)
            manualAnim.SetInteger("page", manualAnim.GetInteger("page") + 1);
        else
            manualAnim.SetInteger("page", manualAnim.GetInteger("page") - 1);

    }
    public void OpenClose(bool open)
    {

    }
}
