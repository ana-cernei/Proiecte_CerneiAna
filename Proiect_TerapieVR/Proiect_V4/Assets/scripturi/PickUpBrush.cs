using UnityEngine;
using System.Collections;
using UnityEngine.UI;    
// Script pentru mini-jocul de periat cainele in VR
// Permite preluarea periei, perierea cainelui, acordarea de stele si afisarea de confetti si mesaj la 3 perieri

public class PickUpBrush : MonoBehaviour
{
    // Referinte la obiecte din scena (setate in Inspector)
    public Transform playerHand;            // Mana jucatorului la care atasam peria cand o luam
    public Transform tablePosition;         // Pozitia de pe masa unde punem peria cand o lasam

    // Setari pentru animatia de periere
    public float brushDuration = 5f;        // Cat dureaza animatia de periat
    public float brushAngleX = 15f;         // Unghi maxim inainte/inapoi
    public float brushAngleY = 8f;          // Unghi maxim stanga/dreapta
    public float brushFrequency = 2f;       // De cate ori pe secunda se misca peria (simulare periat)

    // Stele, confetti, mesaj - elemente de mini-game si feedback vizual
    public GameObject[] stars;              // 3 stele UI care se activeaza progresiv
    public GameObject confettiPrefab;       // Prefab particule confetti pentru recompensa
    public Transform confettiSpawnPoint;    // Locul unde apare confetti
    public GameObject messageUI;            // Mesaj "Bravo, subiect!", dezactivat la start

    // Scor afisat in UI
    public Text scoreText;                  // Text clasic pentru scor (sau TextMeshProUGUI daca folosesti TMP)

    private bool isPickedUp = false;        // Daca peria este luata in mana de jucator
    private Coroutine brushRoutine = null;  // Handler pentru animatia curenta de periat
    private Quaternion originalRotation;    // Salvam rotatia initiala pentru resetare

    // Contor pentru mini-game: cate perieri s-au facut
    private int brushHitsCount = 0;
    private const int requiredBrushes = 3;  // Prag pentru confetti/mesaj

    // Handler pentru rutina de resetare automata dupa succes
    private Coroutine resetRoutine = null;

    void Start()
    {
        // La inceput ascundem toate stelele (pentru mini-game)
        if (stars != null)
        {
            for (int i = 0; i < stars.Length; i++)
            {
                if (stars[i] != null)
                    stars[i].SetActive(false);
            }
        }

        // Mesajul nu e afisat la start
        if (messageUI != null)
            messageUI.SetActive(false);

        // Scorul afisat in UI e 0 la inceput
        UpdateScoreText();
    }

    void OnTriggerEnter(Collider other)
    {
        // Cand peria nu e luata si atingem mana jucatorului, atasam peria la mana
        if (!isPickedUp && other.CompareTag("PlayerHand"))
        {
            AttachToHand();
        }
        // Daca peria e in mana si atingem cainele, pornim animatia si logica de scor/steluțe
        else if (isPickedUp && other.CompareTag("Dog"))
        {
            // Pornim animatia de periat doar daca nu este deja activa
            if (brushRoutine == null)
            {
                originalRotation = transform.localRotation;
                brushRoutine = StartCoroutine(DoBrushMotion());
            }

            // Notificam cainele ca este periat (daca are metoda OnBrushed)
            other.gameObject.SendMessage("OnBrushed", SendMessageOptions.DontRequireReceiver);

            // Logica pentru steluțe, scor si confetti
            if (brushHitsCount < requiredBrushes)
            {
                brushHitsCount++;

                // Activam steaua corespunzatoare (indexul 0, 1 sau 2)
                int indexStea = brushHitsCount - 1;
                if (stars != null && indexStea >= 0 && indexStea < stars.Length && stars[indexStea] != null)
                {
                    stars[indexStea].SetActive(true);
                }

                // Actualizam scorul in UI
                UpdateScoreText();

                // Daca am ajuns la 3 perieri, pornim confetti + mesaj
                if (brushHitsCount == requiredBrushes)
                {
                    TriggerConfettiAndMessage();
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Cand nu mai atingem cainele, oprim animatia de periat si resetam rotatia
        if (isPickedUp && other.CompareTag("Dog") && brushRoutine != null)
        {
            StopCoroutine(brushRoutine);
            brushRoutine = null;
            transform.localRotation = originalRotation;
        }
    }

    void Update()
    {
        // Ia peria din mana: tasta E sau butonul A de pe controller
        if (!isPickedUp && (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.JoystickButton0)))
        {
            AttachToHand();
        }

        // Lasa peria jos: tasta R sau butonul B de pe controller
        if (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            DetachFromHand();
        }
    }

    // Metoda care ataseaza peria la mana jucatorului (devine copil la playerHand)
    private void AttachToHand()
    {
        transform.SetParent(playerHand);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        isPickedUp = true;
    }

    // Metoda care lasa peria jos pe masa, la pozitia specificata (tablePosition)
    private void DetachFromHand()
    {
        transform.SetParent(null);
        transform.position = tablePosition.position;
        transform.rotation = tablePosition.rotation;
        isPickedUp = false;

        // Daca animatia de periat era activa, oprim si resetam rotatia
        if (brushRoutine != null)
        {
            StopCoroutine(brushRoutine);
            brushRoutine = null;
            transform.localRotation = originalRotation;
        }
    }

    // Coroutine pentru animatia de periat (misca peria inainte-inapoi si stanga-dreapta cu un anumit ritm)
    private IEnumerator DoBrushMotion()
    {
        float elapsed = 0f;

        while (elapsed < brushDuration)
        {
            elapsed += Time.deltaTime;

            // Calculeaza unghiurile folosind functii trigonometrice pentru miscare naturala
            float xRot = Mathf.Sin(elapsed * Mathf.PI * brushFrequency) * brushAngleX;
            float yRot = Mathf.Cos(elapsed * Mathf.PI * brushFrequency * 0.5f) * brushAngleY;

            transform.localRotation = originalRotation * Quaternion.Euler(xRot, yRot, 0f);
            yield return null;
        }

        // Dupa animatie, revine la rotatia initiala
        transform.localRotation = originalRotation;
        brushRoutine = null;
    }

    // Cand se ating 3 perieri, afisam confetti si mesaj + pornim timer de reset
    private void TriggerConfettiAndMessage()
    {
        Debug.Log("Mini-game success: confetti + 'Bravo, subiect!'");

        // Instantiem confetti la pozitia specificata in scena
        if (confettiPrefab != null && confettiSpawnPoint != null)
        {
            GameObject conf = Instantiate(
                confettiPrefab,
                confettiSpawnPoint.position,
                confettiSpawnPoint.rotation
            );
            Destroy(conf, 9f); // Distrugem efectul dupa 9 secunde
        }

        // Afisam mesajul de succes in UI
        if (messageUI != null)
        {
            messageUI.SetActive(true);
        }

        // Resetam mini-jocul automat dupa 15 secunde
        if (resetRoutine != null)
            StopCoroutine(resetRoutine);

        resetRoutine = StartCoroutine(ResetAfterDelay(15f));
    }

    // Coroutine care reseteaza starea mini-game dupa cateva secunde
    private IEnumerator ResetAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Resetam contorul de perieri
        brushHitsCount = 0;

        // Ascundem toate stelele din nou
        if (stars != null)
        {
            for (int i = 0; i < stars.Length; i++)
            {
                if (stars[i] != null)
                    stars[i].SetActive(false);
            }
        }

        // Ascundem mesajul
        if (messageUI != null)
        {
            messageUI.SetActive(false);
        }

        // Resetam scorul afisat
        UpdateScoreText();

        Debug.Log("Mini-game a fost resetat.");
        resetRoutine = null;
    }

    // Metoda pentru actualizarea scorului in UI (ex: "Scor: 2")
    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = $"Scor: {brushHitsCount}";
        }
    }
}
