using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour
{
    public float speed; // параметр скорости можно изменять снаружи, настраивая скорость движения космического фона 
                        // the speed parameter can be changed outside by adjusting the speed of the cosmic background
    private Vector3 startPosition; 

    private void Start()
    {
        startPosition = transform.position;
    }
     // Update is called once per frame 
    // обновление на каждый кадр
    void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * speed, transform.localScale.y); // функция Mathf.Repeat позволяет менять значение переменной (1-новая позиция, 2-граница) 0,1,2,..99,100 - 0,1..99 /
                                                                                    // Mathf.Repeat allows to change the value of a variable (1-new position, 2-border)
        transform.position = startPosition + Vector3.back * newPosition;
    }
}
