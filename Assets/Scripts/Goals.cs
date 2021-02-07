using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goals : MonoBehaviour
{
    public bool LeftPlayerGoal;

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.CompareTag("Ball"))
        {
            if(!LeftPlayerGoal)
            {
                GameObject.Find("Score").GetComponent<Score>().LeftPlayerScored();
            }
            else 
            {
                GameObject.Find("Score").GetComponent<Score>().RightPlayerScored();
            }
        }
    }
}
