using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class trapFunction : MonoBehaviour
{
    //[SerializeField] private float damage;    replace with working health code

    [Header("Spiketrap Timers")]
    [SerializeField] private float activationDelay;
    [SerializeField] private float activeTime;

    public AudioSource HighSpike;
    public AudioSource LowSpike;

    private Animator anim;
    private SpriteRenderer spriteRend;

    private bool triggered;  // When the trap gets triggered
    private bool active;    //When the trap is active and can hurt the player

    private void Awake()
    {
        anim = GetComponent<Animator>(); // References the aniamtor tool
        spriteRend = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")   // Collision decets for active trap and active damage
        {
            if (!triggered)
                StartCoroutine(ActivateSpikeTrap()); // Trigger trap with a delay
            if (active)
            {
                Debug.Log("Trap Damaged Player");
                GameManager.gameManager._playerHealth.Dmg(5); // Player Taking Damage
            }
        }
    }
    private IEnumerator ActivateSpikeTrap()
    {
        Debug.Log("Trap Triggered");
        //Turn sprite red to check for player triggering it
        triggered = true;
        anim.SetBool("activateWarning", true);   // Turns red to warn player
        LowSpike.Play();
        yield return new WaitForSeconds(activationDelay); // Delay for trap damage
        active = true;
        anim.SetBool("activateTrap", true);
        HighSpike.Play();
        yield return new WaitForSeconds(activeTime); //Waits to deactivate trap
        active = false;
        triggered = false;
        anim.SetBool("activateWarning", false);
        
        anim.SetBool("activateTrap", false);
        LowSpike.Play();
    }
}