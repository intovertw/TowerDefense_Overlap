using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    Vector3 startPos, endPos, tempPos;
    float time;
    bool go;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        time = 5f;
        go = true;

        startPos = transform.position;
        endPos = new Vector3(transform.position.x - 16, transform.position.y, transform.position.z);
    }

    void Update(){
        if(go){
            StartCoroutine(MoveGoons());
            go = false;
        }
            
    }

    IEnumerator MoveGoons(){
        
        float timeElapsed = 0f;

        while (timeElapsed < time){
            float t = timeElapsed / time;

            transform.position = Vector3.Lerp(startPos, endPos, t);
            timeElapsed += Time.fixedDeltaTime;
            yield return null;
        }
        
        transform.position = endPos;
        tempPos = endPos;
        endPos = startPos;
        startPos = tempPos;

        go = true;
    }
}
