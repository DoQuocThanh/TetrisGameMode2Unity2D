using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject[] B;
    public GameObject[] B_Shadow;
    public int[] Degrees; 
    public Vector3 rotationPosition;
    public static List<GameObject> ListBlock = new List<GameObject>();
    public static GameObject ShadowNow;
    public static Transform[,] gridShadow;
    // Start is called before the first frame update
    void Start()
    {
        New();
    }

    // Update is called once per frame
    void Update()
    {
        gridShadow = ShadowBlock.gridShadow;
        if (ListBlock == null){
            for(int i = 0; i <5 ; i++) {
            ListBlock.Add(Instantiate(ShadowNow,new Vector3(Random.Range(0,10),20,0), Quaternion.Euler(0, 0, Degrees[Random.Range(0,Degrees.Length)])));
        }
        }
    }

    public void New() {
        int Index = Random.Range(0,B.Length);
        
        GameObject Block = B[Index];
        ShadowNow = B_Shadow[Index];
        for(int i = 0; i <5 ; i++) {
            ListBlock.Add(Instantiate(ShadowNow,new Vector3(Random.Range(0,10),20,0), Quaternion.Euler(0, 0, Degrees[Random.Range(0,Degrees.Length)])));
        }
        
       
       
        Instantiate(Block,new Vector3(4,22,0), Quaternion.identity);

    }   
    void OnMouseDown()
    {
        foreach(GameObject obj in ListBlock) {
            if(obj != null){
                foreach(Transform c in obj.transform){
                gridShadow[Mathf.RoundToInt(c.transform.position.x),Mathf.RoundToInt(c.transform.position.y)]= null;
            }
            }
            Destroy(obj);

        }
        
            


        for(int i = 0; i <5 ; i++) {
            ListBlock.Add(Instantiate(ShadowNow,new Vector3(Random.Range(0,10),20,0), Quaternion.Euler(0, 0, Degrees[Random.Range(0,Degrees.Length)])));
        }
        
    }
}
