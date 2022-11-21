using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class trapFunction : MonoBehaviour
{
    //[SerializeField] private float damage;    replace with working health code

    [Header("Firetrap Timers")]
    [SerializeField] private float activationDelay;
    [SerializeField] private float activeTime;

    public AudioSource HighSpike;
    public AudioSource LowSpike;

    private Animator anim;
    private SpriteRenderer spriteRend;

    private bool triggered;  //When the trap gets triggered
    private bool active;    //WHEN TRAP IS ACTIVE AND CAN DAMG PLAYER

    private void Awake()    //references the aniamtor tool
    {
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")   //collision detectores for activating trap and activating damage
        {
            if (!triggered)
            {
                //trigger trap
                StartCoroutine(ActivateSpikeTrap());
            }
            if (active)
            {
                //take damage
                {
                    GameManager.gameManager._playerHealth.Dmg(5);
                }
            }

            
        }
    }
    private IEnumerator ActivateSpikeTrap()
    {
        //Turn sptite red to check for player triggering it
        triggered = true;
        anim.SetBool("activateWarning", true);   //turn red to warn player 
        LowSpike.Play();
        //wait delay for treap to do damage
        yield return new WaitForSeconds(activationDelay);
        active = true;
        anim.SetBool("activateTrap", true);
        HighSpike.Play();
        //Waits X sconds to deactivate trap
        yield return new WaitForSeconds(activeTime);
        active = false;
        triggered = false;
        anim.SetBool("activateWarning", false);
        
        anim.SetBool("activateTrap", false);
        LowSpike.Play();
    }
}