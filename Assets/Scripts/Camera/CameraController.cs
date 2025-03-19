using System.Collections;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Transform _target;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void LateUpdate()
    {
        
    }

    public void ShakeCamera(float duration, float magnitude)
    {
        StartCoroutine(ShakeCameraCoroutine(duration, magnitude));
    }

    IEnumerator ShakeCameraCoroutine(float duration, float magnitude)
    {
        Vector3 originPos = transform.position;

        float elapsed = 0.0f;

        while(elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;
            transform.position = new Vector3(x, y, originPos.z);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.position = originPos;
    }
}
