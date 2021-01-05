using UnityEngine;

public class Platform : MonoBehaviour
{

    public GameObject CircleEffectPrefab;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject ce = Instantiate(CircleEffectPrefab, new Vector3(0, 1.1f, 0), Quaternion.identity);
            ce.gameObject.transform.SetParent(gameObject.transform);
        }
    }
}
