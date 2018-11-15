using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterController: MonoBehaviour
{

    private Rigidbody rb;

    public float speed;

    public Text win;
    public Text countdownText;
    
    private int countdown;

    public GameObject shark;

    void Start()
    {
        shark = GameObject.FindGameObjectWithTag("shark");
        rb = GetComponent<Rigidbody>();
        countdown = 5;
        SetCount();
        win.text = "";
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            SceneManager.LoadScene("MainMenu");
        }
        if(countdown == 0){
            Destroy(shark);
        }
    }

    void FixedUpdate()
    {  
     	float moveHorizontal = Input.GetAxis("Horizontal");
     	float moveVertical = Input.GetAxis("Vertical");

     	Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

     	transform.forward = movement + new Vector3(-90.0f,0.0f,0.0f);
     	rb.AddForce(movement * speed);

		if(Input.GetKey(KeyCode.UpArrow)){
			transform.LookAt(movement + transform.position);
			transform.eulerAngles = new Vector3(0, 270, 0); 
	    	transform.Translate(movement * speed * Time.deltaTime, Space.World);
		}
        
        if(Input.GetKey(KeyCode.DownArrow)){
        	transform.LookAt(movement + transform.position);
        	transform.eulerAngles = new Vector3(0, -270, 0); 
        	transform.Translate(movement * speed * Time.deltaTime, Space.World);
        }
        
        if(Input.GetKey(KeyCode.LeftArrow)){
        	transform.LookAt(movement + transform.position);
        	transform.eulerAngles = new Vector3(0, 180, 0); 
        	transform.Translate(movement * speed * Time.deltaTime, Space.World);
        }
        
        if(Input.GetKey(KeyCode.RightArrow)){
        	transform.LookAt(movement + transform.position);
        	transform.eulerAngles = new Vector3(0, 0, 0); 
        	transform.Translate(movement * speed * Time.deltaTime, Space.World);
        }

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
            countdown -= 1;
            SetCount();
        }
    }

    void SetWinText(){
        win.text = "Level Complete!";
        countdownText.text = "";
        SceneManager.LoadScene("Abyss");
    }  

    void SetCount(){
        countdownText.text = "Fish Eggs Left: " + countdown.ToString();
        if(countdown == 0){
            SetWinText();
        }
    }
}
