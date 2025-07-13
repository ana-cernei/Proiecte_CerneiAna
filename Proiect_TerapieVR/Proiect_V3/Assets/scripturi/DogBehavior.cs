using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class DogBehavior : MonoBehaviour
{
    // Componente Unity si obiecte din scena
    public Animator animator;
    public Transform foodBowl;
    public Transform foodBowlTarget;
    public Transform meatPart1;
    public Transform meatPart2;
    public Transform startPosition;

    private NavMeshAgent agent;
    private float stoppingDistance = 0.3f;
    private AudioSource dogAudio;

    // Sunete folosite pentru comportamentele cainelui
    public AudioClip breathingSound;
    public AudioClip tailWagSound;
    public AudioClip eatingSound;

    // Enumerare a starilor posibile ale cainelui
    private enum DogState { ReturningToStart, Breathing, WigglingTail, WalkingToBowl, Eating, WigglingTailAgain, EatingAgain, Sitting }
    private DogState currentState = DogState.ReturningToStart;
    private DogState savedState;

    private bool isReacting = false;
    private float savedTimer;
    private Quaternion savedRotation;

    void Start()
    {
        // Initializare componente
        agent = GetComponent<NavMeshAgent>();
        dogAudio = GetComponent<AudioSource>();

        // Verificari pentru componente lipsa
        if (agent == null)
        {
            Debug.LogError("NavMeshAgent lipseste de pe caine");
            return;
        }

        if (foodBowl == null || foodBowlTarget == null || startPosition == null)
        {
            Debug.LogError("FoodBowl, FoodBowlTarget sau StartPosition nu sunt setate in Inspector");
            return;
        }

        if (meatPart1 == null || meatPart2 == null)
        {
            Debug.LogError("Obiectele de carne nu sunt setate in Inspector.");
            return;
        }

        if (dogAudio == null)
        {
            Debug.LogError("AudioSource lipseste de pe obiectul Dog");
            return;
        }

        // Se ascunde a doua bucata de carne
        meatPart2.gameObject.SetActive(false);

        agent.stoppingDistance = stoppingDistance;
        agent.isStopped = false;

        // Porneste rutina comportamentala
        StartCoroutine(DogRoutine());
    }

    // Secventa comportamentala a cainelui
    IEnumerator DogRoutine()
    {
        while (true)
        {
            switch (currentState)
            {
                case DogState.ReturningToStart:
                    // Cainelui i se seteaza destinatia la pozitia initiala
                    agent.isStopped = false;
                    agent.SetDestination(startPosition.position);
                    animator.SetInteger("AnimationID", 2); // animatie mers

                    yield return new WaitUntil(() => !agent.pathPending && agent.remainingDistance <= stoppingDistance);
                    agent.isStopped = true;

                    meatPart1.gameObject.SetActive(true);
                    meatPart2.gameObject.SetActive(false);

                    currentState = DogState.Breathing;
                    break;

                case DogState.Breathing:
                    animator.SetInteger("AnimationID", 0); // animatie idle
                    PlaySound(breathingSound, true);

                    yield return new WaitForSeconds(3f);

                    StopSound();
                    currentState = DogState.WigglingTail;
                    break;

                case DogState.WigglingTail:
                    animator.SetInteger("AnimationID", 1); // animatie coada
                    PlaySound(tailWagSound, true);

                    yield return new WaitForSeconds(0f); // timp simbolic
                    StopSound();

                    currentState = DogState.WalkingToBowl;
                    break;

                case DogState.WalkingToBowl:
                    agent.isStopped = false;
                    agent.SetDestination(foodBowlTarget.position);
                    animator.SetInteger("AnimationID", 2); // animatie mers

                    yield return new WaitUntil(() => !agent.pathPending && agent.remainingDistance <= stoppingDistance);
                    agent.isStopped = true;

                    currentState = DogState.Eating;
                    break;

                case DogState.Eating:
                    animator.SetInteger("AnimationID", 5); // animatie mancat
                    PlaySound(eatingSound, false);
                    savedTimer = 0f;

                    while (savedTimer < 13f)
                    {
                        savedTimer += Time.deltaTime;
                        yield return null;
                    }

                    meatPart1.gameObject.SetActive(false);
                    meatPart2.gameObject.SetActive(true);

                    currentState = DogState.WigglingTailAgain;
                    break;

                case DogState.WigglingTailAgain:
                    animator.SetInteger("AnimationID", 1);
                    PlaySound(tailWagSound, true);

                    yield return new WaitForSeconds(0f);
                    StopSound();

                    currentState = DogState.EatingAgain;
                    break;

                case DogState.EatingAgain:
                    animator.SetInteger("AnimationID", 5);
                    PlaySound(eatingSound, false);
                    savedTimer = 0f;

                    while (savedTimer < 13f)
                    {
                        savedTimer += Time.deltaTime;
                        yield return null;
                    }

                    meatPart2.gameObject.SetActive(false);
                    currentState = DogState.Sitting;
                    break;

                case DogState.Sitting:
                    animator.SetInteger("AnimationID", 7); // animatie sezut
                    yield return new WaitForSeconds(5f);

                    currentState = DogState.ReturningToStart;
                    break;
            }
            yield return null;
        }
    }

    // Redare sunet specific cu optiune de loop
    void PlaySound(AudioClip clip, bool loop)
    {
        if (dogAudio != null && clip != null)
        {
            dogAudio.clip = clip;
            dogAudio.loop = loop;
            dogAudio.Play();
        }
    }

    // Oprirea sunetului curent
    void StopSound()
    {
        if (dogAudio.isPlaying)
        {
            dogAudio.Stop();
        }
    }

    // Reactia temporara a cainelui la prezenta jucatorului
    public void ReactToPlayer(Transform player)
    {
        if (isReacting) return;

        savedState = currentState;
        savedRotation = transform.rotation;
        isReacting = true;

        StopAllCoroutines();
        StartCoroutine(TemporaryReaction(player));
    }

    // Animatia si comportamentul temporar de reactie la jucator
    private IEnumerator TemporaryReaction(Transform player)
    {
        // Cainele se intoarce catre jucator
        Vector3 lookDirection = player.position - transform.position;
        lookDirection.y = 0;
        transform.rotation = Quaternion.LookRotation(lookDirection);

        animator.SetInteger("AnimationID", 1);
        PlaySound(tailWagSound, true);

        yield return new WaitForSeconds(5f);

        StopSound();

        // Revine la rotatia initiala
        transform.rotation = savedRotation;

        isReacting = false;
        currentState = savedState;
        StartCoroutine(DogRoutine());
    }
}
