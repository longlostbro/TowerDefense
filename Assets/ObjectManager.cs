using System.Collections.Generic;
using UnityEngine;

public class ObjectManager
{
    public Map _Map;
    public EventHandler _EventHandler;
    public static ObjectManager _ObjectManager;
    public List<EnemyBase> enemies = new List<EnemyBase>();
    public int gameSpeed = 1;

    public ObjectManager()
    {
        _Map = GameObject.Find("Map").GetComponent<Map>();
        _EventHandler = GameObject.Find("Map").GetComponent<_EventHandler>();
        _ObjectManager = this;
        _Map.nodeSize = new LinkedListNode[_Map.size_x, _Map.size_z];

        SetPositions();
        BuildNodes();
        ConnectNodes();
    }

    public static ObjectManager GetInstance()
    {
        if(_ObjectManager == null)
        {
            return new ObjectManager();
        }
        else
        {
            return _ObjectManager;
        }
    }

    private void SetPositions()
    {
        Vector3 midLeft = new Vector3(0, Screen.height / 2);
        Vector3 midRight = new Vector3(Screen.width, Screen.height / 2);

        midLeft = Camera.main.ScreenToWorldPoint(midLeft);
        midRight = Camera.main.ScreenToWorldPoint(midRight);

        _Map.left.transform.position = midLeft;
        _Map.right.transform.position = midRight;
    }

    private void BuildNodes()
    {
        float mapSizeX = _Map.right.position.x - _Map.left.position.x;
        float mapSizeZ = _Map.left.position.z - _Map.right.position.z;

        _Map.nodeSize = new Vector2(mapSizeX / _Map.size_x, mapSizeZ / _Map.size_z);
        float xPos;
        float zPos;
        for(int x=0; x<_Map.size_x; x++)
        {
            for(int z=0; z<_Map.size_z; z++)
            {
                xPos = _Map.left.position.x + x * _Map.nodeSize.x;
                zPos = _Map.right.position.z + (z + 1) * _Map.nodeSize.y;

                Vector3 position = new Vector3(xPos + _Map.nodeSize.x / 2, 0, zPos - _Map.nodeSize.y / 2);
                Vector3 listIndex = new Vector3(x, 0, z);

                _Map.nodes[x, z] = new LinkedListNode(true, true, position, listIndex;
                
                if(Camera.main.WorldToScreenPoint(_Map.nodeSize.Equals[x,z].unityPosition).y<=1 || Camera.main.WorldToScreenPoint(_Map.nodeSize[x,z].unityPosition).y >= Screen.height - Screen.height * .2))
                {
                    _Map.nodeSize[xPos, zPos].isWalkable = false;
                    _Map.nodeSize[xPos, zPos].isBuildable = false;
                }
            }
        }
    }
}