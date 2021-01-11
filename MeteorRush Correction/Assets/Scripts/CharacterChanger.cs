using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterChanger : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject prefabCharacter0;

    [SerializeField]
    GameObject prefabCharacter1;

    GameObject currentCharacter;
    // flag

    bool previousFrameChangeCharacterInput = false;

    void Start()
    {
        currentCharacter = Instantiate<GameObject>(prefabCharacter0,
            Vector3.zero, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        // change character on left mouse button
        if (Input.GetAxis("ChangeCharacter")>0)
        {
            if (!previousFrameChangeCharacterInput)
            {
                previousFrameChangeCharacterInput = true;
                // save current position and destroy current charactert
                Vector3 position = currentCharacter.transform.position;
                Destroy(currentCharacter);

                int prefabNumber = Random.Range(0, 2);
                if (prefabNumber == 0)
                {
                    currentCharacter = Instantiate(prefabCharacter0, position, Quaternion.identity);
                }
                else
                {
                    currentCharacter = Instantiate(prefabCharacter1, position, Quaternion.identity);
                }
            }
        }
        else
        {
            previousFrameChangeCharacterInput = false;
        }
    }
}
