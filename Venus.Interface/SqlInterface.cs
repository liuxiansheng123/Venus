using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Venus.Model;

namespace Venus.Interface
{
    public interface SqlInterface
    {
        IEnumerable<T> QueryList<T>() where T : BaseModel;

        bool Insert<T>(T model) where T : BaseModel;

        T GetSinge<T>(string ID) where T : BaseModel;
    }
}
