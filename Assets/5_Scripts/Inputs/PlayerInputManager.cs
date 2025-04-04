using UnityEngine;
using UnityUtils;
using System;


public class PlayerInputManager : Singleton<PlayerInputManager>
{
    //Inputs depend a lot on the type of game that you are building. 
    //This is just an example class to call on ESC pressed so that you can trigger the pause menu.
    public event Action onESCPressed;
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            onESCPressed?.Invoke();
        }
    }
}
