using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Timer : MonoBehaviour
{
  public TextMeshProUGUI timerText ;
    public float remining ;
    //[SerializeField] GameObject charecterToDestroy ;
    [SerializeField] GameObject player;
    //[SerializeField] GameObject currentCharecter;
    //[SerializeField] GameObject charecterToInst;
    [SerializeField] Transform respawnPoint;
    public PlantTree plant;

    // Update is called once per frame


    void Update()
    {

        if(remining > 0)
        {
            remining -= Time.deltaTime;

        }
        else if (remining <= 0)
        {
            remining = 0;
            //Destroy(currentCharecter);
            //currentCharecter = Instantiate(oldChareterPrefab,new Vector3(-2, -2, 0), Quaternion.identity) ;
            player.transform.position = respawnPoint.position;
            remining = 10;
        }
        
        int minutes = Mathf.FloorToInt(remining / 60);
        int seconds = Mathf.FloorToInt(remining % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

      
    }
    public void ModifyRemaining(float newValue)
    {
        remining = newValue;
        int minutes = Mathf.FloorToInt(remining / 60);
        int seconds = Mathf.FloorToInt(remining % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

    }
}
