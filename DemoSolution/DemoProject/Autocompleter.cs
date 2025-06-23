using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProject;

public class Autocompleter<T>
{
    public required string Query { get; set; }
    public required List<T> Data { get; set; }
    public List<T>? Suggestions { get; set; }

    public void Autocomplete()
    {
        if (Data is null)
        {
            throw new NotSupportedException("Data is null");
        }

        Suggestions = new();

        foreach (var item in Data)
        {
            if (item is null)
            {
                continue;
            }
            
            var props = item.GetType().GetProperties(); // make model
            foreach (var prop in props)
            {
                var value = prop.GetValue(item) as string;
                if (value is not null && value.Contains(Query))
                {
                    Suggestions.Add(item);
                }
            }
        }
    }
}
