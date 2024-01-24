using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float fieldOfViewAngle = 90f; // Угол обзора в градусах
    public float detectionRadius = 10f; // Расстояние обнаружения игрока
    public float moveSpeed = 3f; // Скорость движения объекта

    private Transform player; // Ссылка на трансформ игрока
    private bool playerInSight; // Флаг, указывающий, что игрок в поле зрения

    private void Start()
    {
        // Находим игрока по тегу "Player"
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Проверка, что игрок найден
        if (player == null)
        {
            Debug.LogError("Player not found. Make sure the player has the 'Player' tag.");
        }
    }

    private void Update()
    {
        // Проверка условий обзора и расстояния до игрока
        CheckPlayerInSight();

        // Если игрок в поле зрения и находится в заданном расстоянии, поворачиваем и двигаем объекты
        if (playerInSight && Vector3.Distance(transform.position, player.position) <= detectionRadius)
        {
            // Поворачиваем объекты в сторону игрока
            Vector3 directionToPlayer = player.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(directionToPlayer);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);

            // Двигаем объекты в сторону игрока
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
    }

    private void CheckPlayerInSight()
    {
        // Определяем направление до игрока
        Vector3 directionToPlayer = player.position - transform.position;
        float angleToPlayer = Vector3.Angle(transform.forward, directionToPlayer);

        // Проверяем, находится ли игрок в поле зрения
        if (angleToPlayer < fieldOfViewAngle * 0.5f)
        {
            RaycastHit hit;

            // Проверяем, есть ли препятствия между объектом и игроком
            if (Physics.Raycast(transform.position, directionToPlayer.normalized, out hit, detectionRadius))
            {
                if (hit.collider.CompareTag("Player"))
                {
                    // Игрок обнаружен в поле зрения
                    playerInSight = true;
                }
                else
                {
                    // Игрок не в поле зрения
                    playerInSight = false;
                }
            }
        }
        else
        {
            // Игрок не в поле зрения
            playerInSight = false;
        }
    }
}
