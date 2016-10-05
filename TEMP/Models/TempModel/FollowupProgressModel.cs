using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SSM.Models.TempModel
{
    public class FollowupProgressModel
    {
        [UIHint("Plan_Step")]
        public List<Plan_Step> steps { get; set; }
        public int id { get; set; }
        public String Name { get; set; }
        public String Desription { get; set; }
        public FollowupProgressModel() { steps = new List<Plan_Step>(); }
        public FollowupProgressModel(PrePurchase_FollowUp_Plan plan)
        {
            this.Name = plan.name;
            this.id = plan.id;
            this.Desription = plan.Description;
            steps = new List<Plan_Step>();
            foreach (Plan_Step step in plan.Plan_Step)
            {
                System.Diagnostics.Debug.WriteLine("dafug");
                steps.Add(step);

            }

            int count = steps.Count();
            System.Diagnostics.Debug.WriteLine("dafug  2"+ count);
            for (int i = count+1; i < 9; i++) {
                Plan_Step step = new Plan_Step();
                step.stepNo = i;
                steps.Add(step);
            }
             count = steps.Count();
            System.Diagnostics.Debug.WriteLine("dafug 3  " + count);
        }
    }
}