using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScript : MonoBehaviour
{
    public ParticleSystem winPrefab;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            winPrefab.gameObject.SetActive(true);
            collision.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            GameManager.gameOn = false;
        }
    }
}
