using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float movementSpeed = 7.5f;
    public Camera cam;
    void Update()
    {
        FaceCursor();
        MovePlayer();
    }

    void FaceCursor()
    {
        Vector3 point = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
        // Using some math to calculate the point of intersection between the line going through the camera and the mouse position with the XZ-Plane
        float t = cam.transform.position.y / (cam.transform.position.y - point.y);
        Vector3 finalPoint = new Vector3(t * (point.x - cam.transform.position.x) + cam.transform.position.x, 1, t * (point.z - cam.transform.position.z) + cam.transform.position.z);
        //Rotating the object to that point
        transform.LookAt(finalPoint, Vector3.up);
    }

    void MovePlayer()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical) * movementSpeed * Time.deltaTime;
        transform.Translate(movement, Space.World);
    }
}
