using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target, player;

    private Touch touch;
    private Quaternion rotationY;

    [SerializeField]
    private float rotationSpeedModifier = 0.1f;

    private void Update()
    {
        if (GameManager.gameOn)
        {
            if (Input.touchCount > 0)
            {
                touch = Input.GetTouch(0);

                if(touch.phase == TouchPhase.Moved)
                {
                    rotationY = Quaternion.Euler(0f, touch.deltaPosition.x * rotationSpeedModifier, 0f);

                    target.rotation = rotationY * target.transform.rotation;
                    player.rotation = rotationY * player.transform.rotation;
                }
            }
        }
    }
}
