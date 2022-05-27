using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using System.Text;
using CLR_HW_Project;
using Microsoft.SqlServer.Server;

[Serializable]
[Microsoft.SqlServer.Server.SqlUserDefinedAggregate(Format.UserDefined, MaxByteSize =8000)]
public class MyString_Agg :IBinarySerialize
{

    private StringBuilder _res;
    private string _separator;

    public void Init()
    {
        _separator = "";
        _res = new StringBuilder();
    }

    public void Accumulate(SqlString Value, SqlString separator)
    {
        if (!separator.IsNull)
        {
            _separator = separator.ToString();
        }
        if (!Value.IsNull)
        {
            _res.Append(Value.ToString()).Append(separator.ToString());
        }    
        else
        {
            _res.Append("null").Append(separator.ToString());
        }
    }

    public void Merge (MyString_Agg Group)
    {
        if (Group._separator != null)
        {
            _separator = Group._separator;
        }
        _res.Append(Group._res);
    }

    public string Terminate ()
    {
        var output = "";
        if (_res != null && _res.Length!=0)
        {
            if (_separator != null)
                output = StringFormatHelper.RemoveLastSeparator(_res, _separator.Length);
            else
                output = _res.ToString();
        }
        
        return output;
    }

    public void Read(BinaryReader r)
    {
        _res = new StringBuilder(r.ReadString());
        _separator = r.ReadString();
    }

    public void Write(BinaryWriter w)
    {
        w.Write(_res.ToString());
        w.Write(_separator);
    }


}
