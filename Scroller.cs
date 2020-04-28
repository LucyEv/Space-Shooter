using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour
{
    public float speed; // параметр скорости можно менять снаружи, настраивая скорость движения космического фона
    private Vector3 startPosition; 

    private void Start()
    {
        startPosition = transform.position;
    }
     // Update is called once per frame - на каждый кадр
    void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * speed, transform.localScale.y); // функция Mathf.Repeat позволяет менять значение переменной (1-новая позиция, 2-граница) 0,1,2,.. 99,100 - 0,1 99
        transform.position = startPosition + Vector3.back * newPosition;
    }
}
