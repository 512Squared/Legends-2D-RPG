using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine.UI;

namespace __Scripts.Grid
{
    public  class GridTilemaps : MonoBehaviour, ISaveable
    {
        
        private LevelManager level;
        private int width;
        private int height;
        private Vector3 origin;
        private float cellSize;

        private List<Grid<GridTilemaps>> gridList;

        List<string> scenes = new();

        

        [SerializeField]
        private int fontSize = 10;
        
        private void Start()
        {
            StartCoroutine(StartCo());
            
            // foreach(EditorBuildSettingsScene scene in EditorBuildSettings.scenes)
            // {
            //     if(scene.enabled) { scenes.Add(scene.path); }
            // }
        }

        private IEnumerator StartCo()
        {
            yield return new WaitForSeconds(0.2f);
            level = FindObjectOfType<LevelManager>();
            level.GetTilemapSize(out origin, out width, out height, out cellSize);
            Debug.Log($"Grid specs: {width} | {height} | {cellSize} | {origin}");
        }

        public void GetTilemapData(out Vector3 p_Origin, out int p_Width, out int p_Height, out float p_CellSize)
        {
            p_Origin = origin;
            p_Width = width;
            p_Height = height;
            p_CellSize = cellSize;
        }
        
        
        #region Implementation of ISaveable

        public void PopulateSaveData(SaveData a_SaveData)
        {
            
            
            
        }

        public void LoadFromSaveData(SaveData a_SaveData)
        {
            
            
            
        }

        #endregion
        
    }
}