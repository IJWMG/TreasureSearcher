using UnityEngine;

public class NeedleController : MonoBehaviour
{
    
    public float speedNeedle = 0.1f;
    public float downSpeedNeedle = -0.4f;
    private bool needleIsDown = false;
    private Vector2 positionOnStart, needlePosition;
    private Vector2 currentPointPosition;
    [SerializeField] private PointCreator creator;
    private float direction;
    private float force;
    private void Start() {
        positionOnStart = transform.position;
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            MakeNeedleGoDown();
        }
        if ((Input.GetAxis("Horizontal") != 0 || direction != 0) &&  transform.position.y > 3.6f){
            needlePosition = transform.position;
            if (needlePosition.x > 8.46f){
                transform.position = new Vector2 (8.46f, needlePosition.y);
                }
            else if (needlePosition.x < -8.46f){
                transform.position = new Vector2 (-8.46f, needlePosition.y);
                }
            else{
                force = direction + Input.GetAxis("Horizontal");
                transform.Translate(new Vector2 ((speedNeedle * force), 0));

            }
        }

        if (needleIsDown){
            
            transform.Translate(new Vector2 (0, downSpeedNeedle));
            //Debug.Log("we are going Down");
        }
        if (direction != 0){
            Debug.Log("fly to the high");
        }
        
        if (positionOnStart.y < 3.6f){
            transform.position = new Vector2(transform.position.x, 3.68f);
        }
      /*  if (Input.touchCount == 1){
            transform.position = new Vector2 (Input.GetTouch(0).position.x, transform.position.y);
            MakeNeedleGoDown();
        }
    */
    }
    private void OnCollisionEnter2D(Collision2D other) {
        
        needleIsDown = false;
        creator.CreatePoint(currentPointPosition);
        transform.position = positionOnStart;
        if (PlayerPrefs.GetInt("Sound") == 0){
            GetComponent<AudioSource>().Play();
            }
        Debug.Log ("colision!");
        
    }
   private void OnTriggerEnter2D(Collider2D other) {
       needleIsDown = false;
       transform.position = positionOnStart;
       Debug.Log ("miss!");
   }
    public void MakeNeedleGoDown (){
        needleIsDown = true;
        positionOnStart = transform.position;
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y -1f), Vector2.down);
        currentPointPosition = new Vector2 (hit.point.x, hit.point.y);
    }
        public void OnLeftButtonDown(){
        direction = -1;
        Debug.Log("left");
        
    }
      public void OnRightButtonDown(){
        direction = 1;
                Debug.Log("right");

    }
    public void OnButtonUp(){
        direction = 0;
                Debug.Log("thats all");

    }

}
