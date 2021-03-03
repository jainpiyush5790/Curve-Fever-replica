using System.Linq;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(EdgeCollider2D))]
public class Tail : MonoBehaviour
{

    // This variable shows how far between we want up our points to be and we with uniit
     public float pointSpacing = .1f;
    //Creating a resizable kind of array 
    //This will be the be two points that both our line render will follow its point.
    List<Vector2> points;
    LineRenderer line;
    EdgeCollider2D col;
    
    //creating a refrence to our game object
    public Transform snake;
    void Start()
    {
        //Now we have reference to our line
        line =GetComponent<LineRenderer>(); 
        col=GetComponent<EdgeCollider2D>();

        points=new List<Vector2>();
        SetPoint();
    }

    // Update is called once per frame
    void Update()
    {
        //Vector 3 is used to show the distance between the last point and our current position (and that is point spacing)
        if (Vector3.Distance(points.Last(), snake.position) >  pointSpacing)
        SetPoint();
    }

    // This is where X will actually access our line Renderer
    void SetPoint()
    {

        if(points.Count>1)  
        col.points=points/*now we have created a list and we will convert it into array*/.ToArray<Vector2>();  

        points.Add(transform.position);
      
        line.positionCount =points.Count;
        line.SetPosition(points.Count - 1,transform.position); 

        //now edge collider allows us to down here change some things about this collider 
        
        
    }

}
