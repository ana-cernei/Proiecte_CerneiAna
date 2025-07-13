using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class DogBehavior : MonoBehaviour
{
    [Header("Components")]
    public Animator animator;          // Animator al cainelui
    public AudioSource pantingSource;  // Sunet panting
    public AudioSource happySource;    // Sunet happy dog

    private NavMeshAgent agent;

    [Header("Heart Burst Settings")]
    [Tooltip("Prefab-ul inimioara care apare cand cainele e periat")]
    public GameObject heartEffectPrefab;

    [Tooltip("Offset fata de pozitia cainelui unde apar inimi (Y inaltime, Z inainte/spate)")]
    public Vector3 heartOffset = new Vector3(0f, 1.2f, 0f);

    [Tooltip("Cate inimi apar intr-un burst")]
    public int heartCount = 3;

    [Tooltip("Intarzierea (in secunde) intre aparitia fiecarei inimi")]
    public float heartDelay = 0.25f;

    [Tooltip("Raza (orizontala) in care fiecare inima poate fi pozitionata aleator")]
    public float heartRadius = 0.2f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        // La inceput, porneste sunetul de panting
        if (pantingSource != null)
        {
            pantingSource.loop = true;
            pantingSource.Play();
        }
    }

    // Metoda apelata cand cainele este periat.
    // Opresc agentul, pornesc animatia si sunetul "happy", apoi spawn un burst de inimi.
    public void OnBrushed()
    {
        Debug.Log("DogBehavior: Cainele a fost periat - lansez burst de inimi.");

        // 1. Opreste NavMeshAgent
        if (agent != null)
        {
            agent.isStopped = true;
        }

        // 2. Ruleaza animatia de wiggling tail
        if (animator != null)
        {
            animator.SetInteger("AnimationID", 1); // 1 = WigglingTail
        }

        // 3. Opreste sunetul de panting
        if (pantingSource != null && pantingSource.isPlaying)
        {
            pantingSource.Stop();
        }

        // 4. Porneste sunetul de happy dog
        if (happySource != null)
        {
            happySource.loop = false;
            happySource.Play();
        }

        // 5. Incepe corutina care va spawn-ui un burst de inimi
        if (heartEffectPrefab != null)
        {
            StartCoroutine(SpawnHeartBurst());
        }

        // 6. Dupa 5 secunde, reia starea idle si agentul
        Invoke(nameof(ResumeIdle), 5f);
    }

    // Coroutine care spawn-eaza 'heartCount' inimi, fiecare cu o mica intarziere,
    // la pozitii putin aleatorii in jurul pozitiei cainelui + heartOffset.
    private IEnumerator SpawnHeartBurst()
    {
        for (int i = 0; i < heartCount; i++)
        {
            // Calculam un offset aleator pe orizontala (X,Z) in jurul capului
            float angle = Random.Range(0f, 360f) * Mathf.Deg2Rad;
            Vector3 randomOffset = new Vector3(Mathf.Cos(angle), 0f, Mathf.Sin(angle)) * heartRadius;

            // Pozitia finala de spawn pentru aceasta inima
            Vector3 spawnPos = transform.position + heartOffset + randomOffset;

            // Instantiem prefab-ul
            Instantiate(heartEffectPrefab, spawnPos, Quaternion.identity);

            // Asteptam heartDelay secunde inainte de urmatoarea inimioara
            yield return new WaitForSeconds(heartDelay);
        }
    }

    // Reia animatia idle si agentul dupa un brush.
    private void ResumeIdle()
    {
        // Reia animatia Idle (breathing)
        if (animator != null)
        {
            animator.SetInteger("AnimationID", 0); // 0 = Idle/Breathing
        }

        // Repornim NavMeshAgent-ul
        if (agent != null)
        {
            agent.isStopped = false;
        }

        // Opreste sunetul de happy (daca inca ruleaza)
        if (happySource != null && happySource.isPlaying)
        {
            happySource.Stop();
        }

        // Reia sunetul de panting in bucla
        if (pantingSource != null)
        {
            pantingSource.loop = true;
            pantingSource.Play();
        }
    }
}
