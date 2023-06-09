using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drill_Move : MonoBehaviour
{
    private Rigidbody2D player;
    public float rotationForce;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            player.AddForce(new Vector2(rotationForce*100, 0));
        }
        
        // _angle += RotateSpeed * Time.deltaTime;


        // var offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * Radius;
        // transform.position = _centre + offset;
        // Debug.Log(transform.position);
    }
}
