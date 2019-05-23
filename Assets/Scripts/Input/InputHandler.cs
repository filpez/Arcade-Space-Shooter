using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace __Input__
{
    public class InputHandler : MonoBehaviour
    {
        __Shooter__.Ship player;
        ICommand buttonMouseLeft;

        void Start()
        {
            player = GetComponent<__Shooter__.Ship>();
            
            //Bind commands
            buttonMouseLeft = new FireShot();
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
        }
    }
}

