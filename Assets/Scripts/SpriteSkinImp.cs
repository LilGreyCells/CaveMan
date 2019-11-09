using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSkinImp : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite s;
    void Start()
    {
        StartCoroutine(animateScene());
    }

    public IEnumerator animateScene()
    {
    

        yield return new WaitForSeconds(6);
        GetComponent<SpriteRenderer>().sprite = s;
   


    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
