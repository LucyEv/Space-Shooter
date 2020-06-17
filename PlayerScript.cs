using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed; // скорость корабля
                        //ship speed
    public float tilt; // переменная, которая определяет угол наклона корабля
                       // variable that determines the tilt angle of the ship
    public float xMin, xMax, zMin, zMax; //граница движения корабля
                                         //ship boundary
    public GameObject lazerShot;

    public Transform gunPosition;

    public float shotDelay; // задержка между выстрелами
                            // delay between shots

    private float nextShotTime; //время следующего выстрела
                                //next shot time

// Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        // Если пришло время следующего выстрела (т.е. текущее время (Time.time) больше, чем время следующего выстрела), то можно создавать выстрел
        // If it's time for the next shot (i.e. the current time (Time.time) is more than the time for the next shot), then create a shot
        if (Time.time > nextShotTime && Input.GetButton("Fire1")) // Встрел по кнопке мыши. Fire1 по умолчанию в Unity - левая кнопка мыши
                                                                  // Shot on the mouse button. Fire1 by default in Unity - left mouse button
        {
            Instantiate(lazerShot, gunPosition.position, Quaternion.identity);
            nextShotTime = Time.time + shotDelay; // время следующего каждый раз выстрела нужно переставить: текущее время + задержка
                                                  //the time of the next shot each time needs to be rearranged: current time + delay
        }

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Rigidbody Ship = GetComponent<Rigidbody>();

        Ship.velocity = new Vector3(moveHorizontal, 0, moveVertical) * speed; // скорость в трехмерном пространстве
                                                                              // speed in three-dimensional space

        Ship.rotation = Quaternion.Euler(tilt * Ship.velocity.z, 0, - tilt * Ship.velocity.x); // вращение корабля
                                                                                               // ship rotation

        float xPosition = Mathf.Clamp(Ship.position.x, xMin, xMax);
        float zPosition = Mathf.Clamp(Ship.position.z, zMin, zMax);
        
        Ship.position = new Vector3(xPosition, Ship.position.y, zPosition);
    }
}
