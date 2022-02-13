using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public float power = 2f;
    public bool isGrounded = true;
    public Rigidbody2D rb;
    Camera cam;
    public Vector2 minPower,maxPower;
    private Vector2 force;
    private Vector3 startPoint, endPoint;
    

    private void Start() {
        cam = Camera.main;    
    }

    void OnCollisionEnter2D (Collision2D other)
    {
        isGrounded = true;
    }

    void OnCollision2D (Collision2D collision)
    {
        if(gameObject.name == "RedZone"){
            Destroy(this);
        }
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0))
        {
            startPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            startPoint.z = 15;

        }
        if (Input.GetMouseButtonUp(0))
        {
            endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            endPoint.z = 15;

            if(isGrounded == true){
                isGrounded = false;
                force = new Vector2(Mathf.Clamp(startPoint.x - endPoint.x, minPower.x, maxPower.x), Mathf.Clamp(startPoint.y - endPoint.y, minPower.y, maxPower.y));
                rb.AddForce(force * power, ForceMode2D.Impulse);
            }
        }
        
    }
}