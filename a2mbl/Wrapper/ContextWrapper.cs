﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace a2mbl.Wrapper
{
    internal class ContextWrapper : BaseContextWrapper<a2mContext>
    {
        public ContextWrapper() : base() { }

        public ContextWrapper(bool shared) : base(shared) { }

    }
}