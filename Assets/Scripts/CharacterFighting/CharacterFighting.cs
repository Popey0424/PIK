using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFighting : MonoBehaviour
{

    public KeyCode PunchAttack01;
    public KeyCode KickAttack01;
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
        if (Input.GetKeyDown(PunchAttack01))
        {
            attack1();
        }
        if (Input.GetKeyDown(KickAttack01))
        {
            attack2();
        }

        // faire la memem chose si j'arrive pas a rednre le bouclier automatique
    }

    [ContextMenu("Attack01")]
    public void attack1()
    {
        
        controllerANIM.SetTrigger("Punching01");
        isBlocking = false;
        controllerANIM.SetBool("Blocking", isBlocking);
    }

    [ContextMenu("Kicking01")]
    public void attack2()
    {
        controllerANIM.SetTrigger("Kicking01");
        isBlocking = false;
        controllerANIM.SetBool("Blocking", isBlocking);
    }

    public void SetBlocking()
    {
        if(!isBlocking)
        {
            isBlocking = false;
        }
        else if (!isBlocking)
        {
            isBlocking = true;
        }
        controllerANIM.SetBool("Blocking", isBlocking);
    }
}
