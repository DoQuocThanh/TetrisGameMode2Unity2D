using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowBlock : MonoBehaviour
{
    public static int width = 10;
    public static int height = 25;
    public static Transform BlockTrans;
    public static Transform[,] grid;
    public GameObject objectToDestroy;
    public static bool Refresh;

    public static Transform[,] gridShadow = new Transform[10, 25];

    void OnMouseDown()
    {
        if(!Refresh){
            BlockTrans = transform;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        try{

         grid = Block.grid;
         for(int i = 0; i < 20; i++) {
                transform.position += new Vector3(0,-1,0);    
                if(!ValidMove()){
                    transform.position -= new Vector3(0,-1,0);
                }

        }
        addToGridShadown();

        }catch(System.Exception){

            Destroy(gameObject);
        
        }
       
    }

    // Update is called once per frame
    void Update()
    {
         

      
            
        

    }
    
        void addToGridShadown(){
            foreach(Transform children in transform){
                int roundedX = Mathf.RoundToInt(children.transform.position.x);
                int roundedY = Mathf.RoundToInt(children.transform.position.y);
                
                gridShadow[roundedX,roundedY] = children;

            }

        }
        
         bool ValidMove(){
           
            foreach(Transform children in transform){
                int roundedX = Mathf.RoundToInt(children.transform.position.x);
                int roundedY = Mathf.RoundToInt(children.transform.position.y);
                

                if( roundedY < 0 ){
                    return false;

                }
                if(grid[roundedX,roundedY]!=null){
                    return false;

                }
                if(gridShadow[roundedX,roundedY] != null){
                    
                    foreach(Transform c in gameObject.transform){
                        gridShadow[Mathf.RoundToInt(c.transform.position.x),Mathf.RoundToInt(c.transform.position.y)]= null;
                    }
                    Destroy(gameObject);

                }
            }
            
            return true;
        }
}
