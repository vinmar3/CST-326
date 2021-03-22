using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Ray ray;
    private RaycastHit hit;
    public int coins = 0;

    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity) && Input.GetMouseButtonDown(0))
        {
            if (hit.collider.name == "BigBadGuy" || hit.collider.name == "SmallBadGuy")
            {
                hit.collider.GetComponent<Enemy>().EnemyHealth();
            }
        }
    }
}
