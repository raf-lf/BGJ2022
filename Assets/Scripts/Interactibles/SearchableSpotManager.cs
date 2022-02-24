using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum itemSpawnType { timer, waitPickup }
public class SearchableSpotManager : MonoBehaviour
{
    [Header ("Item Spawn")]
    public int totalItemsToSpawn;
    [SerializeField]
    private int itemsAlreadySpawned;
    //public int itemsPerSpawn;

    [Header("Config")]
    public bool systemOn = true;
    public bool neverRepeatSpot = false;
    public bool ignoreLastSpot = false;
    public bool ignoreLastRoom = false;
    private SearchableSpot lastSpot;
    private Room lastRoom;
    public itemSpawnType spawnMechanics;

    [Header("Spawn Type: Timer")]
    [SerializeField]
    private float timer;
    public float startInterval;
    public float intervalBetweenSpawns;
    public float intervalVariance;

    [Header("Spawn Type: Wait Pickup")]
    public bool itemSpawned;

    [Header("Other")]
    public PlaySfx spawnSfx;
    [SerializeField]
    private List<SearchableSpot> finalValidSpots = new List<SearchableSpot>();
    [SerializeField]
    private List<SearchableSpot> spotsAlreadyUsed = new List<SearchableSpot>();

    private void Awake()
    {
        GameManager.rooms.AddRange(GetComponentsInChildren<Room>());

        foreach (var item in GameManager.rooms)
        {
            item.UpdateSpots();
        }
        
    }

    private void Start()
    {
        timer = startInterval;        
    }

    public void AttemptSpawn()
    {
        if (itemsAlreadySpawned < totalItemsToSpawn)
        {
            /*
            int spawnTimes = itemsPerSpawn;
            spawnTimes = Mathf.Clamp(spawnTimes, 0, (totalItemsToSpawn - itemsAlreadySpawned));
            if (spawnTimes > 0)
            {
                for (int i = spawnTimes; i > 0; i--)
                {
                    SpawnItem();
                }
            }
            */
            SpawnItem();

            if (itemsAlreadySpawned >= totalItemsToSpawn)
            {
                systemOn = false;
                Debug.Log("Items finished spawning!");

            }
        }

    }

    public void SpawnItem()
    {
        //Debug.Log("Starting new spot selection.");

        finalValidSpots.Clear();
        //Debug.Log("Cleared all spots list.");

        List<SearchableSpot> validSpots = new List<SearchableSpot>();

        //Gets all possible spot locations
        foreach (Room room in GameManager.rooms)
        {
            validSpots.AddRange(room.searchablesInRoom);
            finalValidSpots.AddRange(room.searchablesInRoom);
        }

       // Debug.Log("Added all spots");

        int avaliableSpots = validSpots.Count;

        foreach (var item in validSpots)
        {
            if (item.itemInside)
                avaliableSpots--;
        }
        if (avaliableSpots > 0)
        {
            //Ignores spots with items already on them
            foreach (SearchableSpot spot in validSpots)
            {
                if (spot.itemInside && finalValidSpots.Contains(spot))
                {
                    finalValidSpots.Remove(spot);
                }

            }

          //  Debug.Log("Removed filled spots");

            //Ignores spots that have already had an item spawned on them
            if (neverRepeatSpot)
            {
                foreach (SearchableSpot spot in validSpots)
                {
                    if (spotsAlreadyUsed.Contains(spot) && finalValidSpots.Contains(spot))
                    {
                        finalValidSpots.Remove(spot);
                    }
                }
            }

           // Debug.Log("Removed spots already used");

            //Ignores spot used on last interval
            if (ignoreLastSpot && finalValidSpots.Contains(lastSpot))
                finalValidSpots.Remove(lastSpot);

          //  Debug.Log("Removed last spot");

            //Ignores all spots inside the room where the last spot was used
            if (ignoreLastRoom)
            {
                foreach (SearchableSpot spot in validSpots)
                {
                    if (spot.transform.parent.GetComponent<Room>() == lastRoom && finalValidSpots.Contains(spot))
                        finalValidSpots.Remove(spot);

                }

            }

           // Debug.Log("Removed spots from last room");

            //If there are no spots available, resets everything.
            if (finalValidSpots.Count <= 0)
            {
                Debug.Log("No available spots. Restarting.");

                spotsAlreadyUsed.Clear();
                lastSpot = null;
                lastRoom = null;

                SpawnItem();
            }
            else
            {
                SearchableSpot chosenSpot = finalValidSpots[Random.Range(0, finalValidSpots.Count - 1)];

                chosenSpot.itemInside = true;

                spawnSfx.PlayInspectorSfx();
                itemsAlreadySpawned++;

                spotsAlreadyUsed.Add(chosenSpot);

                lastSpot = chosenSpot;
                lastRoom = chosenSpot.transform.parent.GetComponent<Room>();

                if (itemsAlreadySpawned == 1)
                    HintManager.scriptHint.Write(GameManager.rooms[GameManager.rooms.IndexOf(lastRoom)].GetStarterHint());
                else
                    HintManager.scriptHint.Write(GameManager.rooms[GameManager.rooms.IndexOf(lastRoom)].GetRoomHint());

                Debug.Log("Item spawned on spot " + lastSpot + " inside room " + lastRoom.name);

            }
        }
        else
            Debug.Log("No empty slots available!");

    }

    private void Update()
    {
        if (systemOn)
        {
            switch(spawnMechanics)
            {
                case itemSpawnType.timer:
                    if (timer <= 0)
                    {
                        timer = Mathf.Clamp(timer + intervalBetweenSpawns + Random.Range(-intervalVariance, intervalVariance), 0, Mathf.Infinity);
                        AttemptSpawn();
                    }
                    else
                        timer = Mathf.Clamp(timer - Time.deltaTime, 0, Mathf.Infinity);
                    break;

                case itemSpawnType.waitPickup:
                    if(!itemSpawned)
                    {
                        itemSpawned = true;
                        AttemptSpawn();
                    }
                    break;
            }
        }
    }

}
