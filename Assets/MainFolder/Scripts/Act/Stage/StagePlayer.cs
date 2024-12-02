using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class StagePlayer : MonoBehaviour
{
    [SerializeField]
    private float playerMoveSpeed;

    [SerializeField]
    private float playerRunSpeed;

    private Rigidbody playerRb;

    [SerializeField]
    private Vector3 playerRotationOffset;

    [SerializeField]
    private Vector3 camRotationOffset;

    [Header("Rotate")]
    [SerializeField]
    private float mouseSpeed;
    float yRotation;
    float xRotation;

    [SerializeField]
    private GameObject cam;

    [SerializeField]
    private GameObject cutCam;

    private Animator anim;
    private float animBlend;

    private bool isCanMove;
    private bool isAttack;
    private bool isRunning;

    private int attackData;

    [SerializeField]
    private float moveTurn;
    [SerializeField]
    private float runTurn;

    [SerializeField]
    private Image knifeImg;
    [SerializeField]
    private Image knifePImg;

    [SerializeField]
    private CanvasGroup canvasA;

    [SerializeField]
    private Slider stamina;
    [SerializeField]
    private TextMeshProUGUI name;

    private void Start()
    {
        if (PlayerPrefs.GetString("NickName") == null) name.text = "niccolo paganini";
        else name.text = PlayerPrefs.GetString("NickName");
        stamina.value = stamina.maxValue;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        playerRb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

        playerRb.freezeRotation = true;

        StartCoroutine(CutSceneInit());
    }

    private void Update()
    {
        playerRb.velocity = new Vector3(0, -19.6f, 0);

        if (Input.GetKeyDown(KeyCode.LeftShift)) isRunning = true;
        if (Input.GetKeyUp(KeyCode.LeftShift)) isRunning = false;

        if (isRunning) stamina.value -= Time.deltaTime;
        else stamina.value += Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.Return) && cutCam.gameObject.activeSelf)
        {
            StopCoroutine(CutSceneInit());
            cutCam.gameObject.SetActive(false);
            isCanMove = true;
            canvasA.DOFade(1, 1);
        }

        if (isCanMove)
        {
            if (!isAttack)
            {
                Move();
                Attack();
            }
            anim.SetFloat("Blend", animBlend);
            CamMove();
        }

    }

    private void Attack()
    {
        if (Input.GetMouseButtonDown(0) && !isAttack)
        {
            isAttack = true;
            attackData = 1;
            anim.SetBool("isAttack", true);
            anim.SetBool("isPAttack", false);
            Invoke("InitAnimation", 0.3f);
            knifeImg.fillAmount = 0;
            DOTween.To(() => knifeImg.fillAmount, np => knifeImg.fillAmount = np, 1,2);
        }
        else if (Input.GetMouseButtonDown(1) && !isAttack)
        {
            isAttack = true;
            attackData = 2;
            anim.SetBool("isAttack", false);
            anim.SetBool("isPAttack", true);
            Invoke("InitAnimation", 0.3f);

            knifePImg.fillAmount = 0;
            DOTween.To(() => knifePImg.fillAmount, p => knifePImg.fillAmount = p, 1, 2);
        }
    }

    private void Move()
    {
        float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");

        Vector3 viewDir = (transform.TransformDirection(Vector3.forward) * v) + (transform.TransformDirection(Vector3.right) * h);


        if (Input.GetKey(KeyCode.LeftShift) && !(v == 0 && h == 0) && !(stamina.value <= 0))
        {
            Vector3 moveDir = viewDir.normalized * playerRunSpeed;
            DOTween.To(() => animBlend, x => animBlend = x, 1f, 0.3f);
            playerRb.MovePosition(playerRb.position + (moveDir) * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(viewDir), Time.deltaTime * runTurn);
        }
        else if(v == 0 && h == 0)
        {
            DOTween.To(() => animBlend, x => animBlend = x, 0f, 0.3f);
        }
        else
        {
            Vector3 moveDir = viewDir.normalized * playerMoveSpeed;
            DOTween.To(() => animBlend, x => animBlend = x, 0.5f, 0.3f);
            playerRb.MovePosition(playerRb.position + (moveDir) * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(viewDir), Time.deltaTime * moveTurn);
        }
    }

    private void CamMove()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * mouseSpeed * Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * mouseSpeed * Time.deltaTime;

        yRotation += mouseX;
        xRotation -= mouseY;

        cam.transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
    }

    private void InitAnimation()
    {
        anim.SetBool("isAttack", false);
        anim.SetBool("isPAttack", false);
    }

    IEnumerator CutSceneInit()
    {
        yield return new WaitForSeconds(11.5f);
        cutCam.gameObject.SetActive(false);
        isCanMove = true;
        canvasA.DOFade(1, 1);
    }

    public void OffIsAttack()
    {
        isAttack = false;
        attackData = 0;
    }
    
    public int ReturnAttackData()
    {
        return attackData;
    }


}
