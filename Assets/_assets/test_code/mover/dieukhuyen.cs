using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dieukhuyen : MonoBehaviour
{
    public Transform player; // Biến đại diện cho đối tượng player
    public float speed = 5f; // Tốc độ di chuyển của player
    private bool touchStart = false; // Xác định trạng thái chạm
    private Vector2 pointA; // Điểm bắt đầu khi chạm vào màn hình
    private Vector2 pointB; // Điểm hiện tại khi kéo chuột hoặc ngón tay

    public Transform circle;       // Vòng tròn bên trong
    public Transform outercircle;  // Vòng tròn bên ngoài

    // Start is called before the first frame update
    void Start()
    {
        // Khởi tạo các đối tượng và tắt hiển thị ban đầu
        circle.GetComponent<SpriteRenderer>().enabled = false;
        outercircle.GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Phát hiện lúc bắt đầu chạm vào màn hình
        if (Input.GetMouseButtonDown(0))
        {
            // Lấy vị trí con trỏ chuột hoặc điểm chạm vào màn hình (screen space)
            pointA = Input.mousePosition;
            pointB = Input.mousePosition;

            // Chuyển đổi tọa độ màn hình thành tọa độ cho UI (canvas 2D)
            circle.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(pointA.x, pointA.y, Camera.main.nearClipPlane));
            outercircle.transform.position = circle.transform.position;

            // Hiển thị các vòng tròn
            circle.GetComponent<SpriteRenderer>().enabled = true;
            outercircle.GetComponent<SpriteRenderer>().enabled = true;
        }

        // Xác định khi người dùng đang kéo chuột hoặc chạm vào màn hình
        if (Input.GetMouseButton(0))
        {
            touchStart = true;
            pointB = Input.mousePosition;
        }
        else
        {
            touchStart = false;
        }
    }

    // FixedUpdate được gọi liên tục với khoảng thời gian cố định
    private void FixedUpdate()
    {
        if (touchStart)
        {
            // Tính toán khoảng cách giữa điểm A và B
            Vector2 offset = pointB - pointA;
            Vector2 d = Vector2.ClampMagnitude(offset, 100f); // Điều chỉnh độ nhạy

            // Di chuyển nhân vật theo hướng kéo
            movercharecter(d.normalized);

            // Cập nhật vị trí của vòng tròn nhỏ để theo dõi vị trí kéo
            circle.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(pointA.x + d.x, pointA.y + d.y, Camera.main.nearClipPlane));
        }
        else
        {
            // Tắt hiển thị các vòng tròn khi không chạm vào màn hình
            circle.GetComponent<SpriteRenderer>().enabled = false;
            outercircle.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    // Hàm di chuyển player theo hướng được chỉ định
    void movercharecter(Vector2 d)
    {
        player.Translate(d * speed * Time.deltaTime); // Sử dụng Translate để di chuyển
    }
}
