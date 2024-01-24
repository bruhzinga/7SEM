using UnityEngine;

public class PLayerLaser : MonoBehaviour
{
    public float raycastRange = 10f; // Дальность луча

    private void Update()
    {
        // Проверяем ввод игрока (например, нажатие кнопки мыши)
        if (Input.GetMouseButtonDown(0))
        {
            // Создаем луч из центра камеры
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Проверяем, столкнулся ли луч с каким-то объектом
            if (Physics.Raycast(ray, out hit, raycastRange))
            {
                // Проверяем, является ли объект, на котором стоит фокус, преследующим объектом
                EnemyController enemy = hit.collider.GetComponent<EnemyController>();
                if (enemy != null)
                {
                    // Уничтожаем или деактивируем преследующий объект
                    Destroy(enemy.gameObject);
                    // Дополнительно можно использовать enemy.gameObject.SetActive(false); для деактивации объекта
                }
            }
        }
    }
}
