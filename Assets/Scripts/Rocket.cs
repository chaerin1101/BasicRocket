using UnityEngine;
using UnityEngine.UI;

public class Rocket : MonoBehaviour
{
    private Rigidbody2D _rb2d;
    private float fuel = 100f;
    
    private readonly float SPEED = 5f;
    private readonly float FUELPERSHOOT = 10f;
    public Button shootButton;
    
    void Awake()
    {
        // TODO : Rigidbody2D 컴포넌트를 가져옴(캐싱) 
        _rb2d = GetComponent<Rigidbody2D>();
        // 인스펙터 창을 사용하지 않고 컴포넌트를 연결하기

        shootButton.onClick.AddListener(Shoot);
        // AddListner는 주로 UI에서 사용되는 메소드.
        // Button의 인스펙터 창에 On Click에서 +버튼을 누르면 None Object라고 뜨는 부분이 있음.
        // 거기에 스크립트가 연결된 GameObject(=Rocket)를 연결하기와 같은 기능.
        // AddListener와 인스펙터창에서 On Click 추가 둘 다 하면 중복적용됨.
    }
    
    public void Shoot()
    {
        // TODO : fuel이 넉넉하면 윗 방향으로 SPEED만큼의 힘으로 점프, 모자라면 무시
        if (fuel >= FUELPERSHOOT) // 연료가 10보다 크거나 같으면
        {
            _rb2d.AddForce(Vector2.up * SPEED, ForceMode2D.Impulse);
            // 힘을 가해준다(원하는 방향으로)
            // ForceMode2D.Impulse는 순간적으로 힘을 가해주는 메소드
            fuel -= FUELPERSHOOT; // 연료에서 10씩 빼서 넣어준다
            Debug.Log("현재 연료 : " + fuel);
        }
        else
        {
            Debug.Log("연료가 부족합니다");
        }
    }
}
