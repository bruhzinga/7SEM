using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int damage = 10;

    private void OnTriggerEnter(Collider other)
    {
        // Проверяем, столкнулись ли с игроком
        if (other.CompareTag("Player"))
        {
            // Получаем компонент здоровья игрока и наносим урон
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            Debug.Log("PLAYER HIT");
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
        }
    }
}
