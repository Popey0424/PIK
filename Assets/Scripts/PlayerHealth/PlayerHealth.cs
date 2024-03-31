using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Overlays;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public GameObject Character;
    Animator CharacterANIM;
    private float health;
    private float lerpTimer;
    [Header("Health Bar")]
    public float maxHealth = 100;
    public float chipSpeed = 2f;
    public float lightAttack;
    public float MediumAttack;
    public float HeavyAttack;
    public float SpecialAttack;
    public Image frontHealthBar;
    public Image backHealthBar;
    public TextMeshProUGUI healthText;
    public float blockDamageOffset;
    

    public bool isBlocking;

    //[Header(" Damage Overlay")]
    //public Image DamageOverlay;
    //public float duration;
    //public float fadeSpeed;

    //private float durationTimer;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        //DamageOverlay.color = new Color(DamageOverlay.color.r, DamageOverlay.color.g, DamageOverlay.color.b, 0);
        CharacterANIM = Character.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        health = Mathf.Clamp(health, 0, maxHealth);
        UpdateHealthUI();
        //if (DamageOverlay.color.a > 0)
        //{
        //    if (health < 30)
        //    {
        //        return;
        //    }
        //    durationTimer += Time.deltaTime;
        //    if (durationTimer > duration)
        //    {
        //        float tempAlpha = DamageOverlay.color.a;
        //        tempAlpha -= Time.deltaTime * fadeSpeed;
        //        DamageOverlay.color = new Color(DamageOverlay.color.r, DamageOverlay.color.g, DamageOverlay.color.b, tempAlpha);
        //    }
        //}


    }
    public void UpdateHealthUI()
    {
        Debug.Log(health);
        float fillF = frontHealthBar.fillAmount;
        float fillB = backHealthBar.fillAmount;
        float hFraction = health / maxHealth;
        if (fillB > hFraction)
        {
            frontHealthBar.fillAmount = hFraction;
            backHealthBar.color = Color.red;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            percentComplete = percentComplete * percentComplete;
            backHealthBar.fillAmount = Mathf.Lerp(fillB, hFraction, percentComplete);
        }
        if (fillF < hFraction)
        {

            backHealthBar.color = Color.green;
            backHealthBar.fillAmount = hFraction;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            percentComplete = percentComplete * percentComplete;
            frontHealthBar.fillAmount = Mathf.Lerp(fillF, backHealthBar.fillAmount, percentComplete);
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        healthText.text = health.ToString();
        lerpTimer = 0f;
        //durationTimer = 0;
        //DamageOverlay.color = new Color(DamageOverlay.color.r, DamageOverlay.color.g, DamageOverlay.color.b, (float)0.3);
    }
    public void RestoreHealth(float healAmount)
    {
        health += healAmount;
        healthText.text = health.ToString();
        lerpTimer = 0f;
    }
    [ContextMenu("LightHit")]
    public void LightDamage()
    {

       
            health -= lightAttack;
            CharacterANIM.SetTrigger("HitLight");
            healthText.text = health.ToString();
            lerpTimer = 0f;
        
            //if (isBlocking)
            //{

            //}
            
        
    }

    [ContextMenu("MidAttack")]
    public void MediumDamage()
    {
        if(isBlocking)
        {

        }
        health -= MediumAttack;
        CharacterANIM.SetTrigger("HitMedium");
        healthText.text = health.ToString();
        lerpTimer = 0f;
    }

}
