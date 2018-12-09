using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Wander : MonoBehaviour 
{
    private Vector3 tarPos;

    public float movementSpeed;
    private float rotSpeed = 2.0f;
    private float minX, maxX, minZ, maxZ;
    public float force = 50.0f;
    public float minimumDistToAvoid = 5.0f;

	// Use this for initialization
	void Start () 
    {
        minX = 25.0f;
        maxX = 450.0f;

        minZ = 40.0f;
        maxZ = 450.0f;

        //Get Wander Position
        GetNextPosition();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if(Vector3.Distance(tarPos, transform.position) <= 25.0f)
            GetNextPosition();

        Quaternion tarRot = Quaternion.LookRotation(tarPos - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, tarRot, rotSpeed * Time.deltaTime);

        transform.Translate(new Vector3(0, 0, movementSpeed * Time.deltaTime));

        Vector3 dir = (tarPos - transform.position);
        dir.Normalize();

	}

    void GetNextPosition()
    {
        tarPos = new Vector3(Random.Range(minX, maxX), 2.0f, Random.Range(minZ, maxZ));
    }

    public void AvoidObstacles(ref Vector3 dir)
    {
        RaycastHit hit;

        //Only detect layer 8 (Obstacles)
        int layerMask = 1 << 9;

        //Check that the vehicle hit with the obstacles within it's minimum distance to avoid
        if (Physics.Raycast(transform.position, transform.forward, out hit, minimumDistToAvoid, layerMask))
        {
            //Get the normal of the hit point to calculate the new direction
            Vector3 hitNormal = hit.normal;
            hitNormal.y = 2.0f; //Don't want to move in Y-Space

            //Get the new directional vector by adding force to vehicle's current forward vector
            dir = transform.forward + hitNormal * force;
            Debug.DrawLine(hitNormal, transform.position, Color.red);
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("fish"))
        {
            other.gameObject.SetActive(false);
            SetGameOver();
        }
    }

    void SetGameOver()
    {
        //gameOverText.text = "GAME OVER!";
        SceneManager.LoadScene("GameOverScene");
    }
}
