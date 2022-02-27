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
    private Vector3 caipirotoPositionFixed;
    private Vector3 nextPointPositionFixed;
    private float movingTime;

    private int howManyTimeWillStayInARoom;
    private int timeStayedInARoom;
    private RoomCreatureMovement atualRoom;
    private Transform atualSpot;
    private Transform nextSpot;
    private Vector3 moveDirection;
    private bool isWaiting = true;
    private bool startMoving = false;
    private bool canTeleport = true;

    [Header("Movement Configs")]
    public float movementSpeed;

    [Header("Teleport")]
    public ParticleSystem vfxTeleport;
    public PlaySfx sfxTeleport;

    private void Start()
    {
        // Com essa fun��o eu:
        // - Primeiramente Paro a criatura
        // - Pego uma sala aleat�ria
        // - Pego um ponto aleat�rio dessa sala
        // - Zero o contador de movimentos
        // - Realizo os efeitos (sonoros e visuais) de teletransporte
        // - Programo para ele ir para o pr�ximo ponto
        RandomizeRoom();
    }

    private void Update()
    {
        caipirotoPositionFixed.x = transform.position.x;
        caipirotoPositionFixed.z = transform.position.z;

        if(moveDirection != Vector3.zero && startMoving)                            // Se eu tiver uma dire��o e puder me movimentar...
        {
            transform.Translate(moveDirection * movementSpeed * Time.deltaTime);    // ...Eu me movo na dire��o desejada em determinada velocidade.
            movingTime += Time.deltaTime;
        }

        if(nextSpot != null)        // Se eu tiver um novo ponto, eu executo isso.
        {
            // Se a dist�ncia entre a criatura e o ponto que est� se movendo foi pequena eu posso executar essas coisas.
            if(Vector3.Distance(nextPointPositionFixed, caipirotoPositionFixed) < 0.5f && !isWaiting && startMoving)
            {

                // Se eu passei do tempo que posso ficar na sala e posso teletransportar...
                if(timeStayedInARoom >= howManyTimeWillStayInARoom && canTeleport)
                {
                    canTeleport = false;                                    // N�o posso mais teletransportar.

                    Invoke(nameof(RandomizeRoom), timeToChangeRoom);        // Aleatorizo a sala
                }
                // Se eu n�o passei do tempo que posso ficar na sala...
                else
                {
                    isWaiting = true;                       // Come�o a esperar
                    moveDirection = Vector3.zero;           // Zero minha velocidade
                    startMoving = false;                    // Paro de me mover
                    movingTime = 0;

                    // Com essa fun��o eu:
                    // - Aumento a quantidade de movimentos em 1
                    // - Gero um novo spot aleat�rio
                    // - Encontro uma nova dire��o
                    // - Digo que n�o vou mais esperar para me movimentar.
                    Invoke(nameof(FindNextSpot), stopInterval);
                }
            }
        }

        if(movingTime >= 2f && !isWaiting && startMoving)
        {
            isWaiting = true;
            moveDirection = Vector3.zero;
            startMoving = false;
            movingTime = 0;

            Invoke(nameof(FindNextSpot), stopInterval);
        }
    }

    public void RandomizeRoom()
    {
        isWaiting = true;                   // Estou esperando gerar um aleatorio.
        moveDirection = Vector3.zero;       // Zero meu movimento para que eu fique parado.
        startMoving = false;                // Desligo o start moving para que eu nao me mexa mesmo.

        atualRoom = roomManager.GetRandomRoomBetweenAdjacents(state);   // Randomizo minha sala atual
        atualSpot = atualRoom.GetRandomSpot();                          // Pego um spot aleatorio dentro da sala que eu aleatorizei
        state = atualRoom.roomName;                                     // Mudo meu estado para o da sala atual

        timeStayedInARoom = 0;                                                                      // Zero o contador de movimentos
        howManyTimeWillStayInARoom = Random.Range(minimumSpotVisitation, maximumSpotVisitation);    // Gero um aleatorio de movimentos

        canTeleport = true;                                             // Posso me teletransportar
        GetComponent<Animator>().SetTrigger("teleport");                // Fa�o a anima��o do Teletransporte.
    }

    public void FindNextSpot()
    {
        if (timeStayedInARoom < howManyTimeWillStayInARoom)     // Se eu ainda nao ultrapassei a quantidade de movimentos...
        {
            timeStayedInARoom += 1;                             // ...Eu aumento a quantidade de movimentos em 1
        }

        nextSpot = atualSpot;                                   // O proximo spot que foi calculado � normalizado

        while(nextSpot == atualSpot)                            // Enquanto o pr�ximo spot for igual ao meu spot...
        {
            nextSpot = atualRoom.GetRandomSpot();               // ...Eu pego um novo spot aleat�rio.
        }

        nextPointPositionFixed = nextSpot.position;             // Pego a proxima posi��o para analizar a dist�ncia
        nextPointPositionFixed.y = 0;                           // Ajusto a proxima posi��o para analizar a dist�ncia

        FindDirectionToNextSpot();          // Encontro a dire��o baseada no nextStep;
        isWaiting = false;                  // N�o estou mais esperando, ou seja, j� posso me movimentar.
    }

    public void Teleport()
    {
        transform.position = atualSpot.position;                        // Me teletransporto *****

        if (isWaiting)                                      // Se eu estiver esperando (e estou)
        {
            Invoke(nameof(FindNextSpot), stopInterval);     // Programo para encontrar um novo ponto daqui a x tempo.
        }
    }

    public void CreatureAppear()
    {
        sfxTeleport.PlayInspectorSfx();                                 // Fa�o o som de me teletransportar
        vfxTeleport.Play();                                             // Fa�o o efeito de me teletransportar
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
        movingTime = 0;
    }
}