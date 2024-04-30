using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class PlantTree : MonoBehaviour
{
    public GameObject plantPrefab;  // The prefab of the plant to be instantiated
    public Timer time;
   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Plant();
        }
    }

    void Plant()
    {
        // Instantiate the plant prefab at the current position of the player
        Instantiate(plantPrefab, transform.position, Quaternion.identity);
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {
            time.remining = 10;
            int minutes = Mathf.FloorToInt(time.remining / 60);
            int seconds = Mathf.FloorToInt(time.remining % 60);
            time.timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}


