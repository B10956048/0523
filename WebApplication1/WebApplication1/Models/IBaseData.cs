using System;

namespace WebApplication1.Models
{
    public interface IBaseData
    {
        bool IsDelete { get; set; }
        
        DateTime creDateTime { get; set; }

        DateTime UpdateDateTime { get; set; }


    }
}
