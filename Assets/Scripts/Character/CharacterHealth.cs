using UnityEngine;
using UnityEngine.UI;
public class CharacterHealth: MonoBehaviour,IDamagable
{
    public Image healthBarImage;
    public float maxHealth = 100f;
    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthBar();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void UpdateHealthBar()
    {
        float healthPercentage = currentHealth / maxHealth;
        healthBarImage.fillAmount = healthPercentage;
    }

    private void Die()
    {
        EventBus.onPlayerDied?.Invoke();
    }
}
