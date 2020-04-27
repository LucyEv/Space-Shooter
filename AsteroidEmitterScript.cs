using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidEmitterScript : MonoBehaviour
{
    public GameObject asteroid;
    public float minDelay, maxDelay; // задержка между вылетами астероидов

    private float nextSpawn; // время следующего создания астероида

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      if (Time.time > nextSpawn) // если пришло время для создания нового астероида
        {
            float yPosition = transform.position.y;
            float zPosition = transform.position.z;
            float xPosition = Random.Range(-transform.localScale.x/2, transform.localScale.x/2); // влево -половина, вправо +половина

            Vector3 newPosition = new Vector3(xPosition, yPosition, zPosition);

            Instantiate(asteroid, newPosition, Quaternion.identity); // функция Instantiate создает астероид в новой позиции, с пустым вращением

            nextSpawn = Time.time + Random.Range(minDelay, maxDelay);
        }
    }
}
