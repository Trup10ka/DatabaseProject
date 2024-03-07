﻿using DbProject.Database.Data;

namespace DbProject.Database.Dao;

public class Table(string name)
{
    
    public string Name { get; init; } = name;
    public List<Column> Columns { get; } = [];
    
    private void RegisterColumn(string name, ColumnType type)
    {
        var column = new Column(name, type);
        Columns.Add(column);
    }

    protected void Varchar(string name) => RegisterColumn(name, ColumnType.VARCHAR);
    
    protected void Int(string name) => RegisterColumn(name, ColumnType.INT);
    
    protected void Bit(string name) => RegisterColumn(name, ColumnType.BIT);
    
    protected void Date(string name) => RegisterColumn(name, ColumnType.DATE);
}