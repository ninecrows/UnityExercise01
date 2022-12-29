using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class CharacterMotion : MonoBehaviour
{
    // Base speed for the character bubble
    public float speed = 3.0f;

    public float SensitivityVertical = 5.0f;
    public float SensitivityHorizontal = 5.0f;

    public float RotateLimitUp = 45.0f; // degrees
    public float RotateLimitDown = -45.0f; // degrees

    private float VerticalAngle = 0.0f;
    
    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        // Sample the mouse state.
        var xAxis = Input.GetAxis("Mouse X");
        var yAxis = Input.GetAxis("Mouse Y");
        var speed = Input.GetAxis("Horizontal");

        //Debug.Log($"Frame {xAxis} x {yAxis}");
        
        var elapsed = Time.deltaTime;
        
        var RotationDeltaVertical = yAxis * SensitivityVertical;
        var RotationDeltaHorizontal = xAxis * SensitivityHorizontal;

        VerticalAngle += RotationDeltaVertical;
        var RotationVertical = VerticalAngle; //Mathf.Clamp(VerticalAngle, RotateLimitDown, RotateLimitUp);
        if (RotationVertical > 45.0f)
        {
            RotationVertical = 45.0f;
        }

        if (RotationVertical < -45.0f)
        {
            RotationVertical = -45.0f; 
        }
        
        var RotationHorizontal = transform.localEulerAngles.y;
        RotationHorizontal += RotationDeltaHorizontal;

        //Debug.Log($"Final {RotationHorizontal} x {RotationVertical}");
        
        transform.localEulerAngles = new Vector3(RotationVertical, 0.0f, 0.0f);
    }
}
