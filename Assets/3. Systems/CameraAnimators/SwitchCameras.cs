using UnityEngine;
using Cinemachine;

public class SwitchCameras : MonoBehaviour
{
    private Animator anim;

    public CinemachineVirtualCamera[] vCam;
    public int atualCamera;

    private void OnEnable()
    {
        RoomStateController.UpdateRoom += UpdateCamera;
    }

    private void OnDisable()
    {
        RoomStateController.UpdateRoom -= UpdateCamera;
    }

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        UpdateCamera();
    }

    private void Update()
    {
        if (atualCamera != RoomStateController.roomStateController.atualCamera)
            UpdateCamera();
    }

    public void UpdateCamera()
    {
        atualCamera = RoomStateController.roomStateController.atualCamera;
        SwitchPriority();
        anim.Play(vCam[atualCamera].name);
    }

    public void SwitchPriority()
    {
        for (int i = 0; i < vCam.Length; i++)
        {
            if(i == atualCamera)
                vCam[i].Priority = 1;
            else
                vCam[i].Priority = 0;
        }
    }
}
