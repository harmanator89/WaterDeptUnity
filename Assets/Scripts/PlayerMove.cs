using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public float speed;

    private Rigidbody GamePlayer;
    
    void Start()
    {
        GamePlayer = GetComponent<Rigidbody>();
    }


    //Code called before rendering a frame (GAME CODE)
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        

        Vector3 movement = speed * new Vector3(moveHorizontal, 0f, moveVertical);

        movement += GamePlayer.position;
      
        GamePlayer.MovePosition(movement);
    }

    //Code called before preforming any physics calculations
    void FixedUpdate()
    {
        //GamePlayer.AddForce(movement);
    }

}
