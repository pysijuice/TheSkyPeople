using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureDataRandomiser : MonoBehaviour
{
    

    public List <TextureData> biomes = new List<TextureData>();
    // TextureData[Random.Range(0,biomes.Count)]
    // void Start()
    // {
    //     Debug.Log(biomes[0]);
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }
    public TextureData giveTexture(){
        return biomes[Random.Range(0,biomes.Count)];
    }
    public void RandomBiome(){
        Debug.Log(biomes[Random.Range(0,biomes.Count)]);
    }
}
