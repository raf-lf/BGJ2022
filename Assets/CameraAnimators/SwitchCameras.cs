using UnityEngine;
using Cinemachine;

public class SwitchCameras : MonoBehaviour
{
    private Animator anim;

    [SerializeField]
    private CinemachineVirtualCamera[] vCam;
    private int actualCamera;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        actualCamera = 1;
    }

    public void SwitchCamera(int indice)
    {
        for (int i = 0; i < vCam.Length; i++)
        {
            if(indice == i)
            {
                actualCamera = i;
                SwitchPriority();
                anim.Play(vCam[i].name);
                return;
            }
        }
    }

    public void SwitchPriority()
    {
        for (int i = 0; i < vCam.Length; i++)
        {
            if(i == actualCamera)
                vCam[i].Priority = 1;
            else
                vCam[i].Priority = 0;
        }
    }
}
