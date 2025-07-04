using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWLUiDemo.Help
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public class PageAliasAttribute : Attribute
    {
        public string Alias { get; }

        public int Index { set; get; }

        public PageAliasAttribute(string alias,int _Index=1)
        {
            Alias = alias;
            Index= _Index;
        }
    }
}
