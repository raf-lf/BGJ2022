using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualManager : MonoBehaviour
{
    public Animator manualAnim;
    public int pageQty;
    private bool paused;
    
    public void GoPage(bool advance)
    {
        int currentPage = manualAnim.GetInteger("page");

        if (advance)
            currentPage++;
        else
            currentPage--;

        currentPage = Mathf.Clamp(currentPage, 1, pageQty);

        manualAnim.SetInteger("page", currentPage);

    }
    public void OpenClose()
    {
        manualAnim.SetBool("active", !manualAnim.GetBool("active"));
        paused = !paused;

        if (paused)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;

    }
}
