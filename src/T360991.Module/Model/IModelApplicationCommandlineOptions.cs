using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using DevExpress.ExpressApp.Model;

namespace T360991.Module.Model
{
    public interface IModelApplicationCommandlineOptions : IModelNode
    {
        IModelCommandlineOptionsIModelNode CommandlineOptions { get; }
    }
}
