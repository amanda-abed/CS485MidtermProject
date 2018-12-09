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
    private Vector3 movement;
    private int countdown;

    public GameObject shark;

	private AudioSource audio;
	public AudioClip audioClip;

	AsyncOperation scene;

    void Start()
    {
        shark = GameObject.FindGameObjectWithTag("shark");
        rb = GetComponent<Rigidbody>();
        countdown = 5;
        //speed = 10.0f;
        SetCount();
        win.text = "";
        audio = GetComponent<AudioSource>();
        scene = SceneManager.LoadSceneAsync("Coral");
        scene.allowSceneActivation = false;
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
        movement = Vector3.zero;
     	movement.x = Input.GetAxis("Horizontal");
     	movement.z = Input.GetAxis("Vertical");
        movement.y = 0;
        movement = movement.normalized;

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
       /* 
        if (transform.position.y != 1)
        {
            transform.position = new Vector3(transform.position.x, 1, transform.position.z);
        }
        */
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            audio.Play();
            countdown -= 1;
            SetCount();
        }
    }

    void SetWinText(){
        win.text = "Level Complete!";
        audio.PlayOneShot(audioClip, 0.7f);
        countdownText.text = "";
        StartCoroutine(WaitAndLoadScene());
    }  

    IEnumerator WaitAndLoadScene(){
    	yield return new WaitForSeconds(1);
    	scene.allowSceneActivation = true;
    	//SceneManager.LoadSceneAsync("Coral");
    }

    void SetCount(){
        countdownText.text = "Fish Eggs Left: " + countdown.ToString();
        if(countdown == 0){
            SetWinText();
        }
    }
}
