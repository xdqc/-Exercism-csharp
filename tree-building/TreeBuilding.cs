using System;
using System.Collections.Generic;
using System.Linq;

public class TreeBuildingRecord
{
    public int ParentId { get; set; }
    public int RecordId { get; set; }
}

public class Tree
{
    public int Id { get; set; }
    public int ParentId { get; set; }

    public List<Tree> Children { get; set; }

    public bool IsLeaf => Children.Count == 0;

    /*** BFS ***/
    internal Tree GetNodeById(int id)
    {
        var q = new Queue<Tree>();
        q.Enqueue(this);
        while (q.Count > 0)
        {
            var current = q.Dequeue();
            if (current.Id == id)
            {
                return current;
            }
            current.Children.ForEach(t => q.Enqueue(t));
        }
        return null;
    }
}

public static class TreeBuilder
{
    public static Tree BuildTree(IEnumerable<TreeBuildingRecord> rawRecords)
    {
        var records = rawRecords.OrderBy(r => r.RecordId).ToList();
        if (records.FirstOrDefault(r => r.RecordId==0 && r.ParentId==0) == null)
            throw new ArgumentException("Must have a root.");
            
        var t = new Tree(){
            Id = 0, 
            ParentId = 0, 
            Children = new List<Tree>()};

        for (int i = 1; i < records.Count(); i++)
        {
            ValidateRecord(records[i], i);
            t.GetNodeById(records[i].ParentId).Children.Add(new Tree(){
                Id = records[i].RecordId, 
                ParentId = records[i].ParentId,
                Children = new List<Tree>()});
        }
        return t;
    }

    public static void ValidateRecord(TreeBuildingRecord record, int serialId)
    {
        if(record.RecordId != serialId)
            throw new ArgumentException("Record ID must be continuous");
        else if(record.RecordId <= record.ParentId)
            throw new ArgumentException("Record must have an existing parent.");
    }
}