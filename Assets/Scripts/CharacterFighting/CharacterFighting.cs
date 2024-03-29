using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFighting : MonoBehaviour
{
    public GameObject Character;
    Animator controllerANIM;

    public bool isBlocking;


    private void Start()
    {
        controllerANIM = Character.GetComponent<Animator>();
        isBlocking = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown("A"))
        {
            attack1();
        }
    }

    [ContextMenu("Attack01")]
    public void attack1()
    {
        
        controllerANIM.SetTrigger("Punching01");
    }

    public void SetBlocking()
    {

    }
}
