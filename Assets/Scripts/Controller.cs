using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    public float ScrollSpeed = 1f;
    private Camera _camera;
    private Vector3 origin;
    private Vector3 difference;
    private Vector3 resetCamera;
    public Player mainPlayer;
    public LayerMask mask;
    public GameObject scrollView;
    public GameObject buildingsGrid;
    public BuildingUI buildingPrefab;
    public GameObject leftPanel;
    public Village activeVillage;

    private bool drag = false;

    void Start()
    {
        _camera = Camera.main;
        resetCamera = _camera.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float newZoom = _camera.orthographicSize - Input.GetAxis("Mouse ScrollWheel") * ScrollSpeed;
        if (newZoom < 10f && newZoom > 1.5f)
        {
            _camera.orthographicSize = newZoom;
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return;
            HexCell touched = HandleInput();
            if (touched != null)
            {
                


                if (Input.GetKey(KeyCode.LeftControl))
                {
                    if (!touched.isVillage)
                        touched.CreateVillage(mainPlayer);
                }
                else
                {
                    if (touched.isVillage)
                    {
                        if (activeVillage != null)
                        {
                            activeVillage.isActive = false;
                        }
                        activeVillage = touched.village;
                        activeVillage.isActive = true;
                        OpenMenu(touched);
                    }

                }

            }
            else Debug.Log("Click à coté");
        }
    }

    private void OpenMenu(HexCell cell)
    {
        foreach (Transform child in buildingsGrid.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        Village infos = cell.village;
        infos.RefreshGUI();
        if (infos.owner == mainPlayer)
        {
            foreach (var building in infos.buildings)
            {
                BuildingUI buildingUI = Instantiate<BuildingUI>(buildingPrefab);
                buildingUI.Init(building, infos);
                buildingUI.transform.SetParent(buildingsGrid.transform);

            }
        }
        leftPanel.SetActive(true);

    }

    private void LateUpdate()
    {

        if (Input.GetMouseButton(2))
        {
            difference = (Camera.main.ScreenToWorldPoint(Input.mousePosition)) - _camera.transform.position;
            if (drag == false)
            {
                drag = true;
                origin = _camera.ScreenToWorldPoint(Input.mousePosition);

            }
        }
        else
        {
            drag = false;
        }
        if (drag)
        {
            _camera.transform.position = origin - difference;
        }
        if (Input.GetMouseButton(1))
            _camera.transform.position = resetCamera;
    }
    HexCell HandleInput()
    {

        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, mask);

        if (hit.collider != null)
        {
            HexCoordinates coordinates = HexCoordinates.FromPosition(hit.point);
            HexCoordinates posInTab = HexCoordinates.InTab(coordinates);
            HexCell touched = HexGrid.instance.Map[posInTab.R][posInTab.Q];
            Debug.Log("touched at " + coordinates.ToString());
            return touched;
        }
        else return null;
    }

    public void CloseMenu()
    {
        leftPanel.SetActive(false);
    }
}
