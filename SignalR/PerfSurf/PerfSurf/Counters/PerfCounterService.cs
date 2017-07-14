using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfSurf.Counters
{
    public class PerfCounterService
    {
        List<PerfCounterWrapper> _counters;

        public PerfCounterService()
        {
            _counters = new List<PerfCounterWrapper>();

            _counters.Add(new PerfCounterWrapper("Processor",
                "Processor", "% Processor Time", "_Total"));

            _counters.Add(new PerfCounterWrapper("Paging",
                "Memory", "Pages/sec"));

            _counters.Add(new PerfCounterWrapper("Disk",
                "PhysicalDisk", "% Disk Time", "_Total"));
        }

        public dynamic GetResults()
        {
            return _counters.Select(c => new
            { name = c.Name, value = c.Value });
        }
    }
}
