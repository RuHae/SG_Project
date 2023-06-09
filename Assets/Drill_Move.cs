using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drill_Move : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] private KeyCode Right;
    private float moveDirection = -1;
    private float currentMoveDirection;
    private Rigidbody2D RB;
    public float MoveSpeed;
    public float default_angle;
    public float rotation_speed;
    public float centerOffsetCamera = 4;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(Right))
        {
            moveDirection = 1;
        }else if(Input.GetKeyUp(Right)){
            moveDirection = -1;
        }
        currentMoveDirection = Mathf.Lerp(currentMoveDirection, moveDirection, rotation_speed*Time.deltaTime); // Linear Interpolation for smoother rotation
        transform.rotation = Quaternion.Euler(0, 0, default_angle*currentMoveDirection); // Rotation angle
        RB.velocity = (transform.up * -1) * MoveSpeed;  // Drill going locally down
        // RB.velocity = new Vector2(moveDirection, 0)* MoveSpeed;


        camera.transform.position = new Vector3(0, transform.position.y - centerOffsetCamera, -10); // Camera default following the drill only on y direction
    }
}
