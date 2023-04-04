using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Block : MonoBehaviour
{
    public static Transform BlockTrans;
    public static List<GameObject> ListBlock;
    public static int width = 10;
    public static int height = 25;
    public static Transform[,] grid = new Transform[10, 25];
    public float startTime = 0;
    
  

    // Start is called before the first frame update
    void Start()
    {
        ListBlock = Spawn.ListBlock;
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(ShadowBlock.BlockTrans != null){
            this.transform.position = ShadowBlock.BlockTrans.position;
            this.transform.rotation = ShadowBlock.BlockTrans.rotation;
            ShadowBlock.BlockTrans = null;

            foreach(GameObject obj in ListBlock) {
                Destroy(obj);
            }
            addToGrid();
            CheckForLine();
            FindObjectOfType<Spawn>().New();
            this.enabled = false;
        }else if(Time.time -  startTime >=5){
            for(int i = 0; i < 30; i++) {
                transform.position += new Vector3(0,-1,0);
                
                if(!ValidMove()){
                    transform.position -= new Vector3(0,-1,0);
                   
                }
            }
            foreach(GameObject obj in ListBlock) {
                Destroy(obj);
            }
            addToGrid();
            CheckForLine();
            FindObjectOfType<Spawn>().New();
            this.enabled = false;


        }
        void addToGrid(){
            foreach(Transform children in transform){
                int roundedX = Mathf.RoundToInt(children.transform.position.x);
                int roundedY = Mathf.RoundToInt(children.transform.position.y);
                if(roundedY > 20){
                    SceneManager.LoadScene("End");
                }
                grid[roundedX,roundedY] = children;

            }

        }

          void CheckForLine(){
            for(int i = height -1 ; i >= 0  ; i--) {
                if(HasLine(i)){
                    DeleteLine(i);
                    RowDown(i);
                }
            }

        }

        bool HasLine(int i){
            for(int j = 0; j < width ; j++) {
                    if(grid[j,i] == null)
                        return false;
            }
            return true;
        }

        void DeleteLine(int i){
            for(int j = 0; j < width ; j++) {
                    Destroy(grid[j,i].gameObject);
                    grid[j,i] = null; 
            }

           
        }

        void RowDown(int i){
            for(int y = i; y < height; y++) {
                for(int j = 0; j <  width; j++) {
                    if(grid[j,y] != null){
                        grid[j,y-1] = grid[j,y];
                        grid[j,y] = null;
                        grid[j,y-1].transform.position -= new Vector3(0,1,0);

                    }
                }
                
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
              
            }
            
            return true;
        }



    }
}
