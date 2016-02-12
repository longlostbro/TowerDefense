using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManagerBehavior : MonoBehaviour {
    public GameObject prefab;
    public Text healthLabel;
    public GameObject[] healthIndicator;
    public Text waveLabel;
    public GameObject[] nextWaveLabels;
    public Text goldLabel;
    private int gold;
    public bool gameOver = false;
    private int wave;
    private int health;
    public int Health
    {
        get { return health; }
        set
        {
            // 1
            if (value < health)
            {
                Camera.main.GetComponent<CameraShake>().Shake();
            }
            // 2
            health = value;
            healthLabel.text = "HEALTH: " + health;
            // 3
            if (health <= 0 && !gameOver)
            {
                gameOver = true;
                GameObject gameOverText = GameObject.FindGameObjectWithTag("GameOver");
                gameOverText.GetComponent<Animator>().SetBool("gameOver", true);
            }
            // 4 
            for (int i = 0; i < healthIndicator.Length; i++)
            {
                if (i < Health)
                {
                    healthIndicator[i].SetActive(true);
                }
                else {
                    healthIndicator[i].SetActive(false);
                }
            }
        }
    }
    public int Wave
    {
        get { return wave; }
        set
        {
            wave = value;
            if (!gameOver)
            {
                for (int i = 0; i < nextWaveLabels.Length; i++)
                {
                    nextWaveLabels[i].GetComponent<Animator>().SetTrigger("nextWave");
                }
                waveLabel.text = "WAVE: " + (wave + 1);
            }
        }
    }
    public int Gold
    {
        get { return gold; }
        set
        {
            gold = value;
            goldLabel.GetComponent<Text>().text = "GOLD: " + gold;
        }
    }
    // Use this for initialization
    GameObject lastPointer;
    void Start () {
        Gold = 100000;
        Wave = 3;
        Health = 5;
        //float height = (float)600;
        //float width = 800;
        //for (int i = 0; i < height; i++)
        //{
        //    for(int k = 0; k < width; k++)
        //    {
        //        if(k%2 == 0 && i%2==0)
        //            Instantiate(buildLocation, transform.TransformPoint(k-width/2,i-height/2,0), Quaternion.identity);
        //    }
        //}
        //RectTransform objectRectTransform = gameObject.GetComponent<RectTransform>();                // This section gets the RectTransform information from this object. Height and width are stored in variables. The borders of the object are also defined
        //float width = objectRectTransform.rect.width;
        //float height = objectRectTransform.rect.height;
        //float rightOuterBorder = (width * .5f);
        //float leftOuterBorder = (width * -.5f);
        //float topOuterBorder = (height * .5f);
        //float bottomOuterBorder = (height * -.5f);
        //if (Input.mousePosition.x <= (transform.position.x + rightOuterBorder) && Input.mousePosition.x >= (transform.position.x + leftOuterBorder) && Input.mousePosition.y <= (transform.position.y + topOuterBorder) && Input.mousePosition.y >= (transform.position.y + bottomOuterBorder))
        //{
        //    //PerformRaycast();                                // Calls the function to perform a raycast

        //}
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 mousePos = Input.mousePosition;
        if (mousePos != null)
        {
            if (lastPointer != null)
                Destroy(lastPointer);
            mousePos.x = mousePos.x - mousePos.x % 40 + 15;
            mousePos.y = mousePos.y - mousePos.y % 40 + 15;
            Vector3 ObjectPos = Camera.main.ScreenToWorldPoint(mousePos);
            ObjectPos.z = 0;
            lastPointer = (GameObject)Instantiate(prefab, ObjectPos, Quaternion.identity);
        }
    }
}
