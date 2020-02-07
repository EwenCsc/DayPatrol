using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;

public class ObstaclePin : MonoBehaviour, IDragHandler, IEndDragHandler
{
    [SerializeField] GameObject barrierPrefab;
    private Vector3 startingPos;

    bool m_HitDetect = false;

    void Start()
    {
        startingPos = transform.position;
    }

    void Update() { }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(pos.x, 10, pos.z);
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        RaycastHit hit;
        
        Physics.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.down * 500, out hit);
        Debug.DrawLine(Camera.main.ScreenToWorldPoint(Input.mousePosition), Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.down * 500, Color.red, 2.0f);

        //Vector3 size = new Vector3(1.5f, 500.0f, 1.5f);
        //Physics.BoxCast(Camera.main.ScreenToWorldPoint(Input.mousePosition), size, Vector3.down, out hit);

        // instanciate obstacle on obstacle slot if icon dropped on one
        if (hit.collider != null)
        {

            if (hit.collider.gameObject.GetComponent<Block>().GetType() == Block.TileType.Obstacle)
            {
                Instantiate(barrierPrefab, hit.collider.transform.position + Vector3.up * 0.5f, Quaternion.identity);
            }
        }
        else
        {
            Debug.Log("no hit");
        }
        
        // box cast
        /*Collider[] hitColliders = Physics.OverlapBox(Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.localScale / 2);
        List<GameObject> obstacleSlotsGO = new List<GameObject>();

        foreach (Collider col in hitColliders)
        {
            if (col.GetComponent<Block>().GetType() == Block.TileType.Obstacle)
            {
                obstacleSlotsGO.Add(col.gameObject);
            }
        }

        float dist = 999999.0f;

        foreach (GameObject go in obstacleSlotsGO)
        {
            if (go.transform.position)
        }*/

        //m_HitDetect = Physics.BoxCast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.one * 2, transform.forward * 500, out hit);
        if (m_HitDetect)
        {
            //Output the name of the Collider your Box hit
            Debug.Log("Hit : " + hit.collider.name);
            

            if (hit.collider.gameObject.GetComponent<Block>().GetType() == Block.TileType.Obstacle)
            {
                Instantiate(barrierPrefab, hit.collider.transform.position + Vector3.up * 0.5f, Quaternion.identity);
            }
        }
        else
        {
            Debug.Log("no hit");
        }

        // re-init obstacle icon position in tool box
        transform.position = startingPos;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        //Check if there has been a hit yet
        if (m_HitDetect)
        {
            //Draw a Ray forward from GameObject toward the hit
            Gizmos.DrawRay(transform.position, transform.forward * 500);

            //Draw a cube that extends to where the hit exists
            Gizmos.DrawWireCube(transform.position + transform.forward * 500, transform.localScale);
        }
    }
}
