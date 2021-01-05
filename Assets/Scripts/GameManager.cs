using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool gameOn = true;

    public GameObject LevelCompleteMenu;
    public GameObject LevelFailedeMenu;
    public GameObject perfectText;

    public GameObject[] platforms;
    public int numberOfPlatforms;

    public float xOffset = 5f;
    public float yOffset = 1f;
    public float zOffset = 5f;
    public float wideAngle = 10f;


    private void Start()
    {
        SpiralFormation();
    }


    void SpiralFormation()
    {
        Vector3 targetPosition = Vector3.zero;

        GameObject container = new GameObject("Container");
        container.transform.position = Vector3.zero;

        for(int i=0; i< numberOfPlatforms; i++)
        {
            
            GameObject instance = Instantiate(platforms[Random.Range(0, platforms.Length)]);
            float angle = i * (2 * 3.1459f / wideAngle);
            float x = Mathf.Cos(angle) * xOffset;
            float z = Mathf.Sin(angle) * zOffset;

            targetPosition = new Vector3(targetPosition.x + x, targetPosition.y + yOffset, targetPosition.z + z);

            instance.transform.position = targetPosition;

            instance.transform.SetParent(container.transform);
        }
    }

    public void ShowLevelCompleteMenu() 
    {
        LevelCompleteMenu.SetActive(true);
    }

    public void ShowLevelFailedMenu()
    {
        LevelFailedeMenu.SetActive(true);
    }

    public void ShowPerfecttext()
    {
        perfectText.SetActive(true);
    }

    public void RestartLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
