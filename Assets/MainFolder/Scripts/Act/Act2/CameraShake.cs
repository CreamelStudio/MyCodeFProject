using System.Collections;
using UnityEngine;

public class CamShake : MonoBehaviour
{
    [SerializeField]
    private float m_roughness;      //거칠기 정도
    [SerializeField]
    private float m_magnitude;      //움직임 범위

    [SerializeField]
    private float shakeTime;

    [SerializeField]
    private Vector3 offset;

    [SerializeField]
    private bool isCanShake;

    public void Start()
    {
        StartCoroutine(Shake(shakeTime));
        isCanShake = true;
    }

    IEnumerator Shake(float duration)
    {
        if (isCanShake)
        {
            float halfDuration = duration / 2;
            float elapsed = 0f;
            float tick = Random.Range(-10f, 10f);

            while (elapsed < duration)
            {
                elapsed += Time.deltaTime / halfDuration;

                tick += Time.deltaTime * m_roughness;
                transform.position = (new Vector3(
                    Mathf.PerlinNoise(tick, 0) - .5f,
                    Mathf.PerlinNoise(0, tick) - .5f,
                    0f) * m_magnitude * Mathf.PingPong(elapsed, halfDuration)) + offset;

                yield return null;
            }
        }
        
    }

    public void SwitchIsCanShake() => isCanShake = !isCanShake;
}