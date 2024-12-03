using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileScript : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public float despawnZone = -11;
    [SerializeField] bool RandomizePositionOnStart = true;
    [SerializeField] bool RandomizeSizeOnStart = false;
    [SerializeField] bool RandomizeColorOnStart = false;
    [SerializeField] bool RandomizeVelocityOnStart = true;
    [SerializeField] bool RandomizeRotationOnStart = true;
    [SerializeField] float minSize = 1.2f;
    [SerializeField] float maxSize = 1.7f;
    
    void Awake(){
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Start(){
        if(RandomizePositionOnStart) RandomizePosition();
        if(RandomizeSizeOnStart) RandomizeSize();
        if(RandomizeColorOnStart) RandomizeColor();
        if(RandomizeVelocityOnStart) RandomizeVelocity();
        if(RandomizeRotationOnStart) RandomizeRotation();
    }
    void Update(){
        if(transform.position.x < despawnZone){
            Destroy(gameObject);
        }
    }


    public void RandomizeVelocity(){
        float maxSpeed = -3;
        float minSpeed = -3;
        GetComponent<Rigidbody2D>().velocity = new Vector3(Random.Range(minSpeed, maxSpeed),0,0);
    }
    public void RandomizeColor(){
        float minColorVal = .25f;
        float maxColorVal = .75f;
        spriteRenderer.color = new Color(Random.Range(0f,0.6f), Random.Range(minColorVal,maxColorVal), Random.Range(minColorVal,maxColorVal));
    }
    public void RandomizeSize(){
        transform.localScale = new Vector3(1f, Random.Range(minSize, maxSize), 1);
    }
    public void RandomizePosition(){
        float minY = -3.5f;
        float maxY = 3.5f;
        transform.position = new Vector3(transform.position.x, Random.Range(minY, maxY), 0);
    }
    public void RandomizeRotation(){
        float minRot = 0;
        float maxRot = 360;
        transform.rotation = Quaternion.Euler(0,0,Random.Range(minRot, maxRot));
    }

}
