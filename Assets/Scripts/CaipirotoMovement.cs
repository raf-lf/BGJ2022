using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaipirotoMovement : MonoBehaviour
{
    [Header("Movement Controller")]
    public string state;
    public float timeToChangeRoom;
    public float stopInterval;
    public int minimumSpotVisitation;
    public int maximumSpotVisitation;
    public RoomToCreatureMovementManager roomManager;

    private int howManyTimeWillStayInARoom;
    private int timeStayedInARoom;
    private RoomCreatureMovement atualRoom;
    private Transform atualSpot;
    private Transform nextSpot;
    private Vector3 moveDirection;
    private bool isWaiting = true;
    private bool startMoving = false;

    [Header("Movement Configs")]
    public float movementSpeed;

    private void Start()
    {
        RandomizeRoom();
    }

    private void Update()
    {
        if(moveDirection != Vector3.zero)
        {
            transform.Translate(moveDirection * movementSpeed * Time.deltaTime);
        }

        if(nextSpot != null)
        {
            if(Vector3.Distance(nextSpot.position, transform.position) < 0.5f && !isWaiting && startMoving)
            {
                isWaiting = true;
                moveDirection = Vector3.zero;
                Invoke("FindNextSpot", stopInterval);
            }
        }

        if(timeStayedInARoom >= howManyTimeWillStayInARoom)
        {
            // Make the animation to Caipiroto disappears

            RandomizeRoom();
        }
    }

    public void RandomizeRoom()
    {
        isWaiting = true;
        moveDirection = Vector3.zero;
        startMoving = false;

        atualRoom = roomManager.GetRandomRoomBetweenAdjacents(state);
        atualSpot = atualRoom.GetRandomSpot();
        state = atualRoom.roomName;

        timeStayedInARoom = 0;

        howManyTimeWillStayInARoom = Random.Range(minimumSpotVisitation, maximumSpotVisitation);
        
        transform.position = atualSpot.position;
        isWaiting = true;

        // Make the animation to Caipiroto appears

        if (isWaiting)
        {
            Invoke("FindNextSpot", timeToChangeRoom);
        }
    }

    public void FindNextSpot()
    {
        if (timeStayedInARoom < howManyTimeWillStayInARoom)
        {
            timeStayedInARoom += 1;
        }

        nextSpot = atualSpot;

        while(nextSpot == atualSpot)
        {
            nextSpot = atualRoom.GetRandomSpot();
        }

        FindDirectionToNextSpot();
        isWaiting = false;
    }

    public void FindDirectionToNextSpot()
    {
        Vector3 nSpot = nextSpot.position;
        Vector3 cPos = transform.position;

        nSpot.y = 0;
        cPos.y = 0;

        Vector3 movement = nSpot - cPos;
        moveDirection = movement.normalized;

        startMoving = true;
    }
}