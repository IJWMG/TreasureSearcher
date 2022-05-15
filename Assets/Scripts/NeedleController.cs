using UnityEngine;

public class NeedleController : MonoBehaviour
{
    
    public GameObject needle;
    public float speedNeedle = 0.3f;
    public float downSpeedNeedle = -0.05f;
    private bool needleIsDown = false;
    private Vector2 positionOnStart, needlePosition;
    private Vector3 currentPointPosition;
    [SerializeField] private PointCreator creator;
    private void Start() {
        positionOnStart = needle.transform.position;
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            MakeNeedleGoDown();
        }
        if (Input.GetAxis("Horizontal") != 0 &&  needle.transform.position.y > 3.6f){
            needlePosition = needle.transform.position;
            if (needlePosition.x > 8.46f){
                needle.transform.position = new Vector2 (8.46f, needlePosition.y);
                }
            else if (needlePosition.x < -8.46f){
                needle.transform.position = new Vector2 (-8.46f, needlePosition.y);
                }
            else
                needle.transform.Translate(new Vector2 ((speedNeedle * Input.GetAxis("Horizontal")), 0));
            }
        if (needleIsDown){
            
            needle.transform.Translate(new Vector2 (0, downSpeedNeedle));
            //Debug.Log("we are going Down");
        }
        
        if (positionOnStart.y < 3.6f){
            needle.transform.position = new Vector2(needle.transform.position.x, 3.68f);
        }
        if (Input.touchCount == 1){
            needle.transform.position = new Vector2 (Input.GetTouch(0).position.x, needle.transform.position.y);
            MakeNeedleGoDown();
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        
        needleIsDown = false;
        RaycastHit2D hit = Physics2D.Raycast(needle.transform.position, Vector2.down);
        currentPointPosition = new Vector3 (hit.point.x, hit.point.y, 0);
        creator.CreatePoint(currentPointPosition);
        needle.transform.position = positionOnStart;
        if (PlayerPrefs.GetInt("Sound") == 0){
            GetComponent<AudioSource>().Play();
            }
        Debug.Log ("colision!");
        
    }
   private void OnTriggerEnter2D(Collider2D other) {
       needleIsDown = false;
       needle.transform.position = positionOnStart;
       Debug.Log ("miss!");
   }
    private void MakeNeedleGoDown (){
        needleIsDown = true;
        positionOnStart = needle.transform.position;

    }
}
