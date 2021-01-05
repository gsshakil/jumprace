using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerfectText : MonoBehaviour
{

    private void Update()
    {
        Invoke(nameof(Deactivate), 1f);
    }
    void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
