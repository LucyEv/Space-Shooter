using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidEmitterScript : MonoBehaviour
{
    public GameObject asteroid;
    public float minDelay, maxDelay; // задержка между временем вылета астероидов 
                                     // delay between the time of exits of Asteroids

    private float nextSpawn; // время создания следующего астероида 
                             // time for creation the next Asteroid

    // Start запускается перед обновлением первого кадра
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Обновление производится один раз за кадр
    // Update is called once per frame
    void Update()
    {
      if (Time.time > nextSpawn) // если время для создания нового астероида 
                                 // if it's time to create a new Asteroid
        {
            float yPosition = transform.position.y;
            float zPosition = transform.position.z;
            float xPosition = Random.Range(-transform.localScale.x/2, transform.localScale.x/2); // влево -половина, вправо +половина 
                                                                                                 // left - minus half, right - plus half

            Vector3 newPosition = new Vector3(xPosition, yPosition, zPosition);

            Instantiate(asteroid, newPosition, Quaternion.identity); // Функция Instantiate создает астероид в новой позиции с пустым вращением
                                                                     // Function Instantiate creates an asteroid in a new position with empty rotation

            nextSpawn = Time.time + Random.Range(minDelay, maxDelay);
        }
    }
}
