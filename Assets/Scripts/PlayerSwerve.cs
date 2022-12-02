using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwerve : MonoBehaviour
{
    [SerializeField] private float MaxSwerveAmount = 0.5f;
    [SerializeField] private float SwerveSpeed = 0.5f;
    private float LastFingerPosX;
    private float MoveFactorX;
    public float MoveFac => MoveFactorX;
    public float MaxX;
    public float MinX;
    public float MaxY;
    public float MinY;
    public float MaxZ;
    public float MinZ;
    public static PlayerSwerve Instance;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            LastFingerPosX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0))
        {
            MoveFactorX = Input.mousePosition.x - LastFingerPosX;
            LastFingerPosX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            MoveFactorX = 0f;
        }

        float swerveamount = SwerveSpeed * MoveFac * Time.deltaTime;
        swerveamount = Mathf.Clamp(value: swerveamount, min: -MaxSwerveAmount, max: MaxSwerveAmount);
        transform.Translate(swerveamount, 0, 0);
        float xPos = Mathf.Clamp(value: transform.position.x, min: MinX, max: MaxX);
        float yPos = Mathf.Clamp(transform.position.y, MinY, MaxY);
        float zPos = Mathf.Clamp(transform.position.z, MinZ, MaxZ);
        transform.position = new Vector3(xPos, yPos, zPos);
    }
}
