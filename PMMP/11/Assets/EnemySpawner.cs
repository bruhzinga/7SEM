using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Префаб врага
    public int numberOfEnemies = 5; // Количество врагов для спавна
    public float spawnRadius = 10f; // Радиус для случайных координат спавна

    private void Start()
    {
        SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            // Генерируем случайные координаты в радиусе спавна
            Vector3 spawnPosition = GetRandomSpawnPosition();

            // Генерируем случайное вращение
            Quaternion spawnRotation = Quaternion.Euler(0f, Random.Range(0f, 360f), 0f);

            // Создаем врага на случайных координатах с рандомным вращением
            GameObject enemy = Instantiate(enemyPrefab, spawnPosition, spawnRotation);

            // Дополнительные действия при спавне врага, если необходимо
            // Например, можно добавить компоненты, настроить параметры врага и т.д.
        }
    }

    private Vector3 GetRandomSpawnPosition()
    {
        // Генерируем случайные координаты в пределах радиуса спавна
        float randomX = Random.Range(-spawnRadius, spawnRadius);
        float randomZ = Random.Range(-spawnRadius, spawnRadius);

        // Возвращаем случайные координаты с учетом положения объекта спавна
        return new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
    }
}
