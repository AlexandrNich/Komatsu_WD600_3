using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestController : MonoBehaviour
{
    public WorkMotor WorkMotor;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            WorkMotor.Work(1.0f);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            WorkMotor.Work(-1.0f);
        }
        else
        {
            WorkMotor.Work(.0f);
        }
    }
}
