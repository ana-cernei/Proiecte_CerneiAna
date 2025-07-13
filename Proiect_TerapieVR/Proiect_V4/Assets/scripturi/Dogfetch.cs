using UnityEngine;
using UnityEngine.AI;

// Script care controleaza comportamentul unui caine ce aduce mingea inapoi la utilizator ("fetch")
// Cainele porneste automat dupa ce mingea este aruncata, o ia in gura si o aduce la punctul de intoarcere
[RequireComponent(typeof(NavMeshAgent))]
public class Dogfetch : MonoBehaviour
{
    public Transform ball;             // Mingea care va fi adusa inapoi
    public Transform returnTarget;     // Punctul unde cainele trebuie sa aduca mingea
    public Animator animator;          // Animatorul pentru animatiile cainelui

    // Sunet de alergare 
    public AudioSource runAudioSource;

    // Setari pentru logica fetch:
    public float fetchDistance = 1f;           // Distanta la care cainele considera ca a ajuns la minge
    public float ballStopSpeedThreshold = 0.1f;// Prag de viteza ca sa considere ca mingea s-a oprit

    private NavMeshAgent agent;        // Agentul NavMesh pentru miscare automata
    private Rigidbody ballRb;          // Rigidbody-ul mingii pentru verificarea vitezei
    private bool isFetching = false;   // Daca cainele este in procesul de fetch
    private bool hasBall = false;      // Daca tine mingea in gura
    private PickUpBall pickupScript;   // Scriptul de pe minge care retine starea ei

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.stoppingDistance = 0.5f;

        // Setam referintele la mingea si scriptul ei
        if (ball != null)
        {
            ballRb = ball.GetComponent<Rigidbody>();
            pickupScript = ball.GetComponent<PickUpBall>();
            ball.SetParent(null); // Mingea nu mai sta ca "child" la nimic la start
        }
        else
        {
            Debug.LogError("Dogfetch: Referinta la 'ball' nu e setata!");
        }

        // Verificam daca avem sunet de alergare setat
        if (runAudioSource == null)
        {
            Debug.LogWarning("Dogfetch: runAudioSource nu e setat in Inspector.");
        }
    }

    void Update()
    {
        // Daca nu avem referinta la pickupScript sau mingea este tinuta inca de jucator, nu pornim logica fetch
        if (pickupScript == null)
            return;
        if (pickupScript.IsHeld())
            return;

        // Daca mingea nu a fost aruncata, asteptam
        if (!pickupScript.wasThrown)
            return;

        // Daca fetch-ul nu a inceput inca si mingea are viteza aproape zero (s-a oprit)
        if (!isFetching && ballRb != null)
        {
            float currentSpeed = ballRb.velocity.magnitude;
            if (currentSpeed <= ballStopSpeedThreshold)
            {
                StartFetch(); // Pornim fetch
            }
            return;
        }

        // Daca suntem in fetch si nu avem mingea in gura, verificam distanta fata de minge
        if (isFetching && !hasBall)
        {
            float distToBall = Vector3.Distance(transform.position, ball.position);
            if (distToBall <= fetchDistance)
            {
                PickupBallInMouth(); // Cainele ia mingea in gura
            }
            return;
        }

        // Daca tinem mingea si am ajuns la returnTarget, lasam mingea jos
        if (hasBall && !agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            DropBallAtReturnPoint();
        }
    }

    void StartFetch()
    {
        isFetching = true;
        hasBall = false;

        if (agent == null)
            return;

        // Cainele merge catre minge
        agent.SetDestination(ball.position);

        // Animatie de alergare (AnimationID = 4)
        if (animator != null)
        {
            animator.SetInteger("AnimationID", 4);
            animator.speed = 1.6f;
        }

        // Pornim sunetul de alergare
        if (runAudioSource != null && !runAudioSource.isPlaying)
        {
            runAudioSource.Play();
        }
    }

    void PickupBallInMouth()
    {
        float distanceToBall = Vector3.Distance(transform.position, ball.position);
        if (distanceToBall > fetchDistance)
            return;

        // Mingea devine "child" la capul cainelui
        ball.SetParent(this.transform);
        ball.localPosition = new Vector3(0.1f, 0.3f, 0.2f);

        // Oprim fizica mingii cat timp e in gura cainelui
        if (ballRb != null)
            ballRb.isKinematic = true;

        hasBall = true;

        // Cainele merge la returnTarget (de regula langa masa)
        agent.SetDestination(returnTarget.position);

        // Animatie "carrying" (tot ID 4 sau alt ID daca ai)
        if (animator != null)
        {
            animator.SetInteger("AnimationID", 4);
            animator.speed = 1.2f;
        }
    }

    void DropBallAtReturnPoint()
    {
        // Mingea nu mai e copil la caine
        ball.SetParent(null);

        // Activam fizica, pozitionam mingea langa returnTarget
        if (ballRb != null)
        {
            ballRb.isKinematic = false;
            ball.position = returnTarget.position + Vector3.up * 0.5f;
        }

        // Resetam flag-urile din PickUpBall pentru un nou fetch
        pickupScript.ResetThrownFlag();
        pickupScript.isHeld = false;
        pickupScript.isSimulatedHold = false;

        isFetching = false;
        hasBall = false;

        // Oprim sunetul de alergare
        if (runAudioSource != null && runAudioSource.isPlaying)
        {
            runAudioSource.Stop();
        }

        // Animatie "WigglingTail" (ID = 1)
        if (animator != null)
        {
            animator.SetInteger("AnimationID", 1);
            animator.speed = 1f;
        }

        // Dupa 5 secunde revine la Idle automat
        Invoke(nameof(ReturnToIdle), 5f);
    }

    void ReturnToIdle()
    {
        if (animator != null)
        {
            animator.SetInteger("AnimationID", 0); // Idle
        }

        if (agent != null)
            agent.SetDestination(transform.position); // Opreste agentul

        // Siguranta: ne asiguram ca nu mai ruleaza sunetul de alergare
        if (runAudioSource != null && runAudioSource.isPlaying)
        {
            runAudioSource.Stop();
        }
    }
}
