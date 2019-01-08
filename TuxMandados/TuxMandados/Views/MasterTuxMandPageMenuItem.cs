using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuxMandados.Views
{

    public class MasterTuxMandPageMenuItem
    {
        public MasterTuxMandPageMenuItem()
        {
            TargetType = typeof(MasterTuxMandPageDetail);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}