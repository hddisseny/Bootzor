using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Bootzor.Components.Form;

public partial class ZorAutoForm<TObjectForm> : ComponentBase where TObjectForm : class
{
    public Dictionary<string, Type> dataObject { get; set; }
    
    protected string eso { get; set; }

    public ZorAutoForm(TObjectForm itemToBuildForm)
    {
        dataObject = GetParametersObject(itemToBuildForm);
    }

    public Dictionary<string, Type> GetParametersObject(TObjectForm item)
    {
        Dictionary<string, Type> parameters = new Dictionary<string, Type>();

        Type t = item.GetType();

        PropertyInfo[] pinfo = t.GetProperties();
        foreach (var tParam in pinfo)
        {
            parameters.Add(tParam.Name, tParam.PropertyType);
        }
        return parameters;
    }
}