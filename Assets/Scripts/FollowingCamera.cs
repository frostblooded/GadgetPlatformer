using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingCamera : MonoBehaviour
{
    public Transform target;

    // We want the camera to vertically follow the player only if he is near
    // the top or bottom of the screen. So we designate some portion of the screen
    // that is near the bottom and some portion of the screen that is near the top
    // which when the player enters in, we should move the camera.
    private int m_heightPortion;
    private bool m_isMovingCamera;

    private void Start()
    {
        m_heightPortion = Screen.height / 3;
    }

    private void Update()
    {
        transform.position = new Vector3(target.position.x, transform.position.y, transform.position.z);

        Vector3 targetScreenPosition = Camera.main.WorldToScreenPoint(target.position);

        if((targetScreenPosition.y <= m_heightPortion || targetScreenPosition.y >= Screen.height - m_heightPortion)
            && !m_isMovingCamera)
        {
            StartCoroutine(MoveToTargetY());
            m_isMovingCamera = true;
        }
    }

    private IEnumerator MoveToTargetY()
    {
        float startY = transform.position.y;
        const float durationSeconds = 1;

        for(float t = 0; t < durationSeconds; t += Time.deltaTime)
        {
            transform.position = new Vector3(transform.position.x, Mathf.Lerp(startY, target.position.y, t), transform.position.z);
            yield return null;
        }

        m_isMovingCamera = false;
    }
}
