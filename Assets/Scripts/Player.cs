using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float xAxis;
    private float yAxis;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        xAxis = Input.GetAxisRaw("Horizontal");
        yAxis = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A))
            Move(true);
        else if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.W))
            Move(false);
    }

    private void Move(bool isHorizontalAxis)
    {
        if (isHorizontalAxis)
        {
            MoveCommand<Transform> command = new MoveCommand<Transform>(transform, transform.right * xAxis, 1);
            GameManager.Instance.commandProcessor.Execute(command);
        }
        else
        {
            MoveCommand<Transform> command = new MoveCommand<Transform>(transform, transform.forward * yAxis, 1);
            GameManager.Instance.commandProcessor.Execute(command);
        }           
    }
}
