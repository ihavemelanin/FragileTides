using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] float projectileSpeed = 2.5f;

    [Header("Prefabs")]
    [SerializeField] GameObject projectilePrefab;

    [Header("Helpers")]
    [SerializeField] Transform spawnTransform;
    [Header("UI")]
    [SerializeField] TMPro.TextMeshProUGUI ammoText;
    [SerializeField] AudioClip fireSound;
    [SerializeField] AudioSource audioSource;
    [SerializeField] int ammo = 0;

    //launch a projectile forward
    public void Launch(){
        if(ammo > 0){
            ammo--;
            ammoText.text = ammo + "/5";
            GameObject newProjectile = Instantiate(projectilePrefab,spawnTransform.position, Quaternion.identity);
            SpriteRenderer spriteRenderer = newProjectile.GetComponent<SpriteRenderer>();
            float minColorVal = .25f;
            float maxColorVal = .5f;
            spriteRenderer.color = new Color(Random.Range(minColorVal,maxColorVal), Random.Range(minColorVal,maxColorVal), Random.Range(0.9f,1f));
            newProjectile.GetComponent<Rigidbody2D>().velocity = new Vector3(0, projectileSpeed, 0);
            audioSource.PlayOneShot(fireSound);

        }
    }
    public void Reload(){
        ammo = 5;
        ammoText.text = ammo + "/5";
    }
    void Start(){
        Reload();
    }
}
