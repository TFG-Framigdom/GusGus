using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell 
{
    public int x;
    public int y;

    public int value;
    public bool visited = false;

    public bool westCell = true;
    public bool eastCell = true;
    public bool northCell = true;
    public bool southCell = true;

    public Cell(int x, int y){
        this.x = x;
        this.y = y;
        this.value = 1;

    }

    
}

