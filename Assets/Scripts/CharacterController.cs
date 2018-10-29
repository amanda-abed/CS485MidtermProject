using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterController: MonoBehaviour
{

    private Rigidbody rb;

    public float speed;

    public Text win;
    private int count;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        win.text = "";
    }

    void FixedUpdate()
    {  
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        transform.forward = movement + new Vector3(-90.0f,0.0f,0.0f);
        rb.AddForce(movement * speed);

        if(transform.position.y != 1)
        {
            transform.position = new Vector3(transform.position.x, 1, transform.position.z);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetWinText();
        }
    }

    void SetWinText(){
        if(count >= 5){
            win.text = "Level Complete!";
        }
    }  
}
