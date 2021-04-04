 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTowers : MonoBehaviour
{
    public GameObject Tower;
    public GameObject World;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "TowerSpot")
                {
                    if (GameObject.Find("Player").GetComponent<Player>().coins >= 50)
                    {
                        GameObject.Find("Player").GetComponent<Player>().coins -= 50;
                        PlaceTower(hit.transform.position);
                        Debug.Log($"Tower placed. You now have {GameObject.Find("Player").GetComponent<Player>().coins} coins.");
                    }
                    else
                    {
                        Debug.Log("Not enought coins to place tower");
                    }
                }
            }
        }
    }

    void PlaceTower(Vector3 position)
    {
        Instantiate(Tower, position, Quaternion.identity, World.transform);
    }
}
