// using __ imports namespace
// Namespaces are collection of classes, data types
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// MonoBehavior is the base class from which every Unity Script Derives
public class PlayerMovement : MonoBehaviour
{
    public float speed = 25.0f;
    public float rotationSpeed = 90;
    public float force = 700f;
    public GameObject cannon;
    public GameObject bullet;
    public GameObject bulletWinter;
    public GameObject bulletSummer;
    public GameObject bulletFall;
    public GameObject bulletSpring;

    public float bulletForce = 1500;
    Rigidbody rb;
    Transform t;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        t = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        // Time.deltaTime represents the time that passed since the last frame
        //the multiplication below ensures that GameObject moves constant speed every frame
        if (Input.GetKey(KeyCode.W))
            rb.velocity += this.transform.forward * speed * Time.deltaTime;
        else if (Input.GetKey(KeyCode.S))
            rb.velocity -= this.transform.forward * speed * Time.deltaTime;

        // Quaternion returns a rotation that rotates x degrees around the x axis and so on
        if (Input.GetKey(KeyCode.D))
            t.rotation *= Quaternion.Euler(0, rotationSpeed * Time.deltaTime, 0);
        else if (Input.GetKey(KeyCode.A))
            t.rotation *= Quaternion.Euler(0, -rotationSpeed * Time.deltaTime, 0);

        if (Input.GetKeyDown(KeyCode.Space))
            rb.AddForce(t.up * force);
        // https://docs.unity3d.com/ScriptReference/Input.html
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject newBullet = GameObject.Instantiate(bullet, cannon.transform.position, cannon.transform.rotation) as GameObject;
            newBullet.GetComponent<Rigidbody>().velocity += Vector3.up * 2;
            newBullet.GetComponent<Rigidbody>().AddForce(newBullet.transform.forward * bulletForce);
        }

        //change bullet from coordinate
        if (gameObject.transform.position.x > 0)
        {
            if (gameObject.transform.position.z > 0)
            {
                bullet = bulletSummer;
            } else
            {
                bullet = bulletFall;
            }
        } else
        {
            if (gameObject.transform.position.z > 0)
            {
                bullet = bulletSpring;
            }
            else
            {
                bullet = bulletWinter;
            }
        }



        //exit function
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        //reload
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene("assignment 01 quentin bu");
        }
    }

}