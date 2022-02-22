using UnityEngine;
using Cinemachine;

public class SwitchCameras : MonoBehaviour
{
    private Animator anim;

    [SerializeField]
    public CinemachineVirtualCamera[] vCam;
    public int actualCamera;

    private void OnEnable()
    {
        RoomStateController.UpdateRoom += UpdateCamera;
    }

    private void OnDisable()
    {
        RoomStateController.UpdateRoom += UpdateCamera;
    }

    private void Awake()
    {
        anim = GetComponent<Animator>();
        actualCamera = 0;
    }

    public void UpdateCamera()
    {
        SwitchCamera(RoomStateController.roomStateController.GetRoomIndex());
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
