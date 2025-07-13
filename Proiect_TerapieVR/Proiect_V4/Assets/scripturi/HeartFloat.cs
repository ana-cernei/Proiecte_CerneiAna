using UnityEngine;

/// Script atasat la prefab-ul inima
/// Face inimioara sa urce pe verticala si sa estompeze transparenta pana la 0,
/// apoi se autodistruge cu Destroy(gameObject).

public class HeartFloat : MonoBehaviour
{
    [Header("Flight Settings")]
    [Tooltip("Viteza cu care inima urca (metri pe secunda)")]
    public float riseSpeed = 0.5f;

    [Tooltip("Cat timp (in secunde) dureaza efectul complet (urcare + fade-out)")]
    public float duration = 1.5f;

    [Tooltip("Inaltimea maxima relativa fata de pozitia initiala")]
    public float maxVerticalOffset = 2.0f;

    private float elapsed = 0f;                    // Timpul scurs de la aparitia inimii
    private Vector3 startPos;                      // Pozitia initiala de spawn
    private SpriteRenderer spriteRenderer;         // Referinta la componenta SpriteRenderer
    private Color originalColor;                   // Culoarea initiala (cu alpha = 1)

    void Start()
    {
        // Salvam pozitia de pornire
        startPos = transform.position;

        // Preluam componenta SpriteRenderer (daca exista)
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            originalColor = spriteRenderer.color;
        }
    }

    void Update()
    {
        // Crestere timp de viata
        elapsed += Time.deltaTime;

        // Calculam progresul de la 0 la 1 (in functie de durata)
        float t = Mathf.Clamp01(elapsed / duration);

        // 1. Calculam noua pozitie verticala (urcare)
        float newY = Mathf.Lerp(startPos.y, startPos.y + maxVerticalOffset, t);
        Vector3 newPos = new Vector3(startPos.x, newY, startPos.z);
        transform.position = newPos;

        // 2. Fade-out: alpha scade de la 1 la 0
        if (spriteRenderer != null)
        {
            float newAlpha = Mathf.Lerp(1f, 0f, t);
            Color c = originalColor;
            c.a = newAlpha;
            spriteRenderer.color = c;
        }

        // 3. Daca timpul a expirat, distrugem inimioara
        if (t >= 1f)
        {
            Destroy(gameObject);
        }
    }
}
