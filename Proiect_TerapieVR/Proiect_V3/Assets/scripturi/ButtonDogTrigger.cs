using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using System.Collections;

public class ButtonDogTrigger : MonoBehaviour
{
    public DogBehavior dogBehavior;
    public Transform playerTransform;

    [Header("Mini-game Settings")]
    public int requiredClicks = 3;
    public Text messageText;                    // Text UI pentru scor și mesaj
    public GameObject confettiEffect;           // Prefab de confetti
    public Transform confettiSpawnPoint;        // Unde apare confetti-ul în scenă
    public Image[] stars;                       // Stele UI (ex: 3 imagini pentru Star1, Star2, Star3)

    private XRBaseInteractable interactable;
    private int clickCount = 0;

    private void Awake()
    {
        interactable = GetComponent<XRBaseInteractable>();
    }

    private void Start()
    {
        ShowStars(0); //ascunde toate stelele la început
        UpdateScoreLabel();
    }

    private void OnEnable()
    {
        if (interactable != null)
            interactable.selectEntered.AddListener(OnButtonPressed);
    }

    private void OnDisable()
    {
        if (interactable != null)
            interactable.selectEntered.RemoveListener(OnButtonPressed);
    }

    private void OnButtonPressed(SelectEnterEventArgs args)
    {
        Debug.Log("Butonul a fost apasat");

        if (dogBehavior != null && playerTransform != null)
        {
            dogBehavior.ReactToPlayer(playerTransform);
        }
        else
        {
            Debug.LogWarning("DogBehavior sau playerTransform nu sunt asignate");
        }

        clickCount++;
        UpdateScoreLabel();
        ShowStars(clickCount); //adaugăm progresiv stele

        if (clickCount >= requiredClicks)
        {
            TriggerMiniGameSuccess();
        }
    }

    private void UpdateScoreLabel()
    {
        if (messageText != null)
        {
            messageText.text = "Scor: " + clickCount;
        }
    }

    private void TriggerMiniGameSuccess()
    {
        Debug.Log("Mini-game success! Afisare mesaj,stele,confetti");

        if (messageText != null)
        {
            messageText.text = "Bravo!";
        }

        if (confettiEffect != null && confettiSpawnPoint != null)
        {
            GameObject confetti = Instantiate(confettiEffect, confettiSpawnPoint.position, Quaternion.identity);
            Destroy(confetti, 5f);
        }

        //Pornește resetarea automată 
        StartCoroutine(ResetAfterDelay(15f));
    }

    private IEnumerator ResetAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        clickCount = 0;
        ShowStars(0);
        UpdateScoreLabel();

        if (messageText != null)
        {
            messageText.text = "Scor: 0";
        }

        Debug.Log("Jocul a fost resetat automat");
    }

    private void ShowStars(int score)
    {
        for (int i = 0; i < stars.Length; i++)
        {
            stars[i].enabled = i < score;
        }
    }

    // Pentru testare rapidă în editor
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            Debug.Log("Apasare de buton-M");
            OnButtonPressed(null);
        }
    }
}
