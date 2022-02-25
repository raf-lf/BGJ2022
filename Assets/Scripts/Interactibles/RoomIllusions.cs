using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomIllusions : MonoBehaviour, IRoomComponent
{
    [Header("Illusions")]
    [SerializeField]
    private bool illusionActive;
    public float illusionCountdown = 15;
    public float illusionCountdownVariance = 5;
    [SerializeField]
    private float illusionTimer;
    private Animator illusionAnim;

    private Room connectedRoom;

    private void Awake()
    {
        connectedRoom = GetComponentInParent<Room>();
        illusionAnim = GetComponent<Animator>();
        connectedRoom.onEntry += EnteredRoom;
        connectedRoom.onExit += ExitedRoom;

    }

    public void EnteredRoom()
    {
        illusionTimer = Mathf.Clamp(illusionTimer + illusionCountdown + Random.Range(-illusionCountdownVariance, illusionCountdownVariance), 0, Mathf.Infinity);
    }

    public void ExitedRoom()
    {
        StartEndIllusion(false);
    }

    public void StartEndIllusion(bool on)
    {
        illusionActive = on;
        illusionAnim.SetBool("active", on);

        SanityManager.sanityScript.illusion = on;
    }

    private void Update()
    {
        if (GameManager.currentRoom == connectedRoom)
        {
            if (illusionTimer <= 0 && !illusionActive)
                StartEndIllusion(true);
            else
                illusionTimer = Mathf.Clamp(illusionTimer - Time.deltaTime, 0, Mathf.Infinity);
        }
    }
}
