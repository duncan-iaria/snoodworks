using System.Collections.Generic;
using UnityEngine;

namespace SNDL
{
  public abstract class RuntimeSet<T> : ScriptableObject
  {
    public List<T> items = new List<T>();

    public void add(T tNewListItem, bool isDuplicatedEntriesAllowed = false)
    {
      if (isDuplicatedEntriesAllowed)
      {
        items.Add(tNewListItem);
      }
      else
      {
        if (!items.Contains(tNewListItem))
        {
          items.Add(tNewListItem);
        }
      }
    }

    public void remove(T tListItemToRemove)
    {
      if (items.Contains(tListItemToRemove))
      {
        items.Remove(tListItemToRemove);
      }
    }
  }
}