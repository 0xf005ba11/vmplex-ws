using HyperV;
using EasyWMI;
using System.Management;
using System;

namespace VMPlex.HyperV
{
    public class Job
    {
        private IMsvm_ConcreteJob ConcreteJob { get; set; }

        public Job(IMsvm_ConcreteJob concreteJob)
        {
            ConcreteJob = concreteJob;
        }
        public Job(ManagementBaseObject concreteJob)
        {
            ConcreteJob = WmiClassGenerator.CreateInstance<IMsvm_ConcreteJob>(concreteJob);
        }

        public void WaitForCompletion()
        {
            ManagementObject obj = ConcreteJob.__Instance as ManagementObject;
            if (obj == null)
            {
                throw new InvalidOperationException("Cannot wait on invalid job");
            }

            while (ConcreteJob.JobState == 4 /* Running */)
            {
                System.Threading.Thread.Sleep(1);
                obj.Get();
            }
        }
    }
}
