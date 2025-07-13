using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class DogBehavior : MonoBehaviour
{
    public Animator animator;           // referinta la componenta Animator
    public Transform foodBowl;          // pozitia bolului de mancare
    public Transform foodBowlTarget;    // punctul de destinatie pentru agent langa bol
    public Transform meatPart1;         // prima jumatate de carne
    public Transform meatPart2;         // a doua jumatate de carne
    public Transform startPosition;     // pozitia initiala a cainelui

    private NavMeshAgent agent;         // agentul de navigatie NavMeshAgent
    private float stoppingDistance = 0.3f;  // distanta minima pentru a considera ca agentul a ajuns

    // definim starile prin care trece cainele
    private enum DogState { ReturningToStart, Breathing, WigglingTail, WalkingToBowl, Eating, WigglingTailAgain, EatingAgain, Sitting }
    private DogState currentState = DogState.ReturningToStart;  // incepem ciclul cu revenirea la start

    void Start()
    {
        // obtinem componenta NavMeshAgent de pe acelasi GameObject
        agent = GetComponent<NavMeshAgent>();
        if (agent == null)
        {
            Debug.LogError("NavMeshAgent lipseste pe caine!");
            return;
        }

        // verificam referintele in Inspector pentru pozitiile si obiectele necesare
        if (foodBowl == null || foodBowlTarget == null || startPosition == null)
        {
            Debug.LogError("Bolul de mancare, foodBowlTarget sau startPosition nu sunt setate in Inspector!");
            return;
        }

        if (meatPart1 == null || meatPart2 == null)
        {
            Debug.LogError("Obiectele de carne nu sunt setate in Inspector!");
            return;
        }

        // ascundem a doua jumatate de carne la inceputul scenariului
        meatPart2.gameObject.SetActive(false);

        // setam distanta de oprire si activam agentul
        agent.stoppingDistance = stoppingDistance;
        agent.isStopped = false;

        // pornim corutina care gestioneaza comportamentul in timp
        StartCoroutine(DogRoutine());
    }

    IEnumerator DogRoutine()
    {
        while (true)
        {
            switch (currentState)
            {
                case DogState.ReturningToStart:
                    Debug.Log("Cainele revine la pozitia initiala...");
                    agent.isStopped = false;
                    agent.SetDestination(startPosition.position);
                    animator.SetInteger("AnimationID", 2);  // animatie de mers

                    // asteptam sa ajunga aproape de destinatie
                    yield return new WaitUntil(() => !agent.pathPending && agent.remainingDistance <= stoppingDistance);

                    // oprim agentul si resetam viteza
                    agent.isStopped = true;
                    agent.velocity = Vector3.zero;

                    // readucem obiectele de carne in starea initiala
                    meatPart1.gameObject.SetActive(true);
                    meatPart2.gameObject.SetActive(false);

                    // schimbam starea catre respiratie
                    currentState = DogState.Breathing;
                    break;

                case DogState.Breathing:
                    animator.SetInteger("AnimationID", 0);  // animatie de respirat
                    yield return new WaitForSeconds(5f);   // asteptam 5 secunde
                    currentState = DogState.WigglingTail;  // trecem la miscarea cozii
                    break;

                case DogState.WigglingTail:
                    animator.SetInteger("AnimationID", 1);  // animatie coada
                    yield return new WaitForSeconds(5f);
                    currentState = DogState.WalkingToBowl;  // catre bolul de mancare
                    break;

                case DogState.WalkingToBowl:
                    Debug.Log("Cainele merge spre bol...");
                    agent.isStopped = false;
                    agent.SetDestination(foodBowlTarget.position);
                    animator.SetInteger("AnimationID", 2);  // animatie de mers

                    // asteptam sa ajunga la bol
                    yield return new WaitUntil(() => !agent.pathPending && agent.remainingDistance <= stoppingDistance);

                    // oprim agentul si resetam viteza
                    agent.isStopped = true;
                    agent.velocity = Vector3.zero;

                    // rotim cainele spre bol pentru o orientare naturala
                    Quaternion targetRotation = Quaternion.LookRotation(foodBowl.position - transform.position);
                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);

                    currentState = DogState.Eating;  // incepem sa manance
                    break;

                case DogState.Eating:
                    animator.SetInteger("AnimationID", 5);  // animatie de mancat
                    yield return new WaitForSeconds(8f);    // timp initial de mancat
                    yield return new WaitForSeconds(5f);    // pauza scurta

                    // schimbam carnea: ascundem prima jumatate, afisam a doua
                    meatPart1.gameObject.SetActive(false);
                    meatPart2.gameObject.SetActive(true);

                    yield return new WaitForSeconds(5f);
                    currentState = DogState.WigglingTailAgain;  // coada dupa prima portie
                    break;

                case DogState.WigglingTailAgain:
                    animator.SetInteger("AnimationID", 1);  // animatie coada
                    yield return new WaitForSeconds(5f);
                    currentState = DogState.EatingAgain;    // mai mananca inca o tura
                    break;

                case DogState.EatingAgain:
                    animator.SetInteger("AnimationID", 5);
                    yield return new WaitForSeconds(21f);   // timp pentru a doua portie

                    // ascundem si ultima parte de carne
                    meatPart2.gameObject.SetActive(false);
                    currentState = DogState.Sitting;        // se aseaza
                    break;

                case DogState.Sitting:
                    animator.SetInteger("AnimationID", 7);  // animatie de stat jos
                    yield return new WaitForSeconds(5f);    // sta jos cateva secunde

                    // revenim la starea initiala pentru a relua ciclul
                    currentState = DogState.ReturningToStart;
                    break;
            }

            // asteptam urmatorul frame inainte de a continua
            yield return null;
        }
    }
}
