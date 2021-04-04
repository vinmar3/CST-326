using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Ray ray;
    private RaycastHit hit;
    public int coins = 100;

    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity) && Input.GetMouseButtonDown(0))
        {
            if (hit.collider.tag == "BigBadGuy" || hit.collider.tag == "SmallBadGuy")
            {
                hit.collider.GetComponent<Enemy>().EnemyHealth();
            }
        }
    }
}
