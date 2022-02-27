using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualManager : MonoBehaviour
{
    public Animator manualAnim;
    public int pageQty;
    private bool paused;
    public PlaySfx sfxConfirm1;
    public PlaySfx sfxConfirm2;
    public PlaySfx sfxCancel;
    
    public void GoPage(bool advance)
    {
        int currentPage = manualAnim.GetInteger("page");

        if (advance)
        {
            sfxConfirm1.PlayInspectorSfx();
            currentPage++;
        }
        else
        {
            sfxConfirm2.PlayInspectorSfx();
            currentPage--;
        }

        currentPage = Mathf.Clamp(currentPage, 1, pageQty);

        manualAnim.SetInteger("page", currentPage);

    }
    public void OpenClose()
    {
        manualAnim.SetBool("active", !manualAnim.GetBool("active"));
        paused = !paused;

        if (paused)
        {
            sfxConfirm2.PlayInspectorSfx();
            Time.timeScale = 0;
        }
        else
        {
            sfxCancel.PlayInspectorSfx();
            Time.timeScale = 1;
        }

    }
}
