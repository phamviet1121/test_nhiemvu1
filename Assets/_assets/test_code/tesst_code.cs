using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tesst_code : MonoBehaviour
{
    // Biến lưu Transform của Camera và vị trí ban đầu của Camera
    Transform cam;
    Vector3 camStart;

    // Khoảng cách di chuyển của Camera
    float distance;
    float distance_y;
    // Mảng chứa các Material của các background (phông nền)
    Material[] mat;

    // Mảng chứa tốc độ di chuyển của từng background
    float[] backspeed;

    // Mảng chứa các đối tượng GameObject của các background
    GameObject[] backgroud;

    // Biến lưu vị trí xa nhất của background (dùng cho hiệu ứng Parallax)
    float farthestBack;

    // Tốc độ Parallax (di chuyển của background theo Camera)
    [Range(0.01f, 0.05f)] // Giới hạn tốc độ Parallax trong khoảng từ 0.01 đến 0.05
    public float parallaxspeed;

    void Start()
    {
        // Lấy Transform của Camera chính
        cam = Camera.main.transform;

        // Lưu lại vị trí bắt đầu của Camera
        camStart = cam.position;

        // Lấy số lượng đối tượng con (background) của đối tượng hiện tại
        int backcount = transform.childCount;

        // Khởi tạo các mảng Material và tốc độ tương ứng với số lượng background
        mat = new Material[backcount];
        backspeed = new float[backcount];

        // Khởi tạo mảng GameObject chứa các background
        backgroud = new GameObject[backcount]; // Sửa lỗi tạo mảng với kích thước

        // Lấy các đối tượng con (background) và Material của chúng
        for (int i = 0; i < backcount; i++)
        {
            backgroud[i] = transform.GetChild(i).gameObject;
            mat[i] = backgroud[i].GetComponent<Renderer>().material;
        }
        CalculateBackgroundSpeed(backcount);
    }

    // Hàm tính toán tốc độ di chuyển cho từng background
    void CalculateBackgroundSpeed(int backcount)
    {
        // Tìm background xa nhất dựa trên khoảng cách từ Camera đến background
        for (int i = 0; i < backcount; i++)
        {
            if ((backgroud[i].transform.position.z - cam.position.z) > farthestBack)
            {
                farthestBack = backgroud[i].transform.position.z - cam.position.z;
            }
        }

        // Tính tốc độ di chuyển cho từng background dựa trên khoảng cách so với background xa nhất
        for (int i = 0; i < backcount; i++)
        {
            backspeed[i] = 1 - (backgroud[i].transform.position.z - cam.position.z) / farthestBack;
        }
    }

    private void LateUpdate()
    {
        // Tính khoảng cách Camera di chuyển theo trục X kể từ vị trí bắt đầu
        distance = cam.position.x - camStart.x;
        distance_y = cam.position.y - camStart.y;
        // Cập nhật vị trí của đối tượng cha theo vị trí của Camera (chỉ thay đổi theo trục X)
        transform.position = new Vector3(cam.position.x, cam.position.y, 0);
       // transform.position = new Vector3(cam.position.x, transform.position.y, 0);
        // Duyệt qua từng background và cập nhật offset của texture để tạo hiệu ứng Parallax
        for (int i = 0; i < backgroud.Length; i++)
        {
            // Tốc độ dịch chuyển của từng background dựa trên khoảng cách và tốc độ Parallax
            float speed = backspeed[i] * parallaxspeed;

            // Cập nhật offset của texture trên Material để tạo hiệu ứng Parallax
            mat[i].SetTextureOffset("_MainTex", new Vector2(distance, distance_y) * speed);
            //mat[i].SetTextureOffset("_MainTex", new Vector2(distance, 0) * speed);
        }
    }
}

