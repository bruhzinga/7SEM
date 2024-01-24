using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // Проверяем, осталось ли здоровье
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Реализовать действия при смерти игрока
        // Например, перезагрузка уровня или отображение экрана Game Over
        Debug.Log("Player died");
        // Пример перезагрузки уровня: SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
