using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private CharacterController controller;
    private Vector2 playerVelocity;
    private bool isGrounded;
    public float speed = 5f;
    public float gravity = -9.8f;
    public float jumpHeight = 3f;
    bool sprinting = false;
    public bool crouching;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;

    }


    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.y = input.y; // Utiliser l'axe Y pour le mouvement 2D
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);

        // Ajouter la gravité uniquement sur l'axe Y
        playerVelocity.y += gravity * Time.deltaTime;

        // Si le joueur est au sol et tombe, réinitialiser la vélocité verticale
        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }

        // Ne déplacer le joueur que sur les axes X et Y
        controller.Move(new Vector3(playerVelocity.x, playerVelocity.y, 0) * Time.deltaTime);

        Debug.Log(playerVelocity.y);
    }
}
