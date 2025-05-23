using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GroundManager : MonoBehaviour
{
    [Header("타일맵 설정")]
    public Tilemap tilemap; // 클릭을 감지할 타일맵
    public Grid grid; // 그리드 컴포넌트

    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;

        // 타일맵이나 그리드가 설정되지 않았다면 자동으로 찾기
        if (tilemap == null)
            tilemap = FindObjectOfType<Tilemap>();

        if (grid == null)
            grid = FindObjectOfType<Grid>();
    }

    void Update()
    {
        // 마우스 클릭 감지
        if (Input.GetMouseButtonDown(0))
        {
            DetectClickedCell();
        }
    }

    void DetectClickedCell()
    {
        // 마우스 위치를 월드 좌표로 변환
        Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0; // 2D에서는 Z값을 0으로 설정

        // 월드 좌표를 그리드 셀 좌표로 변환
        Vector3Int cellPosition = grid.WorldToCell(mouseWorldPos);

        // 타일맵을 사용한 셀 좌표 (참고용)
        Vector3Int tilemapCellPos = tilemap.WorldToCell(mouseWorldPos);

        // 셀을 다시 월드 좌표로 변환 (셀의 중심점)
        Vector3 cellWorldPos = grid.CellToWorld(cellPosition);

        // 1차원 인덱스 계산 (예시: 100x100 그리드라고 가정)
        int gridWidth = 100; // 그리드 너비 설정
        int index = (cellPosition.y * gridWidth) + cellPosition.x;

        // 결과 출력
        Debug.Log("=== 클릭 정보 ===");
        Debug.Log($"마우스 월드 좌표: {mouseWorldPos}");
        Debug.Log($"셀 좌표 (X, Y): ({cellPosition.x}, {cellPosition.y})");
        Debug.Log($"셀 월드 중심점: {cellWorldPos}");
        Debug.Log($"1차원 인덱스: {index}");
        Debug.Log($"타일맵 셀 좌표: {tilemapCellPos}");

        // 해당 위치에 타일이 있는지 확인
        TileBase tileAtPosition = tilemap.GetTile(cellPosition);
        if (tileAtPosition != null)
        {
            Debug.Log($"타일 존재: {tileAtPosition.name}");
        }
        else
        {
            Debug.Log("빈 셀입니다.");
        }
    }

    // 화면에 정보 표시 (디버그용)
    void OnGUI()
    {
        GUI.Box(new Rect(10, 10, 250, 80), "그리드 클릭 감지");
        GUI.Label(new Rect(20, 35, 230, 20), "마우스 클릭으로 셀 정보 확인");
        GUI.Label(new Rect(20, 55, 230, 20), "콘솔 창에서 상세 정보 확인");

        // 현재 마우스 위치의 셀 좌표 실시간 표시
        Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0;
        Vector3Int currentCell = grid.WorldToCell(mouseWorldPos);
        GUI.Label(new Rect(20, 75, 230, 20), $"현재 셀: ({currentCell.x}, {currentCell.y})");
    }
}
