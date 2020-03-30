using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(GameObject))]
public class CharacterCreatorManager : MonoBehaviour
{
    public GameObject player;

    public Material[] bodyMaterials;
    public Material[] hairMaterials;
    public Material[] shirtMaterials;
    public Material[] pantsMaterials;

    //variables for GameObjects handling player components
    private GameObject bodyGameObject;
    private GameObject hairGameObject;
    private GameObject shirtGameObject;
    private GameObject pantsGameObject;

    //curr hair or jobs
    int currBody = 0;
    int currHair = 0;
    int currJob = 0;

    // Start is called before the first frame update
    void Start()
    {
        bodyGameObject = player.transform.Find("Body").gameObject;
        hairGameObject = player.transform.Find("Hair").gameObject;
        shirtGameObject = player.transform.Find("Shirt").gameObject;
        pantsGameObject = player.transform.Find("Pants").gameObject;
    }

    //detect hair change
    public void ChangeHair ()
    {
        currHair++;

        if(currHair >= hairMaterials.Length)
        {
            currHair = 0;
        }

        int childCount = hairGameObject.transform.childCount;
        
        for(int i=0; i<childCount; i++)
        {
            GameObject child = hairGameObject.transform.GetChild(i).gameObject;
            child.GetComponent<Renderer>().material = hairMaterials[currHair];
        }
    }

    //detect body change
    public void ChangeBody()
    {
        currBody++;

        if (currBody >= bodyMaterials.Length)
        {
            currBody = 0;
        }

        bodyGameObject.GetComponent<Renderer>().material = bodyMaterials[currBody];
    }

    //detect job change
    public void ChangeJob()
    {
        currJob++;

        if (currJob >= pantsMaterials.Length || currJob >= shirtMaterials.Length)
        {
            currJob = 0;
        }

        shirtGameObject.GetComponent<Renderer>().material = shirtMaterials[currJob];
        pantsGameObject.GetComponent<Renderer>().material = pantsMaterials[currJob];
    }
}
