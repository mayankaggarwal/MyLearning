using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MyProj.CM.Common.RabbitMQ.Type
{
    public enum DeliveryMode
    {
        [Description("NonPersistent")]
        NonPersistent=1,

        [Description("Persistent")]
        Persistent=2
    }
}
