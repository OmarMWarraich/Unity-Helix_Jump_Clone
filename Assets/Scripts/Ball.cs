using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody rb;
    public float jumpForce;
    public GameObject splashPrefab;
    private GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnCollisionEnter(Collision collision)
    {
    	rb.velocity = new Vector3(0, jumpForce, 0);
    	
    	GameObject splash = Instantiate(splashPrefab, transform.position + new Vector3(0f, -0.2f, 0f), Quaternion.Euler(90, 0, 0));
    	splash.transform.SetParent(collision.gameObject.transform);	
    	
    	string materialName = collision.gameObject.GetComponent<MeshRenderer>().material.name;
	
	if (materialName == "Platform Safe (Instance)") 
	{
	// continue
	}
	else if (materialName == "Platform Danger (Instance)") 
	{
	    // gameover
	    gm.RestartGame();
	}
	else if (materialName == "Last Ring (Instance)") 
	{
	// level passed
	    Debug.Log("Congrats!!");
	}
    }
}
