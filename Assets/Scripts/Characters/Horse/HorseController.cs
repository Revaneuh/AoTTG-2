using UnityEngine;

public class HorseController : MonoBehaviour
{
    public Camera currentCamera;
    public float currentDirection;
    public FengCustomInputs inputManager;
    public bool isAttackDown;
    public bool isAttackIIDown;
    public bool isWALKDown;
    public bool sit;
    public float targetDirection;

    private void Start()
    {
        this.inputManager = GameObject.Find("InputManagerController").GetComponent<FengCustomInputs>();
        this.currentCamera = GameObject.Find("MainCamera").GetComponent<Camera>();
        if (IN_GAME_MAIN_CAMERA.gametype == GAMETYPE.SINGLE)
        {
            base.enabled = false;
        }
    }

    private void Update()
    {
        int num;
        int num2;
        float y;
        float num4;
        float num5;
        float num6;
        if (FengGameManagerMKII.inputRC.isInputHorse(InputCodeRC.horseForward))
        {
            num = 1;
        }
        else if (FengGameManagerMKII.inputRC.isInputHorse(InputCodeRC.horseBack))
        {
            num = -1;
        }
        else
        {
            num = 0;
        }
        if (FengGameManagerMKII.inputRC.isInputHorse(InputCodeRC.horseLeft))
        {
            num2 = -1;
        }
        else if (FengGameManagerMKII.inputRC.isInputHorse(InputCodeRC.horseRight))
        {
            num2 = 1;
        }
        else
        {
            num2 = 0;
        }
        if ((num2 != 0) || (num != 0))
        {
            y = this.currentCamera.transform.rotation.eulerAngles.y;
            num4 = Mathf.Atan2((float)num, (float)num2) * 57.29578f;
            num4 = -num4 + 90f;
            num5 = y + num4;
            this.targetDirection = num5;
        }
        else
        {
            this.targetDirection = -874f;
        }
        this.isAttackDown = false;
        this.isAttackIIDown = false;
        if (this.targetDirection != -874f)
        {
            this.currentDirection = this.targetDirection;
        }
        num6 = this.currentCamera.transform.rotation.eulerAngles.y - this.currentDirection;
        if (num6 >= 180f)
        {
            num6 -= 360f;
        }
        if (FengGameManagerMKII.inputRC.isInputHorse(InputCodeRC.horseJump))
        {
            this.isAttackDown = true;
        }
        this.isWALKDown = FengGameManagerMKII.inputRC.isInputHorse(InputCodeRC.horseWalk);
    }
}
