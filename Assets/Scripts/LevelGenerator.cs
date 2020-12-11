
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    /*
        Variables públicas de nuestro generador de niveles
    */
    
    public static LevelGenerator sharedInstance; // instancia compartida para tener solo un generador de niveles
    public List<LevelBlock> allLevelBlocks = new List<LevelBlock>(); // Lista que contiene todos los niveles que se han creado
    public List<LevelBlock> currentLevelBlocks = new List<LevelBlock>(); // Lista de los bloques en pantalla
    public Transform levelInitialPoint; // Creación del primer nivel por el cual partir
    private bool isGeneratingInitialBlocks;
    void Awake() {
        sharedInstance = this;
        
 
        
    }
    void Start() {
        isGeneratingInitialBlocks = true;
        GenerateInitialBlocks();
        isGeneratingInitialBlocks = false;
    }

    public void AddNewBlock(){
        // Seleccionar un bloque aleatorio entre los que tenemos disponibles
        int randomIndex = Random.Range(0,allLevelBlocks.Count);
        if (isGeneratingInitialBlocks){
            randomIndex= 0;
        }
        LevelBlock block = (LevelBlock)Instantiate(allLevelBlocks[randomIndex]);
        block.transform.SetParent(this.transform, false);

        // Posición del bloque
        Vector3 blockPosition = Vector3.zero;
        if (currentLevelBlocks.Count == 0) {
            // Vamos a colocar el primer bloque en pantalla
            blockPosition = levelInitialPoint.position;
        }else{
            // Ya tengo bloques en pantalla, lo empalmo al ultimo disponible 
            blockPosition = currentLevelBlocks[currentLevelBlocks.Count-1].exitPoint.position;
        }
        block.transform.position = blockPosition;
        currentLevelBlocks.Add(block);
    }
    public void GenerateInitialBlocks(){
        for (int i=0; i<3;i++){
            AddNewBlock();
        }
    }
    public void RemoveOldBlock(){
        LevelBlock block = currentLevelBlocks[0];
        currentLevelBlocks.Remove(block);
        Destroy(block.gameObject);
    }
    public void RemoveAllBlocks(){
        while (currentLevelBlocks.Count >0){
            RemoveOldBlock();
        }

    }
}
