using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class Player : MonoBehaviour
{
    public static Player Instance;
    public float speed;
    public float startSpeed;
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        startSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        //Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 move = new Vector3(ArduinoControl.Instance.moveY, 0, ArduinoControl.Instance.moveX);
        move += Physics.gravity * Time.deltaTime;

        GetComponent<CharacterController>().Move(move * speed * Time.deltaTime);
    }
}
