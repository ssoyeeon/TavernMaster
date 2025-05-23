using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GroundManager : MonoBehaviour
{
    [Header("Ÿ�ϸ� ����")]
    public Tilemap tilemap; // Ŭ���� ������ Ÿ�ϸ�
    public Grid grid; // �׸��� ������Ʈ

    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;

        // Ÿ�ϸ��̳� �׸��尡 �������� �ʾҴٸ� �ڵ����� ã��
        if (tilemap == null)
            tilemap = FindObjectOfType<Tilemap>();

        if (grid == null)
            grid = FindObjectOfType<Grid>();
    }

    void Update()
    {
        // ���콺 Ŭ�� ����
        if (Input.GetMouseButtonDown(0))
        {
            DetectClickedCell();
        }
    }

    void DetectClickedCell()
    {
        // ���콺 ��ġ�� ���� ��ǥ�� ��ȯ
        Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0; // 2D������ Z���� 0���� ����

        // ���� ��ǥ�� �׸��� �� ��ǥ�� ��ȯ
        Vector3Int cellPosition = grid.WorldToCell(mouseWorldPos);

        // Ÿ�ϸ��� ����� �� ��ǥ (�����)
        Vector3Int tilemapCellPos = tilemap.WorldToCell(mouseWorldPos);

        // ���� �ٽ� ���� ��ǥ�� ��ȯ (���� �߽���)
        Vector3 cellWorldPos = grid.CellToWorld(cellPosition);

        // 1���� �ε��� ��� (����: 100x100 �׸����� ����)
        int gridWidth = 100; // �׸��� �ʺ� ����
        int index = (cellPosition.y * gridWidth) + cellPosition.x;

        // ��� ���
        Debug.Log("=== Ŭ�� ���� ===");
        Debug.Log($"���콺 ���� ��ǥ: {mouseWorldPos}");
        Debug.Log($"�� ��ǥ (X, Y): ({cellPosition.x}, {cellPosition.y})");
        Debug.Log($"�� ���� �߽���: {cellWorldPos}");
        Debug.Log($"1���� �ε���: {index}");
        Debug.Log($"Ÿ�ϸ� �� ��ǥ: {tilemapCellPos}");

        // �ش� ��ġ�� Ÿ���� �ִ��� Ȯ��
        TileBase tileAtPosition = tilemap.GetTile(cellPosition);
        if (tileAtPosition != null)
        {
            Debug.Log($"Ÿ�� ����: {tileAtPosition.name}");
        }
        else
        {
            Debug.Log("�� ���Դϴ�.");
        }
    }

    // ȭ�鿡 ���� ǥ�� (����׿�)
    void OnGUI()
    {
        GUI.Box(new Rect(10, 10, 250, 80), "�׸��� Ŭ�� ����");
        GUI.Label(new Rect(20, 35, 230, 20), "���콺 Ŭ������ �� ���� Ȯ��");
        GUI.Label(new Rect(20, 55, 230, 20), "�ܼ� â���� �� ���� Ȯ��");

        // ���� ���콺 ��ġ�� �� ��ǥ �ǽð� ǥ��
        Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0;
        Vector3Int currentCell = grid.WorldToCell(mouseWorldPos);
        GUI.Label(new Rect(20, 75, 230, 20), $"���� ��: ({currentCell.x}, {currentCell.y})");
    }
}
