using UnityEngine;

public class PerfectJump : MonoBehaviour
{
    public GameObject perfectEffectPrefab;
    public GameManager gm;


    private void Awake()
    {
        gm = GameObject.FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Instantiate(perfectEffectPrefab, transform.position, Quaternion.identity);
            gm.ShowPerfecttext();
            Destroy(gameObject);
        }
    }
}
