using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace __Input__
{
    public class InputHandler : MonoBehaviour
    {
        __Shooter__.Ship player;
        ICommand buttonMouseLeft;
        ICommand buttonMouseRight;
        ICommand buttonW;
        ICommand buttonA;
        ICommand buttonD;
        ICommand buttonSpace;


        void Start()
        {
            player = GetComponent<__Shooter__.Ship>();
            
            //Bind commands
            buttonMouseLeft = new FireShot();
            buttonMouseRight = new FireRocket();

            buttonW = new MoveForward();
            buttonA = new RotateLeft();
            buttonD = new RotateRight();
            buttonSpace = new Pause();

        }

        void Update()
        {
            HandleInput();
        }

        void HandleInput()
        {
            if (Input.GetMouseButtonDown(0))
            {
                ((FireShot)buttonMouseLeft).target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                ((FireShot)buttonMouseLeft).target.y = 0;
                buttonMouseLeft.Execute(player);
            }
            else if (Input.GetMouseButtonDown(1))
            {
                ((FireRocket)buttonMouseRight).target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                ((FireRocket)buttonMouseRight).target.y = 0;
                buttonMouseRight.Execute(player);
            }
            
            if (Input.GetKey(KeyCode.W))
            {
                buttonW.Execute(player);
            }

            if (Input.GetKey(KeyCode.A))
            {
                buttonA.Execute(player);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                buttonD.Execute(player);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                buttonSpace.Execute(player);
            }
        }
    }
}

