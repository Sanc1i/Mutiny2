using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public float offset = 25f, speed = 10f;
    public Vector2 widthPosition, heightPosition;

    private float screenWidth, screenHeight;
    private Vector3 cameraMove;
    void Start()
    {
        screenHeight = Screen.height; screenWidth = Screen.width;
        cameraMove = new Vector3(transform.position.x,transform.position.y,transform.position.z);
    }

    private void LateUpdate() {
        if ((Input.mousePosition.x > screenWidth - offset) && transform.position.x < widthPosition.y)
        {
            cameraMove.x += MoveSpeed();
        }
        if ((Input.mousePosition.x < offset) && transform.position.x > widthPosition.x)
        {
            cameraMove.x -= MoveSpeed();
        }
        if ((Input.mousePosition.y > screenHeight - offset) && transform.position.y < heightPosition.y)
        {
            cameraMove.y += MoveSpeed();
        }
        if ((Input.mousePosition.y < offset) && transform.position.y > heightPosition.x)
        {
            cameraMove.y -= MoveSpeed();
        }
        transform.position = cameraMove;
    }
    float MoveSpeed(){
        return speed*Time.deltaTime;
    }
}
