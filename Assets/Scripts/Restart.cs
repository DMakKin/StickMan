using UnityEngine;

public class Restart : MonoBehaviour
{    
    [SerializeField] private GameObject prefab;
    [SerializeField] private Vector2 offset;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
        SetPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        RestartPlayer();
    }

    private void RestartPlayer()
    {
        if (Input.GetButtonDown("Replay"))
        {    
            Destroy(player);
            SetPlayer();
        }
    }

    private void SetPlayer()
    {        
        player = Instantiate(prefab);
        player.transform.position = new Vector2(transform.position.x + offset.x, transform.position.y + offset.y);        
    }
}
