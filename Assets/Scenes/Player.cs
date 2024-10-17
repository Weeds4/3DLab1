using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float m_speed = 10f;
    [SerializeField] float r_speed = 1.0f;
    [SerializeField] float smoothTime = 0.2f;
    private Vector3 velocity = Vector3.zero;
    [SerializeField] Transform cameraTransform;
    Animator _animator;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform bulletPoint;

    public MeshRenderer muzzleFlash;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        muzzleFlash.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        //transform.Translate((Vector3.forward * v) + (Vector3.right * h) * m_speed * Time.deltaTime);

        Vector2 inputVector = new Vector2(h, v);
        Vector2 mappedInput = SquareToCircle(inputVector);

        _animator.SetFloat("p_V", v * Mathf.Sqrt(1 - (h * h) / 2.0f));
        _animator.SetFloat("p_H", h * Mathf.Sqrt(1 - (v * v) / 2.0f));

        Vector3 moveDirection = transform.forward * v + transform.right * h;
        Vector3 targetPosition = transform.position + moveDirection * m_speed * Time.deltaTime;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

        float mouseX = Input.GetAxis("Mouse X") * r_speed;
        transform.Rotate(0f, mouseX, 0f);
        //bullet 발사
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(ShowEnable());
            Instantiate(bullet, bulletPoint.position, transform.rotation);
        }

    }
    Vector2 SquareToCircle(Vector2 input)
    {
        float x = input.x * Mathf.Sqrt(1 - (input.y * input.y) / 2.0f);
        float y = input.y * Mathf.Sqrt(1 - (input.x * input.x) / 2.0f);
        return new Vector2(x, y);
    }

    IEnumerator ShowEnable()
    {
        float scale = Random.Range(70.0f, 100.0f);
        muzzleFlash.transform.localScale = Vector3.one * scale;
        Quaternion rot = Quaternion.Euler(30.0f,0f, Random.Range(0f, 90.0f));
        muzzleFlash.enabled = true;
        yield return new WaitForSeconds(Random.Range(0.05f,0.2f));
        muzzleFlash.enabled = false;
    }
}
