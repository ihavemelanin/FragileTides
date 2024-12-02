using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This script handles the player's input for controlling a Cubelet character in the game.
/// It listens for specific key presses to trigger actions such as firing a weapon and moving the character.
/// The Update method checks for the spacebar key press to fire the weapon, while the FixedUpdate method
/// handles movement input for the 'A' and 'D' keys to move the character left and right, respectively.
/// The movement is applied to the Cubelet character through the Movement method.
/// </summary>
/// /// {Delton Robinson} 9/11/2024
public class PlayerInput : MonoBehaviour
{

    [SerializeField] Cubelet playerCubelet;
    [SerializeField] MainMenuManager mainMenuManager;
    [SerializeField] public bool acceptInput = true;
    //public Transform playerPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        
  
    }

    void FixedUpdate()
    {
        Vector3 movement = Vector3.zero;

       if(acceptInput){
        // if(Input.GetKey(KeyCode.Space))
        // {
        //     playerCubelet.Jump();
        // }
            if(Input.GetKey(KeyCode.Escape))
             {
                    mainMenuManager.backToMainMenu();
             }
             if(Input.GetKey(KeyCode.W))
             {
                 movement += new Vector3(0,1,0);
             }
             if(Input.GetKey(KeyCode.S))
             {
                 movement += new Vector3(0,-1,0);
             }
             if(Input.GetKey(KeyCode.A))
             {
                 movement += new Vector3(-1,0,0);
             }
             if(Input.GetKey(KeyCode.D))
             {
                 movement += new Vector3(1,0,0);
             }
             playerCubelet.Movement(movement);
        }
    }









}

