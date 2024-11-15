using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] private float speed = 3f; // �������� ��������
    [SerializeField] private int lives = 5; // ���������� ������
    [SerializeField] private float jumpForce = 15f; // ���� ������
    private bool isGrounded = false; // ���� �� ����� ��� ������

    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    //�������� ������ �� rb � sprite
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetButton("Horizontal"))
            Run();
        if (isGrounded && Input.GetButtonDown("Jump"))
            Jump();
    }

    //���
    private void Run()
    {
        Vector3 dir = transform.right * Input.GetAxis("Horizontal"); //����������� �����

        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);

        sprite.flipX = dir.x < 0.0f; //������� ��� ����� �����������
    }

    //������
    private void Jump()
    {
        isGrounded = false;
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            isGrounded = true;
    }
}
