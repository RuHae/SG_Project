using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drill_Move : MonoBehaviour
{

    [SerializeField]
    private float RotateSpeed = 5f;
    private float Radius = 2f;

    private Vector2 _centre;
    private float _angle;


    // Start is called before the first frame update
    void Start()
    {
        _centre = transform.position;
        // Debug.Log(_centre);
    }

    // Update is called once per frame
    void Update()
    {
        _angle += RotateSpeed * Time.deltaTime;
 
        var offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * Radius;
        transform.position = _centre + offset;
        // Debug.Log(transform.position);
    }
}
