using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using AStar.Algorithm;

namespace AStar.Resources
{
    class StepInfo
    {
        public AStarStep Step { get; set; }
        public string Info { get; set; }

        public override string ToString()
        {
            return Info;
        }

        public static List<StepInfo> GetSteps()
        {
            List<StepInfo> info = new List<StepInfo>();
            ResourceManager rm = new ResourceManager("AStar.Resources.StepsResource", typeof(StepInfo).Assembly);

            for (int i = 0; i < Enum.GetValues(typeof (AStarStep)).Length; i++)
            {
                info.Add(new StepInfo()
                {
                    Step = (AStarStep) i,
                    Info = rm.GetString("StepInfo" + i, CultureInfo.CurrentCulture)
                });
            }

            return info;
        }
    }
}
