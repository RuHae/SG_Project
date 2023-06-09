using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drill_Move : MonoBehaviour
{
    private Rigidbody2D player;
    public float rotationForce;
    public float radius = 5;
    public float angle;
    public float center_x;
    public float speed = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        angle = 5f * Mathf.Deg2Rad;
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetMouseButtonDown(0))
        // {
        //     player.AddForce(new Vector2(rotationForce*100, 0));
        // }
        
        // angle += RotateSpeed * Time.deltaTime;
        center_x = transform.position.x - radius;
        var Pos = new Vector2(transform.position.x, transform.position.y);

        var offset = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * radius * speed *Time.deltaTime;
        player.transform.position = Pos + offset;
        Quaternion target = Quaternion.Euler(0, 0, player.transform.rotation.z+1);
        player.transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime);
        Debug.Log(offset);
        Debug.Log(transform.position);
        Debug.Log(Mathf.Cos(angle));
        Debug.Log(Mathf.Sin(angle));
    }
}
