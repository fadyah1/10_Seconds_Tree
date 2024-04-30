using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    [SerializeField] Timer time;
    [SerializeField] GameObject plantPrefab;
    [SerializeField] float moveSpped = 0.01f;
    [SerializeField] float move = 1f;
    bool isFlip = true;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        // float steerAmount = Input.GetAxis("Horizontal") * move * Time.deltaTime;
        // float moveAmount = Input.GetAxis("Vertical") * moveSpped * Time.deltaTime;
        //transform.Translate(steerAmount, moveAmount, 0);
        //transform.Rotate(0, 0, steerAmount);

        float movement = Input.GetAxisRaw("Horizontal");
        float movementUP = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(movement * moveSpped, movementUP * moveSpped);
      if(movement < 0 && isFlip)
        {
            Flip();
            
        }
      else if (movement > 0 && !isFlip)
        {
            Flip();
            
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Plant();
        }

    }

    void Flip()
    {
        isFlip = !isFlip;
        transform.Rotate(0, 180, 0);
    }
    void Plant()
    {
        // Instantiate the plant prefab at the current position of the player
        Instantiate(plantPrefab, transform.position, Quaternion.identity);
        plantPrefab.SetActive(true);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("plant"))
        {
            time.remining = 10;
            int minutes = Mathf.FloorToInt(time.remining / 60);
            int seconds = Mathf.FloorToInt(time.remining % 60);
            time.timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

}
