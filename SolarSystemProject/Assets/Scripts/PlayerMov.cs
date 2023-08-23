using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    public float HorizontalMov;
    public float VerticalMov;
    private Vector3 PlayerInput;

    public CharacterController Player;

    public float PlayerSpeed;
    public float Gravity;
    public float PlayerFallSpeed;
    public float JumpForce;
    private Vector3 MovePlayer;

    private Vector3 Flydirection;

    public Camera MainCamera;
    private Vector3 CamForward;
    private Vector3 CamRight;

    void Start()
    {
        Player=GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalMov=Input.GetAxis("Horizontal");
        VerticalMov=Input.GetAxis("Vertical");

        PlayerInput= new Vector3(HorizontalMov,0,VerticalMov);
        PlayerInput= Vector3.ClampMagnitude(PlayerInput,1);

        CamDirection();

        MovePlayer = PlayerInput.x * CamRight + PlayerInput.z * CamForward;
        MovePlayer = MovePlayer*PlayerSpeed;

        Player.transform.LookAt(Player.transform.position + MovePlayer);
                
        PlayerActions();
        SetGravity();

        Player.Move(MovePlayer*Time.deltaTime);

    }

    void CamDirection()
    {
        CamForward=MainCamera.transform.forward;
        CamRight=MainCamera.transform.right;

        CamForward.y=0;
        CamRight.y=0;

        CamForward = CamForward.normalized;
        CamRight = CamRight.normalized;
    }
    
    public void PlayerActions()
    {
        if (Input.GetButtonDown("Jump"))
        {
            PlayerFallSpeed=JumpForce;
            MovePlayer.y=PlayerFallSpeed;
        }
    }

    public void Fly()
    {
        Flydirection = Vector3.up * JumpForce * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Player.Move(Flydirection);
        }

        else if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Player.Move(-Flydirection);
        }
    }

    public void SetGravity()
    {
        if(Player.isGrounded)
        {
            PlayerFallSpeed = -Gravity*Time.deltaTime;
            MovePlayer.y = PlayerFallSpeed;
        }
        else
        {
            PlayerFallSpeed -= Gravity*Time.deltaTime;
            MovePlayer.y = PlayerFallSpeed;
        }
    }
}
