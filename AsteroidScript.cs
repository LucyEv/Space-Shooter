using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    public float rotationSpeed;
    public float minSpeed, maxSpeed;
    public GameObject asteroidExplosion;
    public GameObject playerExplosion;

    private Rigidbody Asteroid;
    // Запуск вызывается перед обновлением первого кадра
    // Start is called before the first frame update
    void Start()
    {
        Asteroid = GetComponent<Rigidbody>();
        Asteroid.angularVelocity = Random.insideUnitSphere * rotationSpeed; // angularVelocity - угловая скорость, например = new Vector3(50, 0, 0);
                                                                            // angularVelocity, for example = new Vector3 (50, 0, 0);
        Asteroid.velocity = Vector3.back * Random.Range(minSpeed, maxSpeed);
    }
    // срабатывает при столкновении с другим коллайдером;
    // triggered by collision with another collider;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "GameBoundary" || other.tag == "Asteroid")
        {
            return;
        }

        Instantiate(asteroidExplosion, transform.position, Quaternion.identity); // первый аргумент - "что" - создать (взрыв), второй аргумент - "где" создать, третье - вращение (нулевое);
                                                                                 // the first argument is what - to create (explosion), the second argument is where to create, the third is rotation (zero)
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, Quaternion.identity);
        }

        Destroy(other.gameObject); // уничтожаем объект, с которым столкнулся астероид
                                   // to destroy the object that asteroid collided with
        Destroy(gameObject); // уничтожаем сам астероид 
                             // destroy the asteroid itself
    }

    // Update is called once per frame
    // Обновление вызывается один раз за кадр
    
    void Update()
    {
        
    }
}
