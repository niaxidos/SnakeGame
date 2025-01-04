using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private Vector2 _direction;
    private List<Transform> _segments;
    public Transform segmentPrefab;
    public int growthFactor;
    private int score = 0;
    private int highscore = 0;
    public GameOverScreen GameOverScreen;

    private void Start(){
        GameOverScreen.gameObject.SetActive(false);
        _segments = new List<Transform>();
        _segments.Add(this.transform);
    }

    private void Update()
    {
        // used WASD for movement
   
        if(_segments.Count==1){
            if(Input.GetKeyDown(KeyCode.W)){
            _direction = Vector2.up;
        }
            else if(Input.GetKeyDown(KeyCode.A)){
            _direction = Vector2.left;
        }
            else if(Input.GetKeyDown(KeyCode.S)){
            _direction = Vector2.down;
        }
            else if(Input.GetKeyDown(KeyCode.D)){
            _direction = Vector2.right;
        }

        }
        else{
            if(Input.GetKeyDown(KeyCode.W) && _direction != Vector2.down){
            _direction = Vector2.up;
        }
            else if(Input.GetKeyDown(KeyCode.A) && _direction != Vector2.right){
            _direction = Vector2.left;
        }
            else if(Input.GetKeyDown(KeyCode.S) && _direction != Vector2.up){
            _direction = Vector2.down;
        }
            else if(Input.GetKeyDown(KeyCode.D) && _direction != Vector2.left){
            _direction = Vector2.right;
        }

        }
    }

    // physics are handled in fixed update
    private void FixedUpdate()
    {
        if(score>highscore){
            highscore = score;
        }

        for(int i = _segments.Count - 1; i > 0; i--){
            _segments[i].position = _segments[i-1].position;
        }
        // add head and its movement
        this.transform.position = new Vector3(
            Mathf.Round(this.transform.position.x)  + _direction.x, 
            Mathf.Round(this.transform.position.y) + _direction.y, 0.0f);
    }

    private void Grow(){
        score++;
        for(int i = 1; i < growthFactor; i++){
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = _segments[_segments.Count-1].position;
        _segments.Add(segment);
        }
    }

    public void ResetState()
    {
        GameOverScreen.gameObject.SetActive(false);
        for(int i = 1; i < _segments.Count; i++){
            Destroy(_segments[i].gameObject);
        }

        score = 0;
        _segments.Clear();
        _segments.Add(this.transform);
        this.transform.position = Vector3.zero;
    }

    // detects collision with snake
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Food"){
            Grow();
        }
        else if(other.tag == "Obstacle"){
            GameOverScreen.Setup(score, highscore);
            _direction = new Vector2(0,0);
        }
    }
}

