using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class ArmShooting : MonoBehaviour
{
    [SerializeField]
    private float startOffset;
    [SerializeField]
    private GameObject player;

    private bool isMove;
    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private Vector3 offsetPlayer;

    void Start()
    {
        player = GameManager.Instance.player;
        StartCoroutine(ShootStart());
    }

    private void Update()
    {
        if (isMove)
        {
            transform.position += transform.TransformDirection(Vector3.forward) * (Time.deltaTime * moveSpeed);
        }
    }

    IEnumerator ShootStart()
    {
        yield return new WaitForSeconds(startOffset);
        transform.DOLookAt(player.transform.position + offsetPlayer, 0.3f);
        yield return new WaitForSeconds(0.3f);
        isMove = true;
        Destroy(gameObject, 20f);
    }
}
