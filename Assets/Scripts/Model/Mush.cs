using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mush : MonoBehaviour
{
    public float radius = 5f; // радиус движения
    public float speed = 1f; // скорость движения

    private float _angle; // текущий угол

    private void Update()
    {
        _angle += speed * Time.deltaTime; // увеличиваем угол от времени и скорости

        // вычисляем новые координаты объекта на окружности с помощью тригонометрических функций
        float x = Mathf.Cos(_angle) * radius;
        float y = Mathf.Sin(_angle) * radius;

        transform.localPosition = new Vector3(x, y, transform.localPosition.z); // обновляем позицию объекта
    }
}
