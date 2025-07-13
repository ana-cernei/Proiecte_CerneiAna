using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class DogBehavior : MonoBehaviour
{
    // Referinta la Animatorul cainelui pentru schimbarea animatiilor in functie de stare
    public Animator animator;

    // Transformul bolului de mancare - pozitia unde cainele trebuie sa ajunga pentru a manca
    public Transform foodBowl;

    // Punctul tinta langa bol (unde trebuie sa ajunga agentul NavMesh)
    public Transform foodBowlTarget;

    // Doua obiecte diferite pentru carnea ce va fi afisata/ascunsa la fiecare faza de mancat
    public Transform meatPart1;
    public Transform meatPart2;

    // Pozitia de start a cainelui in scena
    public Transform startPosition;

    // Agentul NavMesh pentru miscarea automata a cainelui intre puncte din scena
    private NavMeshAgent agent;

    // Distanta minima la care consideram ca a ajuns la destinatie
    private float stoppingDistance = 0.3f;

    // Componenta AudioSource de pe caine, pentru redarea sunetelor
    private AudioSource dogAudio;

    // Sunete diferite pentru stari/actiuni diferite
    public AudioClip breathingSound;
    public AudioClip tailWagSound;
    public AudioClip eatingSound;

    // Definim starile posibile ale cainelui
    private enum DogState
    {
        ReturningToStart,     // Merge la pozitia initiala
        Breathing,            // Sta si respira (idle)
        WigglingTail,         // Da din coada (bucuros)
        WalkingToBowl,        // Merge spre bolul de mancare
        Eating,               // Mananca prima data
        WigglingTailAgain,    // Da din coada din nou
        EatingAgain,          // Mananca a doua oara
        Sitting               // Sta jos dupa ce termina tot
    }
    private DogState currentState = DogState.ReturningToStart; // Starea curenta in care se afla cainele
    private DogState savedState; // Salvam starea curenta daca trebuie sa reactioneze la jucator

    private bool isReacting = false; // Flag ca sa nu intre de doua ori in reactie

    private float savedTimer; // Temporizator pentru starile unde avem nevoie de un timp exact (ex: mancat)

    private Quaternion savedRotation; // Rotatia initiala pe care o salvam inainte sa se intoarca spre jucator

    void Start()
    {
        // Initializam referintele catre componente
        agent = GetComponent<NavMeshAgent>();
        dogAudio = GetComponent<AudioSource>();

        // Verificam daca toate componentele importante sunt setate corect
        if (agent == null)
        {
            Debug.LogError("NavMeshAgent lipseste pe caine!");
            return;
        }
        if (foodBowl == null || foodBowlTarget == null || startPosition == null)
        {
            Debug.LogError("Bolul de mancare, FoodBowlTarget sau StartPosition nu sunt setate in Inspector!");
            return;
        }
        if (meatPart1 == null || meatPart2 == null)
        {
            Debug.LogError("Obiectele de carne nu sunt setate in Inspector!");
            return;
        }
        if (dogAudio == null)
        {
            Debug.LogError("AudioSource lipseste!");
            return;
        }

        // La inceput a doua bucata de carne e ascunsa 
        meatPart2.gameObject.SetActive(false);

        // Setam distanta minima la care cainele se opreste la destinatie
        agent.stoppingDistance = stoppingDistance;
        agent.isStopped = false;

        // Pornim rutina principala
        StartCoroutine(DogRoutine());
    }

    // Rutina principala care controleaza tranzitiile intre starile cainelui
    IEnumerator DogRoutine()
    {
        while (true)
        {
            switch (currentState)
            {
                case DogState.ReturningToStart:
                    // Cainele merge la pozitia initiala (poate fi folosit ca resetare la inceputul ciclului)
                    agent.isStopped = false;
                    agent.SetDestination(startPosition.position);
                    animator.SetInteger("AnimationID", 2); // Animatie de mers

                    // Asteapta pana cand agentul ajunge aproape de destinatie
                    yield return new WaitUntil(() => !agent.pathPending && agent.remainingDistance <= stoppingDistance);
                    agent.isStopped = true;

                    //Afisam doar prima bucata de carne
                    meatPart1.gameObject.SetActive(true);
                    meatPart2.gameObject.SetActive(false);

                    currentState = DogState.Breathing;
                    break;

                case DogState.Breathing:
                    // Cainele sta pe loc si face animatie idle (respira)
                    animator.SetInteger("AnimationID", 0);
                    PlaySound(breathingSound, true); // Sunet de respiratie

                    // Sta in starea aceasta 10 secunde
                    yield return new WaitForSeconds(10f);

                    StopSound();
                    currentState = DogState.WigglingTail;
                    break;

                case DogState.WigglingTail:
                    // Animatia de dat din coada
                    animator.SetInteger("AnimationID", 1);
                    PlaySound(tailWagSound, true);

                    yield return new WaitForSeconds(5f);

                    StopSound();
                    currentState = DogState.WalkingToBowl;
                    break;

                case DogState.WalkingToBowl:
                    // Cainele merge spre bolul de mancare (tinta e aproape de bol, nu chiar pe bol)
                    agent.isStopped = false;
                    agent.SetDestination(foodBowlTarget.position);
                    animator.SetInteger("AnimationID", 2); // Animatie de mers

                    // Asteapta sa ajunga aproape de bol
                    yield return new WaitUntil(() => !agent.pathPending && agent.remainingDistance <= stoppingDistance);
                    agent.isStopped = true;
                    currentState = DogState.Eating;
                    break;

                case DogState.Eating:
                    // Cainele mananca pentru prima data
                    animator.SetInteger("AnimationID", 5); // Animatie de mancat
                    PlaySound(eatingSound, true);
                  

                    // Cronometram manual timpul cat mananca
                    savedTimer = 0f;
                    while (savedTimer < 13f)
                    {
                        savedTimer += Time.deltaTime;
                        yield return null;
                    }

                    // Schimbam vizibilitatea carnii: prima dispare, a doua apare (efect vizual de "mancat")
                    meatPart1.gameObject.SetActive(false);
                    meatPart2.gameObject.SetActive(true);

                    currentState = DogState.WigglingTailAgain;
                    break;

                case DogState.WigglingTailAgain:
                    // Da din coada din nou, de exemplu pentru a arata satisfactie dupa ce a mancat o parte din carne
                    animator.SetInteger("AnimationID", 1);
                    PlaySound(tailWagSound, true);

                    yield return new WaitForSeconds(0f); 

                    StopSound();
                    currentState = DogState.EatingAgain;
                    break;

                case DogState.EatingAgain:
                    // A doua sesiune de mancat
                    animator.SetInteger("AnimationID", 5);
                    PlaySound(eatingSound, false);

                    savedTimer = 0f;
                    while (savedTimer < 13f)
                    {
                        savedTimer += Time.deltaTime;
                        yield return null;
                    }

                    // Dupa ce termina, dispare si a doua bucata de carne
                    meatPart2.gameObject.SetActive(false);

                    currentState = DogState.Sitting;
                    break;

                case DogState.Sitting:
                    // Cainele se aseaza jos, semn ca e satul si relaxat
                    animator.SetInteger("AnimationID", 7);
                    yield return new WaitForSeconds(10f); // Sta jos 10 secunde
                    PlaySound(breathingSound, true);

                    // Dupa perioada de relaxare, reia tot ciclul
                    currentState = DogState.ReturningToStart;
                    break;
            }
            yield return null;
        }
    }

    // Porneste un sunet dat ca parametru; poate fi setat sa ruleze in loop sau nu
    void PlaySound(AudioClip clip, bool loop)
    {
        if (dogAudio != null && clip != null)
        {
            dogAudio.clip = clip;
            dogAudio.loop = loop;
            dogAudio.Play();
        }
    }

    // Opreste orice sunet care se aude la acel moment
    void StopSound()
    {
        if (dogAudio.isPlaying)
        {
            dogAudio.Stop();
        }
    }

    // Metoda publica ce poate fi apelata din exterior pentru ca cainele sa reactioneze temporar la jucator
    // Ex: cand jucatorul apasa pe buton
    public void ReactToPlayer(Transform player)
    {
        if (isReacting) return; // Nu intra in reactie daca deja este in reactie

        // Salvam starea si rotatia curenta pentru a reveni la ele dupa reactie
        savedState = currentState;
        savedRotation = transform.rotation;
        isReacting = true;

        // Oprim toate corutinele curente (DogRoutine) si pornim rutina de reactie
        StopAllCoroutines();
        StartCoroutine(TemporaryReaction(player));
    }

    // Rutina temporara cand cainele reactioneaza la jucator (ex: intoarce capul si da din coada)
    private IEnumerator TemporaryReaction(Transform player)
    {
        // Rotim cainele sa se uite catre pozitia jucatorului (pe orizontala)
        Vector3 lookDirection = player.position - transform.position;
        lookDirection.y = 0; // Ignoram diferenta de inaltime
        transform.rotation = Quaternion.LookRotation(lookDirection);

        // Pornim animatia si sunetul de dat din coada
        animator.SetInteger("AnimationID", 1);
        PlaySound(tailWagSound, true);

        // Sta in aceasta stare 5 secunde
        yield return new WaitForSeconds(5f);

        StopSound();

        // Dupa reactie, cainele revine la rotatia originala si la starea de dinainte
        transform.rotation = savedRotation;
        isReacting = false;
        currentState = savedState;
        StartCoroutine(DogRoutine());
    }
}
