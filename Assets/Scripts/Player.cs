using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int speed = 4;
    CharacterController controller;
    Vector3 targetDirection;
    Quaternion targetRotation;
    
    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        targetDirection = new Vector3(horizontal, 0f, vertical);
        targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
        targetDirection = Camera.main.transform.TransformDirection(targetDirection);
        targetDirection.y = 0.0f;

        if (targetDirection.magnitude > 0)
        {
            controller.Move(targetDirection * Time.deltaTime * speed);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(targetDirection), Time.deltaTime * speed);
        }
    }
}
