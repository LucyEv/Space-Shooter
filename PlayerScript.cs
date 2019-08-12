﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed; // скорость коробля
    public float tilt; // переменная, которая определяет угол наклона коробля
    public float xMin, xMax, zMin, zMax; //граница движения корабля

    public GameObject lazerShot;

    public Transform gunPosition;

    public float shotDelay; // задержка между выстрелами

    private float nextShotTime; //время следующего выстрела

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Если подошло время следующего выстрела (текущее время Time.time больше, чем время следующего выстрела), то можно создавать выстрел
        if (Time.time > nextShotTime && Input.GetButton("Fire1")) // встрел по кнопке мыши. Fire1 по умолчанию в Unity - левая кнопка мыши
        {
            Instantiate(lazerShot, gunPosition.position, Quaternion.identity);
            nextShotTime = Time.time + shotDelay; // каждый раз время следующего выстрела нужно переставить: текущее время + задержка
        }

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Rigidbody Ship = GetComponent<Rigidbody>();

        Ship.velocity = new Vector3(moveHorizontal, 0, moveVertical) * speed; // скорость в трехмерном пространстве

        Ship.rotation = Quaternion.Euler(tilt * Ship.velocity.z, 0, - tilt * Ship.velocity.x); // вращение корабля

        float xPosition = Mathf.Clamp(Ship.position.x, xMin, xMax);
        float zPosition = Mathf.Clamp(Ship.position.z, zMin, zMax);

        Ship.position = new Vector3(xPosition, Ship.position.y, zPosition);
    }
}