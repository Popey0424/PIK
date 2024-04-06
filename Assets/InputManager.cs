using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{

    private CharacterControler playerInput;
    public CharacterControler.GameplayActions Gameplay;


    private CharacterMovement motor;
    // Start is called before the first frame update
    void Awake()
    {
        playerInput = new CharacterControler();
        Gameplay = playerInput.Gameplay;

        motor = GetComponent<CharacterMovement>();


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        motor.ProcessMove(Gameplay.Movement.ReadValue<Vector2>());
    }
}
