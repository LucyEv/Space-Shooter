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
    // Start is called before the first frame update
    void Start()
    {
        Asteroid = GetComponent<Rigidbody>();
        Asteroid.angularVelocity = Random.insideUnitSphere * rotationSpeed; // angularVelocity - угловая скорость как вариант = new Vector3(50, 0, 0);
        Asteroid.velocity = Vector3.back * Random.Range(minSpeed, maxSpeed);
    }
    // срабатывает при столкновении с другим коллайдером
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "GameBoundary" || other.tag == "Asteroid")
        {
            return;
        }

        Instantiate(asteroidExplosion, transform.position, Quaternion.identity); // первый аргумент- что создать (взрыв), второй аргумент (где создать), третье - вращение (нулевое)

        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, Quaternion.identity);
        }

        Destroy(other.gameObject); // уничтожаем то, с чем столкнулся астероид
        Destroy(gameObject); // уничтожаем сам астероид
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
