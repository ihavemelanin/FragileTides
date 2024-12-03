using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;
// Delton Robinson 9/11/2024
public class Cubelet : MonoBehaviour
{
    //prelim declarations
    public Rigidbody2D rb;
    [SerializeField] public float moveSpeed = 0.25f;
    [SerializeField] float maxSpeed = 1f;
    [SerializeField] float speedDecay = 0.6f;
    [SerializeField] float jumpForce = 1f;
    [SerializeField] playerUI playerUI;
    [SerializeField] MainMenuManager mainMenuManager;
    [SerializeField] AudioClip pointSound;
    [SerializeField] AudioClip hitSound;
    [SerializeField] AudioClip eatingSound;
    [SerializeField] AudioClip deathSound;
    [SerializeField] AudioSource SFXSource;
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource deathSoundSource;
    [SerializeField] PlayerInput PlayerInput;
    [SerializeField] public bool invincible = false;

    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Sprite[] sprites;

    public Transform groundCheck;
    public LayerMask groundLayer;
    bool isGrounded;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer.sprite = sprites[playerUI.health-1];
    }

   
    void Update(){
        isGrounded = Physics2D.OverlapCapsule(groundCheck.position, new Vector2(0.90f, 0.3f), CapsuleDirection2D.Horizontal, 0f, groundLayer);
    
        if (rb.velocity.x > maxSpeed){
            rb.velocity = new Vector3(maxSpeed, rb.velocity.y);
        }
        else if (rb.velocity.x < -maxSpeed){
            rb.velocity = new Vector3(-maxSpeed, rb.velocity.y);
        }
        if (rb.velocity.y > maxSpeed){
            rb.velocity = new Vector3(rb.velocity.x, maxSpeed);
        }
        else if (rb.velocity.y < -maxSpeed){
            rb.velocity = new Vector3(rb.velocity.x, -maxSpeed);
        }
        if (isGrounded){
            rb.velocity = new Vector3(rb.velocity.x * speedDecay, rb.velocity.y);
        }
        /*if(playerUI.health >= 4){
            playerUI.health = 3;
            spriteRenderer.sprite = sprites[playerUI.health-1];
        }*/
    }

    public void Movement(Vector3 movement){

        rb.velocity = new Vector3(rb.velocity.x,rb.velocity.y) + (movement * moveSpeed);

    }
    public void Jump(){
        if (isGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce);
        }
    }
    public void Die(){
        Debug.Log("Game Over: Player Died");
        spriteRenderer.sprite = sprites[3];
        StartCoroutine(Death(5));
    }
    IEnumerator Death(int time){
        PlayerInput.acceptInput = false;
        musicSource.Stop();
        deathSoundSource.PlayOneShot(deathSound);
        yield return new WaitForSeconds(time);
        PlayerInput.acceptInput = true;

        mainMenuManager.QuitGame();
    }

    void OnTriggerEnter2D(Collider2D other){
        if(playerUI.health <= 3 && playerUI.health >= 1){
            if(other.CompareTag("Point")){
                Destroy(other.gameObject);
                Debug.Log("Point Gained");
                SFXSource.PlayOneShot(pointSound);
                playerUI.increaseScore();
            }
            else if(other.CompareTag("EnemyProjectile") && invincible == false){
                Destroy(other.gameObject);
                Debug.Log("Player Hit");
                SFXSource.PlayOneShot(hitSound);
                playerUI.decreaseHealth();
                if(playerUI.health <= 3 && playerUI.health >= 1){
                    spriteRenderer.sprite = sprites[playerUI.health-1];
                }
                if(playerUI.health <= 0){
                    Die();
                }
            }
            else if(other.CompareTag("healthProjectile")){
                Destroy(other.gameObject);
                SFXSource.PlayOneShot(eatingSound);
                if(playerUI.health < 3 && playerUI.health >= 1){
                    Debug.Log("Health Gained");
                    playerUI.increaseHealth();
                    spriteRenderer.sprite = sprites[playerUI.health-1];
                    
                }
            }


    }

    }
}
