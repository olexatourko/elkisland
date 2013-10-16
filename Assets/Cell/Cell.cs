﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Cell {

	public Cell_GameObject cell_GameObject;
	
	public bool selected = false;
	public CellType cellType;
	public enum CellType
	{
		None,
		Path,
		Path_Start,
		Path_End,
		Woods
	}
	
	public Cell left;
	public Cell top;
	public Cell right;
	public Cell bottom;
	public string name;
	
	 //temporary for Astar
	public Cell AStar_Parent;
	public float g = 0;
	public float f = 65536;
	public float h = 0;
	public int cost = 1;
	//for threading
	public Vector3 position;
	
	//Move later (models)
	public GameObject model_instance;
	public GameObject model_random;
	
	
	public Cell(Cell_GameObject _cell_GameObject)
	{
		cell_GameObject = _cell_GameObject;
	}
	
	public List<Cell> getNeighbors()
	{
		List<Cell> cells = new List<Cell>();
		if(left != null) cells.Add(left);
		if(top != null) cells.Add(top);
		if(right != null) cells.Add(right);
		if(bottom != null) cells.Add(bottom);
		return cells;
	}
	/*--------------------------------------------------------------------------*/
	
	public bool IsAdjacent(Cell _cell)
	{
		if(_cell == left || _cell == right || _cell == top || _cell == bottom) return true;
		return false;
	}
	
	public void setType(CellType _type)
	{
		cellType = _type;
	}
	
	public void Select()
	{
		if(selected) return;
		selected = true;
		//if(cell_GameObject != null) cell_GameObject.Redraw();
	}
	
	public void Deselect()
	{
		selected = false;
		//if(cell_GameObject != null) cell_GameObject.Redraw();
	}
	
	public int CostMinusOne() { return cost - 1; }
	
}
