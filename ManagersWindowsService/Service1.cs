using ManagerDataBase.PL.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ManagersWindowsService
{
    public partial class Service1 : ServiceBase
    {
        private ServicePL servicePL;

        public Service1()
        {
            InitializeComponent();
            CanStop = true;
        }

        protected override void OnStart(string[] args)
        {
            servicePL = new ServicePL();
            Thread servicePLThread = new Thread(new ThreadStart(servicePL.Start));
            servicePLThread.Start();
        }

        protected override void OnStop()
        {
            servicePL.Stop();
            Thread.Sleep(1000);
        }
    }
}
