using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] AudioClip pickupSFX;
    [SerializeField] int pointsForCoinPickup = 100;

    bool wasCollected = false;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !wasCollected)
        {

            wasCollected = true;
            FindObjectOfType<GameSession>().addScore(pointsForCoinPickup);
            AudioSource.PlayClipAtPoint(pickupSFX, Camera.main.transform.position);
            gameObject.SetActive(false);
            Destroy(gameObject);
        }

    }

}
