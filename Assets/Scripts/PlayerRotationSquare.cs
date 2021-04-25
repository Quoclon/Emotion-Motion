using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotationSquare : MonoBehaviour
{
    //public float degreesPerSec = 360f;    
    public float rotationAmount = 10f;
    public float currentRotation = 0f;


    // Start is called before the first frame update
    void Start()
    {
        currentRotation = transform.localRotation.eulerAngles.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
            currentRotation += rotationAmount;

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
            currentRotation -= rotationAmount;

        if (currentRotation > 360)
            currentRotation = 0;

        if (currentRotation < -360)
            currentRotation = 0;

        //Debug.Log(currentRotation);
        RotateSquare();
    }
    

    void RotateSquare()
    {
        transform.localRotation = Quaternion.Euler(new Vector3(0, 0, currentRotation));
    }

    void RotateSquarePerSecond()
    {
        //float rotAmount = degreesPerSec * Time.deltaTime;
        //float curRot = transform.localRotation.eulerAngles.z;
        //transform.localRotation = Quaternion.Euler(new Vector3(0, 0, curRot + rotAmount));
    }
}
