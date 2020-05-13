using System;
using System.Collections.Generic;
using System.Text;

namespace models
{
    public interface ILogManager
    {
        public void Log(String info);
    }
    public class LogManager : ILogManager
    {
        public ILog _Ilog;
        public LogManager(ILog log)
        {
            this._Ilog = log;
        }
        public void Log(String info)
        {
            _Ilog.Write(info);
        }
    }
}
