using UnityEngine;
using System.Collections;

public class Map : MonoBehaviour {
    public GameObject SpiritBear;
    public GameObject StandardTurret;
    public Transform left;
    public Transform right;
    public Transform enemySpawnTransform;
    public Transform destinationTransform;

    //public Node destinationNode;
    //public Node enemySpawnNode;

    public int size_x;
    public int size_z;
    public Vector2 nodeSize;

    //public Node[,] nodes;

    public Texture gridTexture;

    private ObjectManager _ObjectManager;
	void Start () {
        _ObjectManager = ObjectManager.GetInstance();
        destinationNode = GetNodeFromLocation(destinationTransform.position);
        enemySpawnNode = GetNodeFromLocation(enemySpawnTransform.position);

        CreateEnemies();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
