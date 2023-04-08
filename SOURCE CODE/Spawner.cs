using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using System.Collections;

public class Spawner : MonoBehaviour
{
    // List of towers (prefabs) that will instantiate 
    public List<GameObject> towersPrefabs;
    public Transform spawnTowerRoot;
    
    // List of towers (UI)
    public List<Image> towersUI;

    // List of cooldown panels
    public List<GameObject> cooldownPanels;
    // list of spawned towers 
    // id of tower spawned
    public int spawnID = -1;

    // spawnpoints tile maps
    public Tilemap spawnTilemaps;
    [HideInInspector] public bool gameStart = false; 

    // get called every frame
    void Update()
    {
        if (Time.timeScale == 1)
        {
            towerAvailable();
        }

        if (Time.timeScale == 0 && gameStart != true)
        {
            foreach (Image towers in towersUI)
            {
                towers.color = Color.white;
            }
        }
        if (canSpawn())
        {
            DetectSpawnPoint();
        }
    }
    // if spawnID == 1 meaning no selected towers and returns false as a bool otherwise true
    bool canSpawn()
    {
        if (spawnID == -1)
            return false;
        else
            return true;

    }
    bool isShovel = false;
    void DetectSpawnPoint()
    {
        // Detect when mouse is clicked (first touch click)
        if (Input.GetMouseButtonDown(0))
        {
            // Detecting the world space position of the mouse
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // Detecting the cell position in the tilemap
            var cellPosDefault = spawnTilemaps.WorldToCell(mousePos);
            // Getting the center of the cell
            var cellPosCenter = spawnTilemaps.GetCellCenterWorld(cellPosDefault);

            // Check if the cell is occupied 
            if (spawnTilemaps.GetColliderType(cellPosDefault) == Tile.ColliderType.Sprite)
            {
                int towerCost = checkTowerCost(spawnID);
                // Check if the currency is enough 
                if (GameManager.instance.currencySystem.isEnough(towerCost))
                {
                    applyCooldown();
                    GameManager.instance.currencySystem.useCurrency(towerCost);
                    spawnTower(cellPosCenter, cellPosDefault);
                    // Disables the collider
                    spawnTilemaps.SetColliderType(cellPosDefault, Tile.ColliderType.None);
                }
                else
                {
                    StartCoroutine(insufficientCurrency());
                }
            }
            else
            {
                Debug.Log("OCCUPIED");
                if (isShovel == true)
                {
                    isShovel = false;
                    Debug.Log("THE SHOVEL IS NOW " + isShovel);
                    spawnTower(cellPosCenter, cellPosDefault);
                    spawnTilemaps.SetColliderType(cellPosDefault, Tile.ColliderType.None);
                }
            }
        }
    }

    public void activeShovel()
    {
        isShovel = true;
    }

    public int checkTowerCost(int id)
    {
        switch (id)
        {
            case 0: return towersPrefabs[id].GetComponent<towerIncome>().towerCost; // REPLICATOR
            case 1: return towersPrefabs[id].GetComponent<towerAttacker>().towerCost; // EOSISHOOTER
            case 2: return towersPrefabs[id].GetComponent<towerDefense>().towerCost; // MAST WALL
            case 3: return towersPrefabs[id].GetComponent<towerAttacker>().towerCost; // DUETOPLASM
            case 4: return towersPrefabs[id].GetComponent<towerDefense>().towerCost; // SWAB 
            case 5: return towersPrefabs[id].GetComponent<towerAttacker>().towerCost; // VITELLUS 
            case 6: return towersPrefabs[id].GetComponent<towerAttacker>().towerCost; // Molpastes Cafer 
            case 7: return towersPrefabs[id].GetComponent<towerDefense>().towerCost; // Cyxic  
            case 8: return towersPrefabs[id].GetComponent<towerDefense>().towerCost; // Safe Guard 
            default: return -1;
        }
    }

    void spawnTower(Vector3 position, Vector3Int cellPosition)
    {
        GameObject tower = Instantiate(towersPrefabs[spawnID], spawnTowerRoot);
        tower.transform.position = position;
        tower.GetComponent<towerParent>().InitializationValues(cellPosition);
        deselectTower();
    }
    public void revertCellState(Vector3Int pos)
    {
        spawnTilemaps.SetColliderType(pos, Tile.ColliderType.Sprite);
    }

    public void selectTower(int id)
    {
        spawnID = id;
    }

    IEnumerator insufficientCurrency()
    {
        // CHANGE THE SPRITE TO RED 
        towersUI[spawnID].color = Color.red;
        // WAIT FOR SECONDS TO TURN BACK THEN REVERT    
        yield return new WaitForSeconds(0.2f);
        towersUI[spawnID].color = Color.white;
        yield return new WaitForSeconds(0.2f);
        towersUI[spawnID].color = Color.red;
        yield return new WaitForSeconds(0.2f);
        towersUI[spawnID].color = Color.white;
        yield return new WaitForSeconds(0.2f);
        towersUI[spawnID].color = Color.red;
        yield return new WaitForSeconds(0.2f);
        towersUI[spawnID].color = new Color(0.5f, 0.5f, 0.5f);
    }

    public void deselectTower()
    {
        Debug.Log("DESELECTED");
        spawnID = -1;
        foreach (var t in towersUI)
        {
          t.color = new Color(0.5f, 0.5f, 0.5f);
        }
    }

    private void applyCooldown()
    {
        if (spawnID == -1)
        {
            Debug.Log("NO TOWER");
        }

        else if (spawnID == 0)
        {
            cooldownPanels[spawnID].SetActive(true);
        }

        else if (spawnID == 1)
        {
            cooldownPanels[spawnID].SetActive(true);
        }

        else if (spawnID == 2)
        {
            cooldownPanels[spawnID].SetActive(true);
        }

        else if (spawnID == 3)
        {
            cooldownPanels[spawnID].SetActive(true);
        }

        // spawnID 4 is for swab
        else if (spawnID == 5)
        {
            cooldownPanels[spawnID].SetActive(true);
        }

        else if (spawnID == 6)
        {
            cooldownPanels[spawnID].SetActive(true);
        }

        else if (spawnID == 7)
        {
            cooldownPanels[spawnID].SetActive(true);
        }

        else if (spawnID == 8)
        {
            cooldownPanels[spawnID].SetActive(true);
        }
    }

    private void towerAvailable()
    {
        if (towersUI.Count >= 2)
        {
            if (GameManager.instance.currencySystem.currentCurrency >= 10)
            {
                towersUI[0].color = Color.white;
            }

            if (GameManager.instance.currencySystem.currentCurrency >= 20)
            {
                towersUI[1].color = Color.white;
            }
        }

        if (towersUI.Count >= 3)
        {
            if (GameManager.instance.currencySystem.currentCurrency >= 10)
            {
                towersUI[2].color = Color.white;
            }
        }

        if (towersUI.Count >= 4)
        {
            if (GameManager.instance.currencySystem.currentCurrency >= 40)
            {
                towersUI[3].color = Color.white;
            }
        }

        if (towersUI.Count >= 5)
        {
            towersUI[4].color = Color.white;
        }

        if (towersUI.Count >= 6)
        {
            if (GameManager.instance.currencySystem.currentCurrency >= 35)
            {
                towersUI[5].color = Color.white;
            }
        }

        if (towersUI.Count >= 7)
        {
            if (GameManager.instance.currencySystem.currentCurrency >= 50)
            {
                towersUI[6].color = Color.white;
            }
        }

        if (towersUI.Count >= 8)
        {
            // CYXIC
            if (GameManager.instance.currencySystem.currentCurrency >= 5)
            {
                towersUI[7].color = Color.white;
            }
        }

        
        if (towersUI.Count >= 9)
        {   
            // SAFEGUARD
            if (GameManager.instance.currencySystem.currentCurrency >= 25)
            {
                towersUI[8].color = Color.white;
            }
        }
    }
}
