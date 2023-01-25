using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Collider col;
    public ParticleSystem pickupParticles;
    public ParticleSystem spawnParticles;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Movement>().score ++;
            other.gameObject.GetComponent<Movement>().timeLeft += 2;

            pickupParticles.gameObject.transform.position = gameObject.transform.position;
            pickupParticles.Play();

            gameObject.SetActive(false);
            Invoke("Spawn", .25f);
        }
    }

    public void Spawn()
    {
        float randomFloatX = Random.Range(col.bounds.min.x + 1, col.bounds.max.x - 1);
        float randomFloatZ = Random.Range(col.bounds.min.z + 1, col.bounds.max.z - 1);

        gameObject.transform.position = new Vector3(randomFloatX, col.bounds.max.y + 1, randomFloatZ);

        spawnParticles.gameObject.transform.position = gameObject.transform.position;
        spawnParticles.Play();

        gameObject.SetActive(true);
    }
}
