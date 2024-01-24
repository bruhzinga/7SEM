using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;  // Ссылка на трансформацию целевого объекта (вашей сферы)
    public Vector3 offset = new Vector3(0f, 2f, -5f);  // Смещение камеры относительно цели

    void Update()
    {
        if (target != null)
        {
            // Позиционируем камеру относительно цели с учетом смещения
            transform.position = target.position + offset;

            // Обращаем камеру к цели
            transform.LookAt(target);
        }
    }
}
