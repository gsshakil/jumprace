using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour
{

    public GameObject WaterSplashEffect;

    public GameObject playerBody;

    private GameManager gm;


    private void Awake()
    {
        gm = GameObject.FindObjectOfType<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Instantiate(WaterSplashEffect, other.gameObject.transform.position, Quaternion.Euler(90,0,0));
            playerBody.GetComponent<SkinnedMeshRenderer>().enabled = false;
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            GameManager.gameOn = false;
            Invoke(nameof(ShowLevelFailedMenu), 1f);
        }
    }

    void ShowLevelFailedMenu()
    {
        gm.ShowLevelFailedMenu();
    }
}
