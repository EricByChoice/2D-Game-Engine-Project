using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private float maxHealth = 5f;
    //[SerializeField] private bool isInvulnerable = false;
    [SerializeField] private float invulnerabilityDuration = 1f;
    [SerializeField] private float blinkSpeed = 0.1f;
    [SerializeField] GameObject[] healthAssets;

    public float currentHealth;
private float invulnerabilityTimer = 0f;
private float blinkTimer = 0f;
private SpriteRenderer spriteRenderer;
private bool isBlinking = false;
bool blinking;

    public UnityEvent<float> onHealthChanged;
public UnityEvent onDeath;

private void Start()
{
    currentHealth = maxHealth;
    spriteRenderer = GetComponent<SpriteRenderer>();
    onHealthChanged?.Invoke(currentHealth);
}

private void Update()
{
    if (invulnerabilityTimer > 0)
    {
        invulnerabilityTimer -= Time.deltaTime;
    }

    if (isBlinking)
    {
        blinkTimer -= Time.deltaTime;
        if (blinkTimer <= 0)
        {
            isBlinking = false;
            if (spriteRenderer != null)
                spriteRenderer.enabled = true;
        }
        else if (spriteRenderer != null)
        {
            spriteRenderer.enabled = Mathf.Sin(blinkTimer * Mathf.PI / blinkSpeed) > 0;
        }
    }
}

    public bool ApplyDamage(float amount)
    {
        if (currentHealth <= 0f || invulnerabilityTimer > 0f)
            return false;

        RemoveHealthAsset();

        currentHealth -= amount;

        if (currentHealth <= 0f)
        {
            Die();
            return true;
        }

        invulnerabilityTimer = invulnerabilityDuration;
        StartBlink(invulnerabilityDuration);
        return true;
    }
    void StartBlink(float duration)
    {
        blinking = true;
        blinkTimer = duration;
    }
    private void Die()
{
    onDeath?.Invoke();
    gameObject.SetActive(false);
}
    void RemoveHealthAsset()
    {
        int index = Mathf.Clamp((int)currentHealth, 0, healthAssets.Length - 1);

        if (index < healthAssets.Length)
        {
            healthAssets[index].SetActive(false);
        }
    }
}