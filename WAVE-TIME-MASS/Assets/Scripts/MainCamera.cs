using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public class MainCamera : MonoBehaviour
{
    [SerializeField] private Transform player;
    private Vector3 pos;

    private void Awake()
    {
        if (!player)
        {
            player = FindObjectOfType<Hero>().transform;
        }
    }
    private void Update()
    {
        pos = player.position;
        pos.z = -10f;

        transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime);
    }
}*/

public class MainCamera : MonoBehaviour
{
    public Transform player; // ������ �� ������ ������
    public Vector2 mapMinBounds; // ����������� ���������� �����
    public Vector2 mapMaxBounds; // ������������ ���������� �����
    public float smoothSpeed = 0.125f; // �������� ��������� ������

    private Camera cam; // ������ �� ��������� ������
    private float camHeight; // ������ ������� ������� ������
    private float camWidth;  // ������ ������� ������� ������

    void Start()
    {
        cam = GetComponent<Camera>();
        UpdateCameraSize();
    }

    void LateUpdate()
    {
        if (player == null)
            return;

        // �������� ������� ������
        Vector3 targetPosition = player.position;

        // ������������ �������� ������ � ������ � ��������
        targetPosition.x = Mathf.Clamp(targetPosition.x, mapMinBounds.x + camWidth, mapMaxBounds.x - camWidth);
        targetPosition.y = Mathf.Clamp(targetPosition.y, mapMinBounds.y + camHeight, mapMaxBounds.y - camHeight);

        // ��������� Z-���������� ������
        targetPosition.z = transform.position.z;

        // ������� �������� ������
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
    }

    void UpdateCameraSize()
    {
        // ������ �������� ������ � ���� �� ������ ���������������� �������
        camHeight = cam.orthographicSize;
        camWidth = cam.aspect * camHeight;
    }

    private void OnDrawGizmosSelected()
    {
        // ������������ ������ �����
        Gizmos.color = Color.green;
        Gizmos.DrawLine(new Vector3(mapMinBounds.x, mapMinBounds.y, 0), new Vector3(mapMinBounds.x, mapMaxBounds.y, 0));
        Gizmos.DrawLine(new Vector3(mapMaxBounds.x, mapMinBounds.y, 0), new Vector3(mapMaxBounds.x, mapMaxBounds.y, 0));
        Gizmos.DrawLine(new Vector3(mapMinBounds.x, mapMinBounds.y, 0), new Vector3(mapMaxBounds.x, mapMinBounds.y, 0));
        Gizmos.DrawLine(new Vector3(mapMinBounds.x, mapMaxBounds.y, 0), new Vector3(mapMaxBounds.x, mapMaxBounds.y, 0));
    }
}
