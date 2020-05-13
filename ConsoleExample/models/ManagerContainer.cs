using models;
using System;
using System.Collections.Generic;
using System.Text;

namespace models
{
    public interface IManagerContainer { 
        
    }
    class ManagerContainer : IManagerContainer
    {
        ILogManager _iLogManager;
        public ManagerContainer(ILogManager manager)
        {
            _iLogManager = manager;
        }
    }
}
