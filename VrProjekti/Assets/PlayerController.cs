using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;



public class PlayerController : MonoBehaviour
{
    public SteamVR_Action_Vector2 input;
    public float speed=1;
    private CharacterController characterContoller;
    public GameObject ball;
    public float ballDistance;

    private Vector3 ballOriginalPosition;
    public float maxDistanceFromPlayer=15f;

    private void Start()
    {
        characterContoller = GetComponent<CharacterController>();
        ballOriginalPosition = ball.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        ballDistance = Vector3.Distance(ball.transform.position, transform.position);
       // Debug.Log(ballDistance);
        if(input.axis.magnitude > 0.1f)
        {
            Vector3 direction = Player.instance.hmdTransform.TransformDirection(new Vector3(input.axis.x, 0, input.axis.y));
            // transform.position += speed * Time.deltaTime * Vector3.ProjectOnPlane(direction,Vector3.up);
            characterContoller.Move(speed * Time.deltaTime * Vector3.ProjectOnPlane(direction, Vector3.up) - new Vector3(0, 9.81f, 0) * Time.deltaTime);
        }
        if(ballDistance > maxDistanceFromPlayer)
        {
            ball.transform.position = ballOriginalPosition;
            ball.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            ball.GetComponent<Rigidbody>().freezeRotation = true;
        }
        

       

        
       
    }
}
