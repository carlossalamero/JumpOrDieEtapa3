using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    [SerializeField] private float parallaxMultiplier;
    private Transform cameraTransform;
    private Vector3 cameraPreviousPos;

    private float spriteWidth;
    private float startPos;
    // Start is called before the first frame update
    void Start()
    {
        
        cameraTransform = Camera.main.transform;
        cameraPreviousPos = cameraTransform.position;

        spriteWidth = GetComponent<SpriteRenderer>().bounds.size.x;
        startPos = transform.position.x;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        
        float x = (cameraTransform.position.x - cameraPreviousPos.x) * parallaxMultiplier;
        float spriteMoveAmount = cameraTransform.position.x * (1 - parallaxMultiplier);

        transform.Translate(new Vector3(x, 0f, 0f));
        cameraPreviousPos = cameraTransform.position;

        if(spriteMoveAmount > startPos + spriteWidth)
        {

            transform.Translate(new Vector3(spriteWidth, 0f, 0f));
            startPos += spriteWidth;

        }else if(spriteMoveAmount < startPos - spriteWidth)
        {

            transform.Translate(new Vector3(spriteWidth, 0f, 0f));
            startPos -= spriteWidth;

        }

    }
}
