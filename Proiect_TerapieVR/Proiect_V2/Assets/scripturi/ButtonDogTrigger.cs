using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

/// Script responsabil sa transmita catre DogBehavior atunci cand utilizatorul apasa butonul
/// Permite cainelui sa reactioneze la jucator

public class ButtonDogTrigger : MonoBehaviour
{
    // Referinta la scriptul DogBehavior de pe caine, pentru a-i putea comanda reactia
    public DogBehavior dogBehavior;

    // Transform-ul jucatorului (sau mainii), folosit ca tinta pentru caine
    public Transform playerTransform;

    // Referinta la interactable-ul XR  (XRSimpleInteractable) care detecteaza interactiunea VR
    private XRBaseInteractable interactable;

    // Metoda apelata la pornirea componentei, obtine referinta la componenta XRBaseInteractable
    private void Awake()
    {
        interactable = GetComponent<XRBaseInteractable>();
    }

    // Cand obiectul devine activ, ne abonam la evenimentul de selectare (apasa butonul)
    private void OnEnable()
    {
        if (interactable != null)
            interactable.selectEntered.AddListener(OnButtonPressed);
    }

    // Cand obiectul este dezactivat, ne dezabonam de la eveniment, pentru siguranta (evita memory leaks)
    private void OnDisable()
    {
        if (interactable != null)
            interactable.selectEntered.RemoveListener(OnButtonPressed);
    }

    // Metoda apelata automat cand utilizatorul apasa butonul VR
    private void OnButtonPressed(SelectEnterEventArgs args)
    {
        Debug.Log("Butonul a fost apasat!");
        // Verificam daca avem referinte setate la dogBehavior si playerTransform
        if (dogBehavior != null && playerTransform != null)
        {
            // Pornim reactia cainelui spre jucator (ex: cainele intoarce capul, da din coada etc.)
            dogBehavior.ReactToPlayer(playerTransform);
        }
        else
        {
            Debug.LogWarning("dogBehavior sau playerTransform nu sunt asignate!");
        }
    }

    // Permite testarea comportamentului direct din Editor, fara VR
    // folosind tasta M pentru a simula apasarea butonului (usor pentru debugging)
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            Debug.Log("simulare apasare de buton-tasta M");
            if (dogBehavior != null && playerTransform != null)
            {
                dogBehavior.ReactToPlayer(playerTransform);
            }
            else
            {
                Debug.LogWarning("dogBehavior sau playerTransform nu sunt asignate!");
            }
        }
    }
}
